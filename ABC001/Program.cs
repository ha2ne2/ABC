﻿using System;
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

namespace ABC001
{
    class Program
    {

        static void Main(string[] args)
        {
        START:
            //A(); // 2m
            //B(); // 12m (10m)
            //C(); // 61m (49m)
            D(); // 103m (42m)

#if DEBUG
            goto START;
#endif
        }

        private class RainRange
        {
            public int From { get; set; }
            public int To { get; set; }

            public RainRange(int from, int to)
            {
                From = from;
                To = to;
            }
        }

        private static void D()
        {
            int N = ReadInt();
            List<RainRange> rainRangeList = new List<RainRange>();

            for (int i = 0; i < N; i++)
            {
                string s = ReadString();
                var ss = s.Split('-');

                int from = int.Parse(ss[0]);
                {
                    int amari = from % 5;
                    if (amari != 0)
                        from -= amari;
                }

                int to = int.Parse(ss[1]);
                {
                    int amari = to % 5;
                    if (amari != 0)
                        to = to - amari + 5;

                    // hourの桁上り対策
                    int hour = to % 100;
                    if (60 <= hour)
                        to += 40;
                }

                rainRangeList.Add(new RainRange(from, to));
            }

            List<RainRange> resultList = new List<RainRange>();
            var sortedRangeList = rainRangeList.OrderBy(m => m.From);
            var first = sortedRangeList.First();
            var currentRange = new RainRange(first.From, first.To);

            foreach (var range in sortedRangeList.Skip(1))
            {
                if (currentRange.To < range.From)
                {
                    resultList.Add(currentRange);
                    currentRange = new RainRange(
                        range.From,
                        range.To
                        );
                }

                else
                {
                    if (currentRange.To < range.To)
                        currentRange.To = range.To;
                }
            }
            resultList.Add(currentRange);

            foreach(var range in resultList)
            {
                WriteLine("{0}-{1}",
                    range.From.ToString().PadLeft(4,'0'),
                    range.To.ToString().PadLeft(4,'0'));
            }
        }

        private static void C()
        {
            decimal dir = ReadInt();
            decimal w = ReadInt();

            dir /= 10m;
            w = Math.Round(w / 60, 1);

            string ansDir = string.Empty;
            int ansW = 0;

            if (11.25m <= dir && dir < 33.75m) { ansDir = "NNE"; }
            else if (dir < 56.25m) { ansDir = "NE"; }
            else if (dir < 78.75m) { ansDir = "ENE"; }
            else if (dir < 101.25m) { ansDir = "E"; }
            else if (dir < 123.75m) { ansDir = "ESE"; }
            else if (dir < 146.25m) { ansDir = "SE"; }
            else if (dir < 168.75m) { ansDir = "SSE"; }
            else if (dir < 191.25m) { ansDir = "S"; }
            else if (dir < 213.75m) { ansDir = "SSW"; }
            else if (dir < 236.25m) { ansDir = "SW"; }
            else if (dir < 258.75m) { ansDir = "WSW"; }
            else if (dir < 281.25m) { ansDir = "W"; }
            else if (dir < 303.75m) { ansDir = "WNW"; }
            else if (dir < 326.25m) { ansDir = "NW"; }
            else if (dir < 348.75m) { ansDir = "NNW"; }
            else { ansDir = "N"; }

            if (0.0m <= w && w <= 0.2m) { ansW = 0; }
            else if (w <= 1.5m) { ansW = 1; }
            else if (w <= 3.3m) { ansW = 2; }
            else if (w <= 5.4m) { ansW = 3; }
            else if (w <= 7.9m) { ansW = 4; }
            else if (w <= 10.7m) { ansW = 5; }
            else if (w <= 13.8m) { ansW = 6; }
            else if (w <= 17.1m) { ansW = 7; }
            else if (w <= 20.7m) { ansW = 8; }
            else if (w <= 24.4m) { ansW = 9; }
            else if (w <= 28.4m) { ansW = 10; }
            else if (w <= 32.6m) { ansW = 11; }
            else { ansW = 12; }

            if ( ansW == 0)
            {
                WriteLine(string.Format("{0} {1}", "C", ansW));
            }
            else
            {
                WriteLine(string.Format("{0} {1}", ansDir, ansW));
            }
        }

