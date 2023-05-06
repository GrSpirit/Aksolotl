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
            List<double> channelData1 = new List<double>(totalPoints);
            List<double> channelData2 = new List<double>(totalPoints);
            Port.GetData(channelData1, channelData2, totalPoints);
            int frequency = (int)frequencyComboBox.SelectedValue;
            double period = 1000.0 / (double)frequency;
            int pointsToSkip = totalPoints / pointsToShow - 1;

            chart1.Series[0].Points.Clear();
            int j = 0;
            for (int i = 0; i < channelData1.Count; i++) {
                if (j >= pointsToSkip) {
                    double x = Math.Round(i * period, 3);
                    this.chart1.Series[0].Points.AddXY(x, channelData1[i]);
                    j = 0;
                }
                j++;
            }
            chart1.Series[1].Points.Clear();
            j = 0;
            for (int i = 0; i < channelData2.Count; i++) {
                if (j >= pointsToSkip) {
                    double x = Math.Round(i * period, 3);
                    this.chart1.Series[1].Points.AddXY(x, channelData2[i]);
                    j = 0;
                }
                j++;
            }

            chartMath.Series[0].Points.Clear();
            if (channelData1.Count > 0 && channelData2.Count > 0) {
                if (fftRadioButton.Checked) {
                    bool isOdd = (channelData2.Count & 1) == 1;
                    double[] fftResult = channelData1.Take(isOdd ? channelData1.Count : (channelData1.Count - 1)).ToArray();
                    int n = fftResult.Length - 2;
                    MathNet.Numerics.IntegralTransforms.Fourier.ForwardReal(fftResult, n);
                    int from = int.Parse(fftFromTextBox.Text);
                    int to = int.Parse(fftToTextBox.Text);
                    if (from >= fftResult.Length) {
                        return;
                    }
                    for (int x = from; x < Math.Min(to + 1, fftResult.Length); x++) {
                        this.chartMath.Series[0].Points.AddXY((double)x, fftResult[x]);
                    }
                }
                else {
                    j = 0;
                    for (int i = 0; i < Math.Min(channelData1.Count, channelData2.Count); i++) {
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

    public class FFT
    {
        /// <summary>
        /// Вычисление поворачивающего модуля e^(-i*2*PI*k/N)
        /// </summary>
        /// <param name="k"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        private static Complex w(int k, int N)
        {
            if (k % N == 0) return 1;
            double arg = -2 * Math.PI * k / N;
            return new Complex(Math.Cos(arg), Math.Sin(arg));
        }
        /// <summary>
        /// Возвращает спектр сигнала
        /// </summary>
        /// <param name="x">Массив значений сигнала. Количество значений должно быть степенью 2</param>
        /// <returns>Массив со значениями спектра сигнала</returns>
        public static Complex[] fft(Complex[] x)
        {
            Complex[] X;
            int N = x.Length;
            if (N == 2)
            {
                X = new Complex[2];
                X[0] = x[0] + x[1];
                X[1] = x[0] - x[1];
            }
            else
            {
                Complex[] x_even = new Complex[N / 2];
                Complex[] x_odd = new Complex[N / 2];
                for (int i = 0; i < N / 2; i++)
                {
                    x_even[i] = x[2 * i];
                    x_odd[i] = x[2 * i + 1];
                }
                Complex[] X_even = fft(x_even);
                Complex[] X_odd = fft(x_odd);
                X = new Complex[N];
                for (int i = 0; i < N / 2; i++)
                {
                    X[i] = X_even[i] + w(i, N) * X_odd[i];
                    X[i + N / 2] = X_even[i] - w(i, N) * X_odd[i];
                }
            }
            return X;
        }
        /// <summary>
        /// Центровка массива значений полученных в fft (спектральная составляющая при нулевой частоте будет в центре массива)
        /// </summary>
        /// <param name="X">Массив значений полученный в fft</param>
        /// <returns></returns>
        public static Complex[] nfft(Complex[] X)
        {
            int N = X.Length;
            Complex[] X_n = new Complex[N];
            for (int i = 0; i < N / 2; i++)
            {
                X_n[i] = X[N / 2 + i];
                X_n[N / 2 + i] = X[i];
            }
            return X_n;
        }
    }

}
