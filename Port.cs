using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        /// <summary>
        /// Записать полученные данные в файл
        /// </summary>
        /// <param name="channel">номер канала</param>
        void Save(Channel channel);
        void GetData(List<double> channel1, List<double> channel2, int count);
    }
    abstract class APortBase : IPort
    {
        /// <summary>
        /// Максимальное число байт вычитываемых из порта
        /// </summary>
        public const int MAX_BYTES_TO_READ = 1024 * 1024;
        protected Object obj = new Object();
        protected IsProcessCanceled processCanceled;
        private readonly List<double> channelData1 = new List<double>();
        private readonly List<double> channelData2 = new List<double>();
        public virtual IList<double> ChannelData1 { get { return channelData1; } }
        public virtual IList<double> ChannelData2 { get { return channelData2; } }
        protected int readBytes = 0;
        protected byte[] buffer = new byte[1000];

        public event EventHandler Finished;
        public event EventHandler Read;
        public abstract bool IsOpen { get; }
        public virtual PortMode Mode { get; set; }
        public virtual PortAccuracy Accuracy { get; set; }
        public abstract void Init();
        public virtual void Open(string portName, IsProcessCanceled processCanceled)
        {
            readBytes = 0;
            this.processCanceled = processCanceled;
            channelData1.Clear();
            channelData2.Clear();
        }
        public abstract void Close();

        protected virtual void OnFinish()
        {
            Close();
            Finished?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnRead()
        {
            Read?.Invoke(this, EventArgs.Empty);
        }

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

                // Определяем канал
                UInt16 userData = buffer[offset + 1];
                userData <<= 8;
                userData |= buffer[offset];
                offset += 2;

                var channel = (userData & (1 << 1)) == (1 << 1) ? ChannelData2 : ChannelData1;

                for (int i = offset; i < length;) {
                    UInt16 data = buffer[i + 1];
                    data <<= 8;
                    data |= buffer[i];
                    i += 2;
                    if (channel.Count >= MAX_BYTES_TO_READ) {
                        channel.Clear();
                    }
                    channel.Add(ConvertWolt(data));
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
                    break;
            }
        }
        public virtual void GetData(List<double> channel1, List<double> channel2, int count)
        {
            lock (obj) {
                channel1.AddRange(ChannelData1.Skip(Math.Max(0, ChannelData1.Count - count)).Take(Math.Min(count, ChannelData1.Count)));
                channel2.AddRange(ChannelData2.Skip(Math.Max(0, ChannelData2.Count - count)).Take(Math.Min(count, ChannelData2.Count)));
            }
        }
    }

    class Port : APortBase
    {
        SerialPort port = new SerialPort();
        public Port()
        {
            //port.BaudRate = 9600;
            port.BaudRate = 480000 * 12;
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
            while (!processCanceled()) {
                int n = port.Read(buffer, 0, Math.Min(buffer.Length, port.BytesToRead));
                SplitData(buffer, n);
                readBytes += n;
                DumpData(buffer, n);
            }
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
            //OnFinish();
        }
    }

    public class EmptyPortNameException : Exception { }
}
