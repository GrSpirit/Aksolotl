using System;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aksolotl
{
    public partial class Form1 : Form
    {
        const int MAX_POINTS_TO_SHOW = 300;
        private readonly Port serialPort = new Port();
        private readonly PortMock fakePort = new PortMock();
        private Thread portThread;
        private IPort Port {
            get {
                if (UseMock) return fakePort;
                return serialPort;
            }
        }
        public Form1()
        {
            InitializeComponent();
            serialPort.Finished += Visualize;
            fakePort.Finished += Visualize;
            serialPort.Read += Visualize;
            fakePort.Read += Visualize;
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
        }

        private void run_stop_Click(object sender, EventArgs e)
        {
            try {
                if (Port.IsOpen) {
                    run_stop.Text = "run";
                    //Port.Close();
                    backgroundWorker1.CancelAsync();
                }
                else {
                    run_stop.Text = "stop";
                    backgroundWorker1.RunWorkerAsync(comboBox1.Text);
                    //Port.Open(comboBox1.Text);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //чтение портов доступных в системе
            //string[] ports = SerialPort.GetPortNames();
            //Очистка содержимого бокса
            //comboBox1.Items.Clear();
            //Добавление найденных портов в бокс
            //comboBox1.Items.AddRange(ports);
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
            Port.Save(Channel.ONE);
        }

        private void button_export_ch2_Click(object sender, EventArgs e)
        {
            Port.Save(Channel.TWO);
        }

        private void Visualize(object sender, EventArgs e)
        {
            //chart1.Series[0].Points.Clear();
            IPort port = (IPort)sender;
            for (int i = 0; i < Math.Min(MAX_POINTS_TO_SHOW, port.ChannelData1.Count); i++) {
                if (chart1.Series[0].Points.Count > MAX_POINTS_TO_SHOW) {
                    chart1.Series[0].Points.Clear();
                }
                this.chart1.Series[0].Points.AddXY(i, port.ChannelData1[i]);
            }
            port.ChannelData1.Clear();

            //chart1.Series[1].Points.Clear();
            for (int i = 0; i < Math.Min(MAX_POINTS_TO_SHOW, port.ChannelData2.Count); i++) {
                if (chart1.Series[1].Points.Count > MAX_POINTS_TO_SHOW) {
                    chart1.Series[1].Points.Clear();
                }
                this.chart1.Series[1].Points.AddXY(i, port.ChannelData2[i]);
            }
            port.ChannelData2.Clear();
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
            List<double> channelData1 = new List<double>();
            List<double> channelData2 = new List<double>();
            Port.GetData(channelData1, channelData2, MAX_POINTS_TO_SHOW);
            for (int i = 0; i < Math.Min(MAX_POINTS_TO_SHOW, channelData1.Count); i++) {
                if (chart1.Series[0].Points.Count > MAX_POINTS_TO_SHOW) {
                    chart1.Series[0].Points.Clear();
                }
                this.chart1.Series[0].Points.AddXY(i, channelData1[i]);
            }
            //chart1.Series[1].Points.Clear();
            for (int i = 0; i < Math.Min(MAX_POINTS_TO_SHOW, channelData2.Count); i++) {
                if (chart1.Series[1].Points.Count > MAX_POINTS_TO_SHOW) {
                    chart1.Series[1].Points.Clear();
                }
                this.chart1.Series[1].Points.AddXY(i, channelData2[i]);
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