        private static void B()
        {
            int m = ReadInt();
            decimal km = m / 1000m;

            if (m < 100)
            {
                WriteLine("00");
            }
            else if (m <= 5000)
            {
                km *= 10;
                WriteLine(((int)km).ToString().PadLeft(2, '0'));
            }
            else if (m <= 30000)
            {
                WriteLine((km + 50).ToString());
            }
            else if (m <= 70000)
            {
                WriteLine((km - 30) / 5 + 80);
            } else
            {
                WriteLine(89);
            }
        }

        private static void A()
        {
            int H1 = ReadInt();
            int H2 = ReadInt();

            WriteLine(H1 - H2);
        }
    }
}

namespace Ha2ne2Util
{
    public static class Cin
    {
        static string[] Tokens { get; set; }

        static int Ptr { get; set; }

        public static string Next()
        {
            if (Tokens == null || Tokens.Length <= Ptr)
            {
                Tokens = Console.ReadLine().Split(' ');
                Ptr = 0;
            }

            return Tokens[Ptr++];
        }

        public static int ReadInt()
        {
            return int.Parse(Next());
        }

        public static long ReadLong()
        {
            return long.Parse(Next());
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

        public static string ReadString()
        {
            return Next();
        }

        /// <summary>
        /// "00101001010"という様な入力をintの配列にして返す
        /// </summary>
        /// <returns></returns>
        public static int[] ReadIntArrayFromBinaryString()
        {
            Tokens = null;
            return Array.ConvertAll(Console.ReadLine().ToArray(), c => int.Parse(c.ToString()));
        }

        /// <summary>
        /// "00101001010"という様な入力をboolの配列にして返す
        /// </summary>
        /// <returns></returns>
        public static bool[] ReadBoolArrayFromBinaryString()
        {
            Tokens = null;
            return Console.ReadLine().Select(c => c == '1').ToArray();
        }
    }

    /// <summary>
    /// ユーティリティー
    /// </summary>
    public static class Util
    {
        // 10^17
        public static readonly long INF = (long)1e17;

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
        /// 逆順ソートをして結果を返します。
        /// 破壊的関数です。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] ReverseSort<T>(T[] array)
        {
            Array.Sort<T>(array);
            Array.Reverse(array);
            return array;
        }

