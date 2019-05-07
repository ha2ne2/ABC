using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ABC119.Util;
using static System.Console;

#if DEBUG
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace ABC119
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            while (true)
            {
#endif
                // StillTBD(); // 3m
                // DigitalGifts(); // 12m
                // SyntheticKadomatsu(); // 60m wakaran
                //LazyFaith(); // 4h47m

                SyntheticKadomatsu();
#if DEBUG
            }
#endif
        }

        static void LazyFaith()
        {
            int[] tmp = ReadIntArray();
            int A = tmp[0];
            int B = tmp[1];
            int Q = tmp[2];

            long[] s = new long[A];
            long[] t = new long[B];
            long[] q = new long[Q];

            for (int i = 0; i < A; i++) s[i] = ReadLong();
            for (int i = 0; i < B; i++) t[i] = ReadLong();
            for (int i = 0; i < Q; i++) q[i] = ReadLong();

            Sort(s);
            Sort(t);

            long[] s2 = AddHeadAndTail(s);
            long[] t2 = AddHeadAndTail(t);

            s2[0] = t2[0] = -INF;
            s2[s2.Length-1] = t2[t2.Length-1] = INF;

            long[] ansArray = new long[Q];
            for(int i = 0; i < Q; i++)
            {
                long n = q[i];
                int si = BinarySearch(s2, n);
                int ti = BinarySearch(t2, n);

                long ans = long.MaxValue;

                foreach (var S in new long[] { s2[si - 1], s2[si] })
                {
                    foreach (var T in new long[] { t2[ti - 1], t2[ti] })
                    {
                        long d1 = Math.Abs(S - n) + Math.Abs(T - S);
                        long d2 = Math.Abs(T - n) + Math.Abs(T - S);

                        ans = Math.Min(ans, Math.Min(d1, d2));
                    }
                }

                ansArray[i] = ans;
            }

            DontAutoFlush();
            foreach(var _a in ansArray)
            {
                WriteLine(_a);
            }
            Flush();
        }

        static void SyntheticKadomatsu()
        {
            int[] tmp = ReadIntArray();
            int N = tmp[0];
            int A = tmp[1];
            int B = tmp[2];
            int C = tmp[3];
            int[] take = new int[N];
            for (int i = 0; i < N; i++)
            {
                take[i] = ReadInt();
            }

            Func<int, int, int, int, int> dfs = null;
            dfs = (int cur,int a,int b,int c) => {
                if (cur == N)
                {
                    if (Math.Min(a,Math.Min(b,c)) > 0)
                    {
                        return Math.Abs(a - A) + Math.Abs(b - B) + Math.Abs(c - C) - 30;
                    }
                    else
                    {
                        return int.MaxValue;
                    }
                }
                else
                {
                    return new List<int> {
                        dfs(cur + 1, a, b, c),
                        (dfs(cur + 1, a + take[cur], b, c) + 10),
                        (dfs(cur + 1, a, b + take[cur], c) + 10),
                        (dfs(cur + 1, a, b, c + take[cur]) + 10)
                    }.Min();
                }
            };

            WriteLine(dfs(0, 0, 0, 0));
        }

        static void DigitalGifts()
        {
            double BTC = 380000.0D;
            int N = ReadInt();
            double[] X = new double[N];
            string[] U = new string[N];

            for (int i = 0; i < N; i++)
            {
                string[] tmp = ReadString().Split(' ');

                X[i] = double.Parse(tmp[0]);
                U[i] = tmp[1];
            }

            double ans = 0;
            for (int i = 0; i < N; i++)
            {
                if (U[i] == "JPY")
                {
                    ans += X[i];
                }
                else
                {
                    ans += BTC * X[i];
                }
            }

            WriteLine(ans);
        }

        static void StillTBD()
        {
            string input = ReadString();
            int[] nums = input.Split('/').Select(int.Parse).ToArray();

            if (nums[0] <= 2019 && nums[1] <= 4 && nums[2] <= 30)
            {
                WriteLine("Heisei");
            }
            else
            {
                WriteLine("TBD");
            }
        }
    }

#if DEBUG
    [TestClass]
    public class Test
    {
        public static StreamReader StringToStreamReader(string s)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(s);
            MemoryStream stream = new MemoryStream(byteArray);
            StreamReader reader = new StreamReader(stream);
            return reader;
        }

        [TestMethod]
        public void Test1()
        {
            string input = "Testing 1-2-3";
            System.Console.SetIn(StringToStreamReader(input));
        }
    }

#endif

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
            int right = array.Length;

            while(left <= right)
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