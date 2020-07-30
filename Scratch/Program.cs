using System;
using System.Collections.Generic;
using System.Linq;

namespace Scratch
{
    public class Lengths
    {
        public static void Main(string[] args)
        {
            var lst = new List<int> { 1, 2, 3 };
            Console.WriteLine(Length(lst));
            Console.WriteLine(Length2(lst));
            Console.WriteLine(Length3(lst));
        }

        public static long Length<T>(IEnumerable<T> list)
        {
            return !list.Any() ? 0 : 1 + Length(list.Skip(1));
        }

        public static long Length2<T>(IEnumerable<T> list)
            => Length2Inner(list, 0);

        public static long Length2Inner<T>(IEnumerable<T> list, long acc)
        {
            return !list.Any() ? acc : Length2Inner(list.Skip(1), acc + 1);
        }

        public static long Length3<T>(IEnumerable<T> list)
            => Length3Inner(list, (n) => n);
        public static long Length3Inner<T>(IEnumerable<T> list, Func<long,long> cont)
        {
            return !list.Any() ? cont(0) : Length3Inner(list.Skip(1), (n) => cont(n + 1));
        }

    }


    public struct Mint
    {
        public static long MOD = (long)1e9+7;

        /// <summary>
        /// 0以上MOD未満の整数
        /// </summary>
        public long Value;

        public Mint(long val)
        {
            Value = val % MOD;
            if (Value < 0) Value += MOD;
        }

        private static Mint Ctor(long val)
        {
            return new Mint() { Value = val };
        }

        public static Mint operator+(Mint a, Mint b)
        {
            long res = a.Value + b.Value;
            if (res > MOD) res -= MOD;
            return Ctor(res);
        }
        public static Mint operator-(Mint a, Mint b)
        {
            long res = a.Value - b.Value;
            if (res < 0) res += MOD;
            return Ctor(res);
        }

        public static Mint operator*(Mint a, Mint b)
        {
            long res = a.Value * b.Value;
            if (res > MOD) res %= MOD;
            return Ctor(res);
        }

        public static Mint operator/(Mint a, Mint b)
        {
            return a * Inv(b);
        }

        public static Mint Pow(Mint a, long n)
        {
            if (n == 0) return new Mint(1);
            Mint b = Pow(a, n >> 1);
            b *= b;
            if ((n & 1) == 1) b *= a;
            return b;
        }

        public static Mint Inv(Mint n)
        {
            long a = n.Value;
            long b = MOD;

            long x = 1;
            long u = 0;
            while (b != 0)
            {
                long k = a / b;
                long _x = u;
                u = x - k * u;
                x = _x;

                long _a = a;
                a = b;
                b = _a - (k * b);
            }

            return new Mint(x);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static explicit operator Mint(long a) { return new Mint(a); }
        public static explicit operator long(Mint a) { return a.Value; }
    }

    public class Program
    {
        public static void _Main()
        {
            Mint a = new Mint(7);
            Mint b = new Mint(6);
            Console.WriteLine($"{a}+{b}:" + (a + b).Value);
            Console.WriteLine($"{b}-{a}:" + (b - a).Value);
            Console.WriteLine($"{a}*{b}:" + (a * b).Value);
            Console.WriteLine($"{a}/{b}:" + (a / b).Value);
            Console.WriteLine($"Pow(2,10):" + Mint.Pow((Mint)2,10));

            long x, y;
            var gcd = ExtGcd(11, 7, out x, out y);

        }

        /// <summary>
        /// 拡張ユークリッド互除法
        /// ax+by=gcd(a,b)を満たすx,yを引数に格納する。
        /// 戻り値はgcd(a,b)。
        /// 行列演算による実装
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

        public static long modinv(long a, long mod)
        {
            long b = mod;

            long x = 1;
            long u = 0;
            while (b != 0)
            {
                long k = a / b;
                long _x = u;
                u = x - k * u;
                x = _x;

                long _a = a;
                a = b;
                b = _a - (k * b);
            }
            x %= mod;
            if (x < 0) x += mod;

            return x;
        }
    }
}
