using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aksolotl
{
    class Mock
    {
        double x1 = 0;
        double x2 = 0;
        Random r = new Random();
        public int Generate(byte[] data, int offset, int size)
        {
            for (int i = offset; i * 2 < size; i += 2) {
                byte chan = (byte)(r.Next(0, 2) << 1);
                UInt16 d = 0;
                if (chan == 0) {
                    double y = Math.Cos(x1) + 1;
                    d = this.Pack(y, chan);
                    x1 += Math.PI / 50;
                }
                else {
                    double y = Math.Abs(Math.Sin(x2) * 2);
                    d = this.Pack(y, chan);
                    x2 += Math.PI / 100;
                }
                
                data[2 * i] = (byte)(d >> 8);
                data[2 * i + 1] = (byte)(d);
            }
            return size - offset;
            
        }
        private UInt16 Pack(double x, byte chan)
        {
            UInt16 d = (UInt16)(x * 4096 / 3.3);
            d <<= 4;
            d |= (byte)(chan | 0xD);
            return d;
        }
    }
}
