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
/// https://atcoder.jp/contests/abc137
/// 2020/02/12 
/// </summary>
namespace ABC137
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // A(); 3m
            // B(); 10m
            // C(); 29m
            D();
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
            long N = rl;
            long M = rl;
            HashMap<long, List<long>> hm = new HashMap<long, List<long>>();
            for (int i = 0; i < N; i++)
            {
                long a = rl;
                long b = rl;
                hm[a].Add(b);
            }

            PriorityQueue<long> pq = new PriorityQueue<long>(PriorityQueue<long>.Order.Descend);
            long ans = 0;
            for (int i = 1; i <= M; i++)
            {
                foreach(var money in hm[i])
                {
                    pq.Enqueue(money);
                }

                if(pq.Any())
                    ans += pq.Dequeue();
            }

            Console.WriteLine(ans);
        }

        public static void C()
        {
            long N = rl;
            string[] s = new string[N];
            for (int i = 0; i < N; i++)
            {
                s[i] = rs;
            }

            HashMap<string, long> hm = new HashMap<string,long>();
            foreach(var str in s)
            {
                hm[new string(str.OrderBy(c => c).ToArray())]++;
            }

            long ans = 0;
            foreach(var val in hm.Values)
            {
                ans += val * (val - 1) / 2;
            }

            Console.WriteLine(ans);

        }

        public static void B()
        {
            long K = rl;
            long X = rl;

            StringBuilder sb = new StringBuilder();                        
            for (int i = (int)(X-K+1); i <= X+K-1; i++)
            {
                sb.Append(i + " ");
            }

            Console.WriteLine(sb.ToString());
        }

        public static void A()
        {
            long A = rl;
            long B = rl;

            long plus = A + B;
            long minus = A - B;
            long mul = A * B;

            Console.WriteLine(Max(Max(plus, minus), mul));
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

        public static IEnumerable<int> Range(int end)
        {
            for (int i = 0; i < end; i++)
            {
                yield return i;
            }
        }

        public static IEnumerable<int> Range(int from, int end)
        {
            for (int i = from; i < end; i++)
            {
                yield return i;
            }
        }

        public static IEnumerable<int> Range(int from, int end, int step)
        {
            for (int i = from; i < end; i += step)
            {
                yield return i;
            }
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

        /// <summary>
        /// 先頭と末尾に要素を増やした新しい配列を返します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] AddHeadAndTail<T>(T[] array)
        {
            int len = array.Length;
            T[] res = new T[len + 2];
            Array.Copy(array, 0, res, 1, len);
            return res;
        }

        /// <summary>
        /// 昇順ソート済みの配列を2分探索します。
        /// 要素が見つからなかった場合はnより大きい数値の中で最小の数値のインデックスを返す。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int BinarySearch(long[] array, long n)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (right - left) / 2 + left;

                if (array[mid] == n)
                {
                    return mid;
                }
                else if (n < array[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }

        public static int GCD(int a, int b)
        {
            return (b == 0) ? a : GCD(b, a % b);
        }

        /// <summary>
        /// nの約数の配列を返します。
        /// 配列は昇順ソートされています。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] GetDivisor(int n)
        {
            double sqrt = Math.Sqrt(n);

            List<int> divisor = new List<int>();

            for (int i = 1; i <= sqrt; i++)
            {
                if (n % i == 0)
                {
                    divisor.Add(i);
                    int d = n / i;
                    if (d != i)
                    {
                        divisor.Add(d);
                    }
                }
            }

            return Sort(divisor.ToArray());
        }

        public static void Deconstruct<T>(this T[] items, out T t0)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1)
        {
            if (items.Length < 2)
                throw new ArgumentException();

            t0 = items[0];
            t1 = items[1];
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2)
        {
            if (items.Length < 3)
                throw new ArgumentException();

            t0 = items[0];
            t1 = items[1];
            t2 = items[2];
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2, out T t3)
        {
            if (items.Length < 4)
                throw new ArgumentException();

            t0 = items[0];
            t1 = items[1];
            t2 = items[2];
            t3 = items[3];
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

        public static T MinBy<T>(this IEnumerable<T> source, Func<T, long> conv)
        {
            T min = source.First();
            long minValue = long.MaxValue;
            foreach (T x in source)
            {
                long n = conv(x);
                if (n < minValue)
                {
                    min = x;
                }
            }

            return min;
        }

        public static T MaxBy<T>(this IEnumerable<T> source, Func<T, long> conv)
        {
            T min = source.First();
            long maxValue = long.MinValue;
            foreach (T x in source)
            {
                long n = conv(x);
                if (maxValue < n)
                {
                    min = x;
                }
            }

            return min;
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
                    if (DefaultValue == null)
                    {
                        base[i] = CreateInstance();
                    }
                    else
                    {
                        base[i] = DefaultValue;
                    }

                    return base[i];
                }
            }
            set { base[i] = value; }
        }
    }

    public class PriorityQueue<T>
    {
        public enum Order
        {
            Ascend,
            Descend
        }

        private readonly List<T> Heap;
        private readonly Comparison<T> Compare;
        private int Size;

        public PriorityQueue() : this(Comparer<T>.Default.Compare) { }
        public PriorityQueue(Comparison<T> comparison)
        {
            Heap = new List<T>();
            Compare = comparison;
        }

        public PriorityQueue(Order order)
        {
            Heap = new List<T>();
            Comparison<T> defaultCompare = Comparer<T>.Default.Compare;
            if (order == Order.Descend)
            {
                Compare = (x, y) => defaultCompare(x, y) * -1;
            }
            else
            {
                Compare = defaultCompare;
            }
        }

        public void Enqueue(T item)
        {
            Heap.Add(default(T));
            int i = Size;
            Size++;
            while (i > 0)
            {
                int p = (i - 1) >> 1;
                if (Compare(Heap[p], item) <= 0)
                    break;
                Heap[i] = Heap[p];
                i = p;
            }
            Heap[i] = item;
        }

        public T Dequeue()
        {
            T ret = Heap[0];
            Size--;
            T x = Heap[Size];
            Heap[Size] = default(T);
            int i = 0;
            while ((i << 1) + 1 < Size)
            {
                int l = (i << 1) + 1;
                int r = l + 1;

                if (r < Size && Compare(Heap[r], Heap[l]) < 0)
                    l = r;

                if (Compare(x, Heap[l]) <= 0)
                    break;

                Heap[i] = Heap[l];
                i = l;
            }
            Heap[i] = x;
            return ret;
        }

        public T Peek() { return Heap[0]; }
        public int Count { get { return Size; } }
        public bool Any() { return Size > 0; }
        public bool IsEmpty() { return Size == 0; }
    }
}
