using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Filtering;

namespace Aksolotl
{

    public partial class Form1 : Form
    {
        private const int MAX_POINTS_TO_SHOW = 2000;
        private readonly Port serialPort = new Port();
        private readonly PortMock fakePort = new PortMock();
        private IPort Port {
            get {
                if (UseMock) return fakePort;
                return serialPort;
            }
        }

        private class FrequencyItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        public bool UseMock { get { return mockCheckBox.Checked; } }
        private void Form1_Load(object sender, EventArgs e)
        {
            //чтение портов доступных в системе
            string[] ports = SerialPort.GetPortNames();
            //Очистка содержимого бокса
            comboBox1.Items.Clear();
            //Добавление найденных портов в бокс
            comboBox1.Items.AddRange(ports);
            run_stop.Text = "run";
            var frequencies = new List<FrequencyItem>() {
                new FrequencyItem { Text = "856 кГц (F103 DMA + ACP)", Value = 856 },
                new FrequencyItem { Text = "1,71 МГц (F103 DMA + 2ACP)", Value = 1712 },
                new FrequencyItem { Text = "2,00 МГц (F407 DMA + 1ACP)", Value = 2000 },
                new FrequencyItem { Text = "3,75 МГц (F407 DMA + 2ACP)", Value = 3750 }
            };
            frequencyComboBox.DataSource = frequencies;
            frequencyComboBox.DisplayMember = "Text";
            frequencyComboBox.ValueMember = "Value";
            frequencyComboBox.SelectedIndex = 0;
        }

        private void run_stop_Click(object sender, EventArgs e)
        {
            try {
                if (Port.IsOpen) {
                    //run_stop.Text = "run";
                    backgroundWorker1.CancelAsync();
                }
                else {
                    run_stop.Text = "stop";
                    backgroundWorker1.RunWorkerAsync(comboBox1.Text);
                    timer1.Start();
                }
            } catch (EmptyPortNameException) {
                run_stop.Text = "run";
                MessageBox.Show("Выберите порт для начала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox_fft_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_std_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_dfm.Checked) {
                Port.Mode = PortMode.DFM;
            }
            else {
                Port.Mode = PortMode.STD;
            }
            if (Port.IsOpen) {
                Port.Init();
            }
        }

        private void button_export_ch1_Click(object sender, EventArgs e)
        {
            if (saveCsvFileDialog.ShowDialog(this) == DialogResult.OK) {
                Port.Save(Channel.ONE, saveCsvFileDialog.FileName);
            }
        }

        private void button_export_ch2_Click(object sender, EventArgs e)
        {
            if (saveCsvFileDialog.ShowDialog(this) == DialogResult.OK) {
                Port.Save(Channel.TWO, saveCsvFileDialog.FileName);
            }
        }

        private void accuracyRadioButton15_CheckedChanged(object sender, EventArgs e)
        {
            if (accuracyRadioButton213.Checked) {
                Port.Accuracy = PortAccuracy.FINE;
            } else {
                Port.Accuracy = PortAccuracy.RAW;
            }
            if (Port.IsOpen) {
                Port.Init();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                Port.Open((string)e.Argument, () => { return backgroundWorker1.CancellationPending; });
            }
            catch (EmptyPortNameException) {
                MessageBox.Show("Выберите порт для начала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            run_stop.Text = "run";
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int pointsToShow = MAX_POINTS_TO_SHOW; 
            int totalPoints = int.Parse(numPointsBox.Text, System.Globalization.NumberStyles.None);
            double deltaVolt = bufferCheckBox.Checked ? -1.65 : 0;
            (var channelData1, var channelData2) = Port.GetData(totalPoints, deltaVolt);
            int frequency = (int)frequencyComboBox.SelectedValue;
            double period = 1000.0 / (double)frequency;
            int pointsToSkip = totalPoints / pointsToShow - 1;

            chart1.Series[0].Points.Clear();
            if (showCheckBox1.Checked) {
                int j = 0;
                for (int i = 0; i < channelData1.Length; i++) {
                    if (j >= pointsToSkip) {
                        double x = Math.Round(i * period, 3);
                        this.chart1.Series[0].Points.AddXY(x, channelData1[i]);
                        j = 0;
                    }
                    j++;
                }
            }
            chart1.Series[1].Points.Clear();
            if (showCheckBox2.Checked) {
                int j = 0;
                for (int i = 0; i < channelData2.Length; i++) {
                    if (j >= pointsToSkip) {
                        double x = Math.Round(i * period, 3);
                        this.chart1.Series[1].Points.AddXY(x, channelData2[i]);
                        j = 0;
                    }
                    j++;
                }
            }

            chartMath.Series[0].Points.Clear();
            if (channelData1.Length > 0 && fftRadioButton.Checked) {
                MathNet.Numerics.IntegralTransforms.Fourier.ForwardReal(channelData1, channelData1.Length - 2);
                int from = int.Parse(fftFromTextBox.Text);
                int to = int.Parse(fftToTextBox.Text);
                if (from >= channelData1.Length || to <= from) {
                    return;
                }
                for (int x = from; x < Math.Min(to + 1, channelData1.Length - 2); x++) {
                    this.chartMath.Series[0].Points.AddXY(x, channelData1[x]);
                }
            }
            else if (channelData1.Length > 0 && channelData2.Length > 0) {
                int j = 0;
                for (int i = 0; i < Math.Min(channelData1.Length, channelData2.Length); i++) {
                    if (j >= pointsToSkip) {
                        double x = Math.Round(i * period, 3);
                        double y = 0;
                        if (addRadioButton.Checked) {
                            y = channelData1[i] + channelData2[i];
                        }
                        else if (subRadioButton.Checked) {
                            y = channelData1[i] - channelData2[i];
                        }
                        else if (multRadioButton.Checked) {
                            y = channelData1[i] * channelData2[i];
                        }
                        else if (divRadioButton.Checked) {
                            y = channelData1[i] / Math.Max(channelData2[i], 0.001);
                        }
                        this.chartMath.Series[0].Points.AddXY(x, y);
                        j = 0;
                    }
                    j++;
                }
            }
        }

        private void numPointsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            numPointsBox.Text = numPointsTrackBar.Value.ToString();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            //Очистка содержимого бокса
            comboBox1.Items.Clear();
            //Добавление найденных портов в бокс
            comboBox1.Items.AddRange(ports);
        }

        private void fftFromTextBox_TextChanged(object sender, EventArgs e)
        {
            MaskedTextBox textBox = sender as MaskedTextBox;
            if (textBox.Text == "") {
                textBox.Text = "0";
            }
        }
    }
}
