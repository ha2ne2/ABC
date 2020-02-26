using System;

namespace Scratch
{
    public class Program
    {
        public static void Main()
        {
            long x, y;
            var gcd = ExtGcd(11, 7, out x, out y);

        }

        /// <summary>
        /// 拡張ユークリッド互除法
        /// ax+by=gcd(a,b)を満たすx,yを引数に格納する。
        /// 戻り値はgcd(a,b)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static long ExtGcd(long a, long b, out long x, out long y)
        {
            x = 1;
            y = 0;
            long u = 0;
            long v = 1;

            while (b != 0)
            {
                long k = a / b;
                long _x = u;
                u = x - k * u;
                x = _x;
                long _y = v;
                v = y - k * v;
                y = _y;

                long _a = a;
                a = b;
                b = _a - (k * b);
            }

            return a;
        }
    }
}
