using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ha2ne2Util.Cin;
using static Ha2ne2Util.Util;
using static System.Console;
using static System.Math;
using System.Collections;
using Pair = System.Tuple<long, long>;
using Ha2ne2Util;
using System.Linq.Expressions;

/// <summary>
/// 色々テスト用
/// 
/// </summary>
namespace Scratch
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    ABC105_A();
        //}

        public static void ABC105_A()
        {
            long Senbei = ReadLong();
            long Ninzu = ReadLong();

            long amari = Senbei % Ninzu;

            if (amari == 0)
            {                
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine("1");
            }
        }

        public static void ABC106_A()
        {
            long A = ReadLong();
            long B = ReadLong();

            long C = A + B;
            if (C <= 10)
            {
                Console.WriteLine("Cは10以下です");
            }
            else
            {
                Console.WriteLine("Cは10以下じゃないです");
            }
        }

        public static void AGC036_A()
        {
            long S = rl;
            long v = (long)1e9;
            long x = (v - S % v) % v;
            long y = (S + x) / v;
            string ans = "0 0 1000000000 1 " + x + " " + y;
            Console.WriteLine(ans);
        }

        public static void MeguruBinarySearchSample()
        {
            int[] A = new int[] { 1, 2, 3, 4, 4, 5, 6, 7 };
            Predicate<int> pred = (x) =>
            {
                return x <= 4;
            };

            long okIndex = -1;
            long ngIndex = A.Length;

            //MeguruBinarySearch(A, ref okIndex, ref ngIndex, pred);
            Console.WriteLine("{0} {1}", okIndex, ngIndex);
        }
    }
}



namespace Ha2ne2Util
{
    public static class Cin
    {
        #region public

        public static long rl => ReadLong();
        public static long[] rla => ReadLongArray();
        public static double rd => ReadDouble();
        public static double[] rda => ReadDoubleArray();
        public static string rs => ReadString();

        public static int ReadInt()
        {
            return int.Parse(Next());
        }

        public static long ReadLong()
        {
            return long.Parse(Next());
        }

        public static double ReadDouble()
        {
            return double.Parse(Next());
        }

        public static string ReadString()
        {
            return Next();
        }

        public static int[] ReadIntArray()
        {
            Tokens = null;
            return Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        }

        public static long[] ReadLongArray()
        {
            Tokens = null;
            return Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
        }

        public static double[] ReadDoubleArray()
        {
            Tokens = null;
            return Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
        }

        public static void ReadCols(out long[] a, out long[] b, long N)
        {
            a = new long[N];
            b = new long[N];
            for (int i = 0; i < N; i++)
            {
                a[i] = ReadLong();
                b[i] = ReadLong();
            }
        }

        public static void ReadCols(out long[] a, out long[] b, out long[] c, long N)
        {
            a = new long[N];
            b = new long[N];
            c = new long[N];
            for (int i = 0; i < N; i++)
            {
                a[i] = ReadLong();
                b[i] = ReadLong();
                c[i] = ReadLong();
            }
        }

        public static int[][] ReadIntTable(int n)
        {
            Tokens = null;
            int[][] ret = new int[n][];
            for (int i = 0; i < n; i++)
            {
                ret[i] = ReadIntArray();
            }

            return ret;
        }

        public static long[][] ReadLongTable(long n)
        {
            Tokens = null;
            long[][] ret = new long[n][];
            for (long i = 0; i < n; i++)
            {
                ret[i] = ReadLongArray();
            }

            return ret;
        }

        #endregion

        #region private

        private static string[] Tokens { get; set; }

        private static int Pointer { get; set; }

        private static string Next()
        {
            if (Tokens == null || Tokens.Length <= Pointer)
            {
                Tokens = Console.ReadLine().Split(' ');
                Pointer = 0;
            }

            return Tokens[Pointer++];
        }

        #endregion

    }

    /// <summary>
    /// ユーティリティー
    /// </summary>
    public static class Util
    {
        // 10^17
        public static readonly long INF = (long)1e17;

        // 10^9 + 7
        public readonly static long MOD = (long)1e9 + 7;

        /// <summary>
        /// Console.WriteLineの自動フラッシュをしないようにする
        /// </summary>
        public static void DontAutoFlush()
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
        }

        public static void Flush()
        {
            Console.Out.Flush();
        }

        /// <summary>
        /// ソートをして結果を返します。
        /// 破壊的関数です。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] Sort<T>(T[] array)
        {
            Array.Sort<T>(array);
            return array;
        }

        /// <summary>
        /// 降順ソートをして結果を返します。
        /// 破壊的関数です。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] SortDecend<T>(T[] array)
        {
            Array.Sort<T>(array);
            Array.Reverse(array);
            return array;
        }

        /// <summary>
        /// 引数aと引数bの値を入れ替えます
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap<T>(ref T a, ref T b)
        {
            T _a = a;
            a = b;
            b = _a;
        }

        public static int GCD(int a, int b)
        {
            return (b == 0) ? a : GCD(b, a % b);
        }

        public static void ChMax(ref long a, long b)
        {
            if (a < b) a = b;
        }

        public static void ChMin(ref long a, long b)
        {
            if (a > b) a = b;
        }

        public static long ModAdd(long a, long b)
        {
            long res = a + b;
            if (res >= MOD)
                return res % MOD;
            return res;
        }

        public static long ModMul(long a, long b)
        {
            long res = a * b;
            if (res >= MOD)
                return res % MOD;
            return res;
        }

        public static void ChModAdd(ref long a, long b)
        {
            a += b;
            if (a >= MOD)
                a %= MOD;
        }

        public static void ChModMul(ref long a, long b)
        {
            a *= b;
            if (a >= MOD)
                a %= MOD;
        }

        public static void FillArray<T>(T[] array, T value)
        {
            int max = array.Length;
            for (int i = 0; i < max; i++)
            {
                array[i] = value;
            }
        }

        public static void FillArray<T>(T[,] array, T value)
        {
            int max0 = array.GetLength(0);
            int max1 = array.GetLength(1);

            for (int i = 0; i < max0; i++)
            {
                for (int j = 0; j < max1; j++)
                {
                    array[i, j] = value;
                }
            }
        }

        public static void FillArray<T>(T[,,] array, T value)
        {
            int max0 = array.GetLength(0);
            int max1 = array.GetLength(1);
            int max2 = array.GetLength(2);

            for (int i = 0; i < max0; i++)
            {
                for (int j = 0; j < max1; j++)
                {
                    for (int k = 0; k < max2; k++)
                    {
                        array[i, j, k] = value;
                    }
                }
            }
        }

        /// <summary>
        /// 累積和を求めて返します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static long[] Accumulate(long[] array)
        {
            long[] acc = new long[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                acc[i + 1] = acc[i] + array[i];
            }
            return acc;
        }

        public static double[] Accumulate(double[] array)
        {
            double[] acc = new double[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                acc[i + 1] = acc[i] + array[i];
            }
            return acc;
        }
    }

    public class HashMap<K, V> : Dictionary<K, V>
    {
        private V DefaultValue;
        private static Func<V> CreateInstance =
            Expression.Lambda<Func<V>>(Expression.New(typeof(V))).Compile();

        public HashMap() { }
        public HashMap(V defaultValue)
        {
            DefaultValue = defaultValue;
        }
        new public V this[K i]
        {
            get
            {
                V v;
                if (TryGetValue(i, out v))
                {
                    return v;
                }
                else
                {
                    return base[i] = DefaultValue != null ? DefaultValue : CreateInstance();
                }
            }
            set { base[i] = value; }
        }
    }
}
