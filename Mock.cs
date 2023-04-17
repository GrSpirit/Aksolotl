using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aksolotl
{
    class Mock
    {
        double x1 = 0;
        double x2 = 0;
        delegate double Simulator();

        double Channel1()
        {
            x1 += Math.PI / 50;
            return Math.Cos(x1) + 1;
        }
        double Channel2()
        {
            x2 += Math.PI / 25;
            return Math.Sin(x2) / 2 + 1;
        }

        int MakeData(byte[] data8, int offset, int count, int chan)
        {
            int i = 0;
            int n = count / 2;
            if (n == 0) { return 0; }
            UInt16[] data16 = new ushort[n];
            data16[i++] = 0xDEAD;
            data16[i++] = (ushort)((chan == 0) ? 0b0101 : 0b0111);
            for (; i < n; i++) {
                data16[i] = Pack(chan == 0 ? Channel1() : Channel2());
            }

            Buffer.BlockCopy(data16, 0, data8, offset, count);
            return count;
        }
        public int Generate(byte[] data, int offset, int size)
        {
            int n = MakeData(data, offset, size / 2, 0);
            n += MakeData(data, offset + size / 2, size - size / 2, 1);

            return n;
            
        }
        private UInt16 Pack(double x)
        {
            return (UInt16)(x * 4096 / 3.3);
        }
    }
}