        /// <summary>
        /// Rubyにあるようなやつ
        /// ex) 5.Times(i => Console.WriteLine(i));
        /// </summary>
        /// <param name="times"></param>
        /// <param name="action"></param>
        public static void Times(this int times, Action<int> action)
        {
            for (int i = 0; i < times; i++)
            {
                action(i);
            }
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

        public static int[] GetDivisor(int n)
        {
            double sqrt = Math.Sqrt(n);

            List<int> divisor = new List<int>();

            for (int i = 1; i <= sqrt; i++)
            {
                if (n % i == 0)
                {
                    divisor.Add(i);
                    int tmp = n / i;
                    if (tmp != i)
                    {
                        divisor.Add(tmp);
                    }
                }
            }

            return Sort(divisor.ToArray());
        }

        public static int[] LongToBinaryArray(long n)
        {
            List<int> lst = new List<int>();

            while (n > 0)
            {
                int amari = (int)(n % 2);
                lst.Add(amari);
                n /= 2;
            }

            return lst.ToArray();
        }

        public static long BinaryArrayToLong(int[] binaryArray)
        {
            long result = 0;
            long b = 1;
            int len = binaryArray.Length;

            for (int i = 0; i < len; i++)
            {
                result += binaryArray[i] * b;
                b *= 2;
            }

            return result;
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

        public static void ArrayInitialize<T>(T[,] array, T value)
        {
            int len0 = array.GetLength(0);
            int len1 = array.GetLength(1);

            for (int i = 0; i < len0; i++)
            {
                for (int j = 0; j < len1; j++)
                {
                    array[i, j] = value;
                }
            }
        }

        public static void ChMax(ref long a, long b)
        {
            if (a < b) a = b;
        }

        public static void ChMin(ref long a, long b)
        {
            if (a > b) a = b;
        }

        public readonly static int MOD = 1000000007;
        public static void ModAdd(ref long a, long b)
        {
            a += b;
            if (a >= MOD)
                a %= MOD;
        }

        public static T MinBy<T>(this IEnumerable<T> source, Func<T, long> conv)
        {
            T min = source.First();
            long minValue = conv(min);
            foreach (T x in source.Skip(1))
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
            long maxValue = conv(min);
            foreach (T x in source.Skip(1))
            {
                long n = conv(x);
                if (maxValue < n)
                {
                    min = x;
                }
            }

            return min;
        }
    }

    /// <summary>
    /// HashSetにTupleを入れた時の、等値性判定方法の指定に使います。
    /// HashSetのコンストラクタに渡して使います。
    /// EqualsとGetHashCodeを提供します。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EqualityComparer<T> : IEqualityComparer<T>
    {
        private Func<T, T, bool> _equals;
        private Func<T, int> _getHashCode;

        public EqualityComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
        {
            _equals = equals;
            _getHashCode = getHashCode;
        }

        public bool Equals(T x, T y)
        {
            return _equals(x, y);
        }

        public int GetHashCode(T obj)
        {
            return _getHashCode(obj);
        }
    }

    /// <summary>
    /// UnionFindTree
    /// </summary>
    public class UnionFindTree
    {
        int[] Node;

        public UnionFindTree(int N)
        {
            Node = new int[N];
            for (int i = 0; i < N; i++)
            {
                Node[i] = -1;
            }
        }

        public bool IsSameGroup(int x, int y)
        {
            return GetRoot(x) == GetRoot(y);
        }

        public bool Merge(int x, int y)
        {
            int xr = GetRoot(x);
            int yr = GetRoot(y);

            if (xr == yr)
                return false;

            // xが、大きなグループを示すようにSwapする（値が小さい方が大きなグループ）
            if (Node[xr] > Node[yr])
                Swap(ref xr, ref yr);

            // グループの数を合算する
            Node[xr] += Node[yr];

            // 根を張り替える
            Node[yr] = xr;
            return true;
        }

        public int Size(int x)
        {
            return -Node[GetRoot(x)];
        }

        public int GetRoot(int n)
        {
            if (Node[n] < 0)
            {
                return n;
            }
            else
            {
                // 根を張りなおす。
                Node[n] = GetRoot(Node[n]);
                return Node[n];
            }
        }
    }

    /// <summary>
    /// PriorityQueue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T>
    {
        private Comparison<T> _comparison = null;
        private int _type = 0;

        private T[] _heap;
        private int _sz = 0;

        private int _count = 0;

        /// <summary>
        /// Priority queue
        /// </summary>
        /// <param name="maxSize">max size</param>
        /// <param name="type">0: asc, 1:desc</param>
        public PriorityQueue(int maxSize, int type = 0)
        {
            _heap = new T[maxSize];
            _type = type;
        }

        public PriorityQueue(int maxSize, Comparison<T> comparison)
        {
            _heap = new T[maxSize];
            _comparison = comparison;
        }

        private int Compare(T x, T y)
        {
            return _comparison(x, y);
            //if (_comparison != null) return _comparison(x, y);
            //return _type == 0 ? x.CompareTo(y) : y.CompareTo(x);
        }

        public void Push(T x)
        {
            _count++;

            //node number
            var i = _sz++;

            while (i > 0)
            {
                //parent node number
                var p = (i - 1) / 2;

                if (Compare(_heap[p], x) <= 0) break;

                _heap[i] = _heap[p];
                i = p;
            }

            _heap[i] = x;
        }

        public T Pop()
        {
            _count--;

            T ret = _heap[0];
            T x = _heap[--_sz];

            int i = 0;
            while (i * 2 + 1 < _sz)
            {
                //children
                int a = i * 2 + 1;
                int b = i * 2 + 2;

                if (b < _sz && Compare(_heap[b], _heap[a]) < 0) a = b;

                if (Compare(_heap[a], x) >= 0) break;

                _heap[i] = _heap[a];
                i = a;
            }

            _heap[i] = x;

            return ret;
        }

        public int Count()
        {
            return _count;
        }

        public T Peek()
        {
            return _heap[0];
        }

        public bool Contains(T x)
        {
            for (int i = 0; i < _sz; i++) if (x.Equals(_heap[i])) return true;
            return false;
        }

        public void Clear()
        {
            while (this.Count() > 0) this.Pop();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var ret = new List<T>();

            while (this.Count() > 0)
            {
                ret.Add(this.Pop());
            }

            foreach (var r in ret)
            {
                this.Push(r);
                yield return r;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[_sz];
            int i = 0;

            foreach (var r in this)
            {
                array[i++] = r;
            }

            return array;
        }
    }
}
