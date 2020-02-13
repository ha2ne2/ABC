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
using System.Linq.Expressions;

/// <summary>
/// https://atcoder.jp/contests/abc138
///
/// </summary>
namespace ABC138
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // A();
            // B();
            // C();
            // D();
            // E();
            // F();
        }

        public static void F()
        {

        }

        public static void E()
        {

        }

        public static void D()
        {

        }

        public static void C()
        {

        }

        public static void B()
        {

        }

        public static void A()
        {

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

        public static string Next()
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

        /// <summary>
        /// めぐる式二分探索
        /// okにはpredを満たすindexを、ngにはpredを満たさないindexを指定します。
        /// 引数がng＜okの場合、最小のokとなるindexをokに代入します。(lower_bound）
        /// 引数がok＜ngの場合、最大のokとなるindexをokに代入します。(upper_bound）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="okIndex"></param>
        /// <param name="ngIndex"></param>
        /// <param name="pred"></param>
        public static void MeguruBinarySearch<T>(
            T[] array,
            ref long okIndex,
            ref long ngIndex,
            Predicate<T> pred)
        {
            while (Math.Abs(okIndex - ngIndex) > 1)
            {
                long mid = (okIndex + ngIndex) / 2;
                if (pred(array[mid]))
                {
                    okIndex = mid;
                }
                else
                {
                    ngIndex = mid;
                }
            }
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
