﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ABC117.Util;
using static System.Console;

#if DEBUG
using System.Diagnostics;
#endif

namespace ABC117
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            while (true)
            {
#endif
                // EntranceExamination(); // 3m
                // Polygon(); // 13m
                // Streamline(); // 40m
                XXOR();
#if DEBUG
            }
#endif
        }

        static void XXOR()
        {
            int maxDigit = 50;

            long[] input = ReadLongArray();
            long N = input[0];
            long K = input[1];
            long[] A = ReadLongArray();

            long[,] dp = new long[maxDigit+1, 2];
            ArrayInitialize(dp, -1);
            dp[0, 0] = 0;

            for(int d = 0; d < maxDigit; d++)
            {
                long mask = 1L << (maxDigit - d - 1);

                int num1 = 0;
                // d桁目の1の数
                for (int i = 0; i < N; i++)
                    if ((A[i] & mask) == mask)
                        num1++;

                long cost0 = mask * num1;
                long cost1 = mask * (N - num1);

                // exact -> exact
                if (dp[d, 0] != -1)
                {
                    if ((K & mask) == mask)
                        ChMax(ref dp[d + 1, 0], dp[d, 0] + cost1);
                    else
                        ChMax(ref dp[d + 1, 0], dp[d, 0] + cost0);
                }
                
                // exact -> smaller
                if (dp[d, 0] != -1)
                {
                    if ((K & mask) == mask)
                        ChMax(ref dp[d + 1, 1], dp[d, 0] + cost0);
                }

                // smaller -> smaller
                if (dp[d, 1] != -1)
                {
                    ChMax(ref dp[d + 1, 1], dp[d, 1] + Math.Max(cost0, cost1));
                }
            }

            long ans = Math.Max(dp[maxDigit, 0], dp[maxDigit, 1]);
            WriteLine(ans);
        }

        static void Streamline()
        {
            int[] input = ReadIntArray();
            int N = input[0];
            int M = input[1];
            int[] X = ReadIntArray();

            Sort(X);
            int[] diffList = new int[M - 1];
            for (int i = 0; i < M-1; i++)
            {
                diffList[i] = X[i + 1] - X[i];
            }
            ReverseSort(diffList);

            int ans = diffList.Skip(N-1).Sum();
            WriteLine(ans);
        }


        static void Polygon()
        {
            int N = ReadInt();
            int[] L = ReadIntArray();

            ReverseSort(L);

            int max = L[0];
            int sum = L.Skip(1).Sum();

            string ans = max < sum ? "Yes" : "No";

            WriteLine(ans);
        }


        static void EntranceExamination()
        {
            int[] tmp = ReadIntArray();
            int T = tmp[0];
            int X = tmp[1];

            WriteLine(T * 1.0m / X);
        }
    }


    #region ToolBox

    /// <summary>
    /// ユーティリティー
    /// </summary>
    public static class Util
    {
        // 10^10 * 2
        public static readonly long INF = 20000000000;

        public static int ReadInt()
        {
            return int.Parse(Console.ReadLine());
        }
        
        public static int[] ReadIntArray()
        {
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        public static long ReadLong()
        {
            return long.Parse(Console.ReadLine());
        }

        public static long[] ReadLongArray()
        {
            return Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        }

        public static string ReadString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// "00101001010"という様な入力をintの配列にして返す
        /// </summary>
        /// <returns></returns>
        public static int[] ReadIntArrayFromBinaryString()
        {
            return Console.ReadLine().Select(c => int.Parse(c.ToString())).ToArray();
        }

        /// <summary>
        /// "00101001010"という様な入力をboolの配列にして返す
        /// </summary>
        /// <returns></returns>
        public static bool[] ReadBoolArrayFromBinaryString()
        {
            return Console.ReadLine().Select(c => c == '1').ToArray();
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
                    return mid;
                else if (n < array[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
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

            for(int i = 0; i < len0; i++)
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

#if DEBUG
        static void SampleGenerator()
        {
            int A = 1000;
            int B = 1000;
            int Q = 1000;

            Random r = new Random();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} {1} {2}", A, B, Q));
            A.Times(a => sb.AppendLine(((long)r.Next() * r.Next()).ToString()));
            B.Times(b => sb.AppendLine(((long)r.Next() * r.Next()).ToString()));
            Q.Times(q => sb.AppendLine(((long)r.Next() * r.Next()).ToString()));

            Debug.WriteLine(sb.ToString());
        }
#endif

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
    public class PriorityQueue<T> where T : IComparable
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
            if (_comparison != null) return _comparison(x, y);
            return _type == 0 ? x.CompareTo(y) : y.CompareTo(x);
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

    #endregion
}