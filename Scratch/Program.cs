using System;
using System.Collections.Generic;

namespace Scratch
{
    public class Program
    {
        public static void _Main()
        {

            var lst = PrimeFactorize(3);
            foreach(var key in lst.Keys)
            {
                Console.WriteLine("{0} {1}", key, lst[key]);
            }
            //Console.WriteLine();
     
            // output
            // 0 1 2 3
            // 0 1 3 2
            // 0 2 1 3
            // 0 2 3 1
            // 0 3 1 2
            // 0 3 2 1
            // 1 0 2 3
            // ...
        }

        public static Dictionary<long,long> PrimeFactorize(long n)
        {
            Dictionary<long, long> dic = new Dictionary<long, long>();

            if (n % 2 == 0)
            {
                n /= 2;
                dic[2] = 1;
                while (n % 2 == 0)
                {
                    n /= 2;
                    dic[2]++;
                }
            }

            for (long i = 3; i * i <= n; i+=2)
            {
                if (n % i == 0)
                {
                    n /= i;
                    dic[i] = 1;
                    while (n % i == 0)
                    {
                        n /= i;
                        dic[i]++;
                    }
                }
            }

            if (n != 1)
                dic[n] = 1;

            return dic;
        }

        public static List<long> GetPrimes(long n)
        {
            List<long> primes = new List<long>();

            if (n % 2 == 0)
            {
                primes.Add(2);
                while (n % 2 == 0) n /= 2;
            }

            for (long i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0)
                {
                    primes.Add(i);
                    while (n % i == 0) n /= i;
                }
            }
            if (n != 1)
                primes.Add(n);

