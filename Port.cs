using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aksolotl
{

    enum PortMode: byte
    {
        DFM = 0b11111111,
        STD = 0b11110000,
        SAM15 = 0b11110001,
        SAM84 = 0b11110010,
        SAM144 = 0b11110011,
        SAM480 = 0b11110100,
    }
    enum PortAccuracy: byte
    {
        RAW = 0b10110000,
        FINE = 0b10110001
    }
    enum Channel
    {
        ONE,
        TWO
    }
    delegate bool IsProcessCanceled();
    interface IPort
    {
        /// <summary>
        /// Порт открыт?
        /// </summary>
        bool IsOpen { get; }
        /// <summary>
        /// Открыть порт и инициализировать с ним работу
        /// </summary>
        /// <param name="portName">имя порта</param>
        void Open(string portName, IsProcessCanceled processCanceled);
        void Init();
        /// <summary>
        /// Закрыть порт
        /// </summary>
        void Close();
        /// <summary>
        /// Данные канала 1
        /// </summary>
        IList<double> ChannelData1 { get; }
        /// <summary>
        /// Данные канала 2
        /// </summary>
        IList<double> ChannelData2 { get; }
        /// <summary>
        /// Режим работы порта std/dfm
        /// </summary>
        PortMode Mode { get; set; }
        PortAccuracy Accuracy { get; set; }
        UInt16 SampleRate { get; set; }
        /// <summary>
        /// Записать полученные данные в файл
        /// </summary>
        /// <param name="channel">номер канала</param>
        void Save(Channel channel, string fileName);
        Tuple<double[], double[], UInt16> GetData(int count, double deltaVolt);
        double SamplePeriod { get; }
    }
    abstract class APortBase : IPort
    {
        /// <summary>
        /// Максимальное число байт вычитываемых из порта
        /// </summary>
        public const int MAX_BYTES_TO_READ = 20 * 1024 * 1024;
        protected Object obj = new Object();
        protected IsProcessCanceled processCanceled;
        private readonly List<double> channelData1 = new List<double>();
        private readonly List<double> channelData2 = new List<double>();
        public virtual IList<double> ChannelData1 { get { return channelData1; } }
        public virtual IList<double> ChannelData2 { get { return channelData2; } }
        protected int readBytes = 0;
        protected byte[] buffer = new byte[100000];

        public event EventHandler Finished;
        public event EventHandler Read;
        public abstract bool IsOpen { get; }
        private PortMode mode = PortMode.STD;
        public virtual PortMode Mode { get { return mode; } set { mode = value; } }
        public virtual PortAccuracy Accuracy { get; set; }
        public virtual UInt16 SampleRate { get; set; }
        public virtual double SamplePeriod { get {
                switch(Mode) {
                    case PortMode.STD:
                        return 0.5;
                    case PortMode.SAM15:
                        return 0.9;
                    case PortMode.SAM84:
                        return 3.2;
                    case PortMode.SAM144:
                        return 5.2;
                    case PortMode.SAM480:
                        return 16.4 * 2;
                    default:
                        return 0.5 / 3;
                }
            } 
        }
        public abstract void Init();
        public virtual void Open(string portName, IsProcessCanceled processCanceled)
        {
            readBytes = 0;
            this.processCanceled = processCanceled;
            channelData1.Clear();
            channelData2.Clear();
        }
        public abstract void Close();

        /// <summary>
        /// Converts data from the buffer to voltage and splits into 2 channels
        /// </summary>
        /// <param name="buffer">input buffer</param>
        /// <param name="length">buffer length</param>
        protected virtual void SplitData(byte[] buffer, int length)
        {
            lock (obj) {
                int offset = 0;

                // Ищем начало данных
                while (offset + 1 < length) {
                    if (buffer[offset] == 0xAD && buffer[offset + 1] == 0xDE) {
                        offset += 2;
                        break;
                    }
                    offset++;
                }

                // Данных нет
                if (offset + 1 >= length) {
                    return;
                }

                int n = (length - offset) / 2;
                UInt16[] data16 = new UInt16[n];
                Buffer.BlockCopy(buffer, offset, data16, 0, 2 * n);

                // Определяем канал
                UInt16 userData = data16[0];
                var channel = (userData & (1 << 1)) == (1 << 1) ? ChannelData2 : ChannelData1;
                SampleRate = data16[1];

                for (int i = 2; i < n; i++) {
                    if (channel.Count >= MAX_BYTES_TO_READ) {
                        channel.Clear();
                    }
                    var d = data16[i];
                    if (d == 0xDEAD) {
                        if (i + 2 < (length - offset) / 2) {
                            userData = data16[i + 1];
                            channel = (userData & (1 << 1)) == (1 << 1) ? ChannelData2 : ChannelData1;
                            SampleRate = data16[i + 2];
                            i += 2;
                        }
                    }
                    else {
                        channel.Add(ConvertWolt(data16[i]));
                    }
                }
            }
        }

        /// <summary>
        /// Converts input data to wolt
        /// </summary>
        /// <param name="data">data</param>
        /// <returns>volte</returns>
        protected virtual double ConvertWolt(UInt16 data)
        {
            return (double)(data) * 3.3 / 4096.0;
        }

        protected virtual void SaveDataToFile(string fileName, IList<double> data)
        {
            StreamWriter writer = new StreamWriter(fileName);
            foreach (double y in data) {
                writer.Write(y);
                writer.Write("\n");
            }
        }
        public virtual void Save(Channel channel, string fileName)
        {
            switch (channel) {
                case Channel.ONE:
                    SaveDataToFile(fileName, ChannelData1);
                    break;
                case Channel.TWO:
                    SaveDataToFile(fileName, ChannelData2);
                    break;
                default:
                    break;
            }
        }
        public virtual Tuple<double[], double[], UInt16> GetData(int count, double deltaVolt)
        {
            lock (obj) {
                double[] ch1 = ChannelData1.Skip(Math.Max(0, ChannelData1.Count - count)).Take(Math.Min(count, ChannelData1.Count)).Select((x) => x + deltaVolt).ToArray();
                double[] ch2 = ChannelData2.Skip(Math.Max(0, ChannelData2.Count - count)).Take(Math.Min(count, ChannelData2.Count)).Select((x) => x + deltaVolt).ToArray();
                return new Tuple<double[], double[], UInt16>(ch1, ch2, SampleRate);
            }
        }
    }

    class Port : APortBase
    {
        SerialPort port = new SerialPort();
        public Port()
        {
            port.BaudRate = 480000 * 12;
            port.ReadBufferSize = buffer.Length;
            port.Parity = Parity.None;
            port.Handshake = Handshake.None;
            port.StopBits = StopBits.One;
            port.DtrEnable = false;
            port.RtsEnable = false;
        }
        public override bool IsOpen { get { return port.IsOpen; } }
        public override void Init()
        {
            buffer[0] = (byte)Mode;
            port.Write(buffer, 0, 1);
            Thread.Sleep(8);
            ChannelData1.Clear();
            ChannelData2.Clear();
        }

        public override void Close()
        {
            port.Close();
        }

        /// <summary>
        /// Initiate and open port
        /// </summary>
        /// <param name="portName">port name</param>
        public override void Open(string portName, IsProcessCanceled processCanceled)
        {
            if (String.IsNullOrWhiteSpace(portName)) {
                throw new EmptyPortNameException();
            }
            port.PortName = portName;
            port.Open();
            // Устанавливаем режим работы std/dfm
            Init();
            base.Open(portName, processCanceled);
            try {
                while (port.IsOpen && !processCanceled()) {
                    int n = port.Read(buffer, 0, Math.Min(buffer.Length, port.BytesToRead));
                    if (n > 0) {
                        SplitData(buffer, n);
                        readBytes += n;
                        DumpData(buffer, n);
                    }
                    Thread.Sleep(10);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
        void DumpData(byte[] data, int length)
        {
            FileStream fs = new FileStream("raw.dmp", FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(data, 0, length);
            writer.Close();
            fs.Close();
        }
    }


    class PortMock: APortBase
    {
        private Mock mock = new Mock();
        bool isOpen;

        public override bool IsOpen { get { return isOpen; } }

        public override void Close() 
        {
            isOpen = false;
        }

        public override void Init()
        {
            
        }

        public override void Open(string portName, IsProcessCanceled processCanceled) 
        {
            isOpen = true;
            base.Open(portName, processCanceled);
            GenerateData();
        }
        private void GenerateData()
        {
            while (!processCanceled()) {
                int n = mock.Generate(buffer, 0, buffer.Length);
                SplitData(buffer, n);
                readBytes += n;
                Thread.Sleep(20);
            }
            Close();
        }
    }

    public class EmptyPortNameException : Exception { }
}
