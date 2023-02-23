using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aksolotl
{
    enum PortMode: byte
    {
        DFM = 0b11110001,
        STD = 0b11110000
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
        void Open(string portName);
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
        /// <summary>
        /// Записать полученные данные в файл
        /// </summary>
        /// <param name="channel">номер канала</param>
        void Save(Channel channel);
    }
    abstract class APortBase : IPort
    {
        /// <summary>
        /// Максимальное число байт вычитываемых из порта
        /// </summary>
        public const int MAX_BYTES_TO_READ = 1024 * 1024;
        private readonly List<double> channelData1 = new List<double>();
        private readonly List<double> channelData2 = new List<double>();
        public virtual IList<double> ChannelData1 { get { return channelData1; } }
        public virtual IList<double> ChannelData2 { get { return channelData2; } }
        protected int readBytes = 0;
        protected byte[] buffer = new byte[4096];

        public event EventHandler Finished;
        public abstract bool IsOpen { get; }
        public virtual PortMode Mode { get; set; }
        public virtual PortAccuracy Accuracy { get; set; }
        public abstract void Init();
        public virtual void Open(string portName)
        {
            readBytes = 0;
            channelData1.Clear();
            channelData2.Clear();
        }
        public abstract void Close();

        protected virtual void OnFinish()
        {
            Close();
            Finished?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Converts data from the buffer to voltage and splits into 2 channels
        /// </summary>
        /// <param name="buffer">input buffer</param>
        /// <param name="length">buffer length</param>
        protected virtual void SplitData(byte[] buffer, int length)
        {
            for (int i = 0; i * 2 + 1 < length; i += 2) {
                UInt16 data = buffer[2 * i + 1];
                data <<= 8;
                data |= buffer[2 * i];
                if ((data & (1 << 1)) == (1 << 1)) {
                    ChannelData2.Add(ConvertWolt(data));

                }
                else {
                    ChannelData1.Add(ConvertWolt(data));
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
                writer.Write(";");
            }
        }
        public virtual void Save(Channel channel)
        {
            switch (channel) {
                case Channel.ONE:
                    SaveDataToFile("ch1.txt", ChannelData1);
                    break;
                case Channel.TWO:
                    SaveDataToFile("ch2.txt", ChannelData2);
                    break;
                default:
                    //comment схранение файла из канала
                    break;
            }
        }
    }

    class Port: APortBase
    {
        SerialPort port = new SerialPort();
        public Port()
        {
            port.BaudRate = 9600;
            port.ReadBufferSize = buffer.Length;
            port.Parity = Parity.None;
            port.Handshake = Handshake.None;
            port.StopBits = StopBits.One;
            port.DtrEnable = false;
            port.RtsEnable = false;
            //port.DataReceived += Port_DataReceived;
        }
        public override bool IsOpen { get { return port.IsOpen; } }
        public override void Init()
        {
            buffer[0] = (byte)Mode;
            port.Write(buffer, 0, 1);
            Thread.Sleep(100);
            buffer[0] = (byte)Accuracy;
            port.Write(buffer, 0, 1);
            Thread.Sleep(100);
        }

        public override void Close()
        {
            port.Close();
        }

        /// <summary>
        /// Initiate and open port
        /// </summary>
        /// <param name="portName">port name</param>
        public override void Open(string portName)
        {
            if (String.IsNullOrWhiteSpace(portName)) {
                throw new EmptyPortNameException();
            }
            port.PortName = portName;
            port.Open();
            // Устанавливаем режим работы std/dfm
            Init();
            base.Open(portName);
            while (readBytes < 100) {
                int n = port.Read(buffer, 0, Math.Min(buffer.Length, port.BytesToRead));
                SplitData(buffer, n);
                readBytes += n;
                DumpData(buffer, n);
            }
            OnFinish();
        }
        void DumpData(byte[] data, int length)
        {
            FileStream fs = new FileStream("raw.dmp", FileMode.Append);
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(data, 0, length);
            writer.Close();
            fs.Close();
        }
        /// <summary>
        /// Событие для получения данных из порта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n = port.Read(buffer, 0, Math.Min(buffer.Length, port.BytesToRead));
            SplitData(buffer, n);
            readBytes += n;
            DumpData(buffer, n);
            //if (readBytes >= MAX_BYTES_TO_READ) {
                OnFinish();
            //}
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

        public override void Open(string portName) 
        {
            isOpen = true;
            base.Open(portName);
            GenerateData();
        }
        private void GenerateData()
        {
            while (readBytes <= MAX_BYTES_TO_READ) {
                int n = mock.Generate(buffer, 0, buffer.Length);
                SplitData(buffer, n);
                readBytes += n;
            }
            OnFinish();
        }
    }

    public class EmptyPortNameException : Exception { }
}