            return primes;
        }
        public static void NextPermutation(int[] array)
        {
            // a[left] < a[left+1] を満たす最大のleftを探す
            int left = array.Length - 2;
            while (array[left] > array[left + 1])
            {
                left--;
                if (left < 0) return;
            }

            // a[left] < a[right] を満たす最大のrightを探す
            int leftVal = array[left];
            int right = array.Length - 1;
            while (leftVal > array[right])
            {
                right--;
            }

            // 入れ替える
            Swap(ref array[left], ref array[right]);

            // 後ろを全部入れ替える。入れ替え後は a[left] > a[left+1] < a[left+2] < ... < a[length-1] という不等式が成り立つ。
            left++;
            right = array.Length - 1;
            while (left < right)
            {
                Swap(ref array[left], ref array[right]);
                left++;
                right--;
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
    }
}



//    public static class Cin
//    {
//        #region public

//        public static long rl { get { return ReadLong(); } }
//        public static long[] rla { get { return ReadLongArray(); } }
//        public static double rd { get { return ReadDouble(); } }
//        public static double[] rda { get { return ReadDoubleArray(); } }
//        public static string rs { get { return ReadString(); } }

//        public static int ReadInt()
//        {
//            return int.Parse(Next());
//        }

//        public static long ReadLong()
//        {
//            return long.Parse(Next());
//        }

//        public static double ReadDouble()
//        {
//            return double.Parse(Next());
//        }

//        public static string ReadString()
//        {
//            return Next();
//        }

//        public static int[] ReadIntArray()
//        {
//            Tokens = null;
//            return Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
//        }

//        public static long[] ReadLongArray()
//        {
//            Tokens = null;
//            return Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
//        }

//        public static double[] ReadDoubleArray()
//        {
//            Tokens = null;
//            return Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
//        }

//        public static void ReadCols(out long[] a, out long[] b, long N)
//        {
//            a = new long[N];
//            b = new long[N];
//            for (int i = 0; i < N; i++)
//            {
//                a[i] = ReadLong();
//                b[i] = ReadLong();
//            }
//        }

//        public static void ReadCols(out long[] a, out long[] b, out long[] c, long N)
//        {
//            a = new long[N];
//            b = new long[N];
//            c = new long[N];
//            for (int i = 0; i < N; i++)
//            {
//                a[i] = ReadLong();
//                b[i] = ReadLong();
//                c[i] = ReadLong();
//            }
//        }

//        public static int[][] ReadIntTable(int n)
//        {
//            Tokens = null;
//            int[][] ret = new int[n][];
//            for (int i = 0; i < n; i++)
//            {
//                ret[i] = ReadIntArray();
//            }

//            return ret;
//        }

//        public static long[][] ReadLongTable(long n)
//        {
//            Tokens = null;
//            long[][] ret = new long[n][];
//            for (long i = 0; i < n; i++)
//            {
//                ret[i] = ReadLongArray();
//            }

//            return ret;
//        }

//        #endregion

//        #region private

//        private static string[] Tokens { get; set; }

//        private static int Pointer { get; set; }

//        private static string Next()
//        {
//            if (Tokens == null || Tokens.Length <= Pointer)
//            {
//                Tokens = Console.ReadLine().Split(' ');
//                Pointer = 0;
//            }

//            return Tokens[Pointer++];
//        }

//        #endregion

//    }

//    /// <summary>
//    /// ユーティリティー
//    /// </summary>
//    public static class Util
//    {
//        // 10^17
//        public static readonly long INF = (long)1e17;

//        // 10^9 + 7
//        public readonly static long MOD = (long)1e9 + 7;

//        /// <summary>
//        /// Console.WriteLineの自動フラッシュをしないようにする
//        /// </summary>
//        public static void DontAutoFlush()
//        {
//            var sw = new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
//            Console.SetOut(sw);
//        }

//        public static void Flush()
//        {
//            Console.Out.Flush();
//        }

//        /// <summary>
//        /// ソートをして結果を返します。
//        /// 破壊的関数です。
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="array"></param>
//        /// <returns></returns>
//        public static T[] Sort<T>(T[] array)
//        {
//            Array.Sort<T>(array);
//            return array;
//        }

//        /// <summary>
//        /// 降順ソートをして結果を返します。
//        /// 破壊的関数です。
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="array"></param>
//        /// <returns></returns>
//        public static T[] SortDecend<T>(T[] array)
//        {
//            Array.Sort<T>(array);
//            Array.Reverse(array);
//            return array;
//        }

//        /// <summary>
//        /// 引数aと引数bの値を入れ替えます
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="a"></param>
//        /// <param name="b"></param>
//        public static void Swap<T>(ref T a, ref T b)
//        {
//            T _a = a;
//            a = b;
//            b = _a;
//        }

//        public static int GCD(int a, int b)
//        {
//            return (b == 0) ? a : GCD(b, a % b);
//        }

//        public static void ChMax(ref long a, long b)
//        {
//            if (a < b) a = b;
//        }

//        public static void ChMin(ref long a, long b)
//        {
//            if (a > b) a = b;
//        }

//        public static long ModAdd(long a, long b)
//        {
//            long res = a + b;
//            if (res >= MOD)
//                return res % MOD;
//            return res;
//        }

//        public static long ModMul(long a, long b)
//        {
//            long res = a * b;
//            if (res >= MOD)
//                return res % MOD;
//            return res;
//        }

//        public static void ChModAdd(ref long a, long b)
//        {
//            a += b;
//            if (a >= MOD)
//                a %= MOD;
//        }

//        public static void ChModMul(ref long a, long b)
//        {
//            a *= b;
//            if (a >= MOD)
//                a %= MOD;
//        }

//        public static void FillArray<T>(T[] array, T value)
//        {
//            int max = array.Length;
//            for (int i = 0; i < max; i++)
//            {
//                array[i] = value;
//            }
//        }

//        public static void FillArray<T>(T[,] array, T value)
//        {
//            int max0 = array.GetLength(0);
//            int max1 = array.GetLength(1);

//            for (int i = 0; i < max0; i++)
//            {
//                for (int j = 0; j < max1; j++)
//                {
//                    array[i, j] = value;
//                }
//            }
//        }

//        public static void FillArray<T>(T[,,] array, T value)
//        {
//            int max0 = array.GetLength(0);
//            int max1 = array.GetLength(1);
//            int max2 = array.GetLength(2);

//            for (int i = 0; i < max0; i++)
//            {
//                for (int j = 0; j < max1; j++)
//                {
//                    for (int k = 0; k < max2; k++)
//                    {
//                        array[i, j, k] = value;
//                    }
//                }
//            }
//        }

//        /// <summary>
//        /// 累積和を求めて返します。
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="array"></param>
//        /// <returns></returns>
//        public static long[] Accumulate(long[] array)
//        {
//            long[] acc = new long[array.Length + 1];
//            for (int i = 0; i < array.Length; i++)
//            {
//                acc[i + 1] = acc[i] + array[i];
//            }
//            return acc;
//        }

//        public static double[] Accumulate(double[] array)
//        {
//            double[] acc = new double[array.Length + 1];
//            for (int i = 0; i < array.Length; i++)
//            {
//                acc[i + 1] = acc[i] + array[i];
//            }
//            return acc;
//        }
//    }

//    public class HashMap<K, V> : Dictionary<K, V>
//    {
//        private V DefaultValue;
//        private static Func<V> CreateInstance =
//            System.Linq.Expressions.Expression.Lambda<Func<V>>(System.Linq.Expressions.Expression.New(typeof(V))).Compile();

//        public HashMap() { }
//        public HashMap(V defaultValue)
//        {
//            DefaultValue = defaultValue;
//        }
//        new public V this[K i]
//        {
//            get
//            {
//                V v;
//                if (TryGetValue(i, out v))
//                {
//                    return v;
//                }
//                else
//                {
//                    return base[i] = DefaultValue != null ? DefaultValue : CreateInstance();
//                }
//            }
//            set { base[i] = value; }
//        }
//    }
//}
