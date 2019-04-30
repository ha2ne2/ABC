using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ABC122.Util;

namespace ABC122
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2019/04/28
            // 結果：A,B,Cは解けたが、D解けず。Dなんだよこれ（怒）
            // 感想戦後：D簡単やん

            // DoubleHelix(); // 5min
            // AtCoder(); // 11min
            // GeTAC(); // 1h5m
            // WeLikeAGC(); //解けず

            WeLikeAGC();
        }

        readonly static int MOD = 1000000007;
        static void ModAdd(ref long a, long b)
        {
            a += b;
            if (a >= MOD)
                a -= MOD;
        }

        static long Solve(int N)
        {
            long[,,,] dp = new long[N+1,5,5,5];
            dp[0, 0, 0, 0] = 1;

            for(int n = 0; n < N; n++)
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        for (int k = 0; k < 5; k++)
                            for (int l = 1; l < 5; l++)
                            {
                                if (i == 1 && j == 2 && l == 3) continue;
                                if (i == 1 && k == 2 && l == 3) continue;
                                if (j == 1 && k == 2 && l == 3) continue;
                                if (j == 2 && k == 1 && l == 3) continue;
                                if (j == 1 && k == 3 && l == 2) continue;
                                ModAdd(ref dp[n + 1,j,k,l], dp[n,i,j,k]);
                            }

            long res = 0;
            for (int i = 1; i < 5; i++)
                for (int j = 1; j < 5; j++)
                    for (int k = 1; k < 5; k++)
                        ModAdd(ref res, dp[N, i, j, k]);

            return res;
        }


        static void WeLikeAGC()
        {
            int N = ReadInt();

            long ans = Solve(N);

            Console.WriteLine(ans);
        }

        static void GeTAC()
        {
            var tmp = ReadIntArray();
            var N = tmp[0];
            var Q = tmp[1];

            var S = Console.ReadLine();
            var lr = new int[Q][];

            for(int i = 0; i < Q; i++)
            {
                lr[i] = ReadIntArray();
            }

            // 累積和を作る
            int[] cusum = new int[N];
            for (int i = 1; i < N; i++)
            {
                if (S[i] == 'C' && S[i - 1] == 'A')
                {
                    cusum[i] = cusum[i - 1] + 1;
                }
                else
                {
                    cusum[i] = cusum[i - 1];
                }
            }

            // 答えを出していく
            for (int i = 0; i < Q; i++)
            {
                // 1ベースなので0ベースに変換
                var l = lr[i][0] - 1;
                var r = lr[i][1] - 1;

                int ans = cusum[r] - cusum[l];

                Console.WriteLine(ans);
            }
        }

        static void AtCoder()
        {
            string agct = "AGCT";
            string input = Console.ReadLine();
            int len = input.Length;

            int ans = 0;
            int cur = 0;
            for (int i = 0; i < len; i++)
            {
                if (agct.Contains(input[i]))
                {
                    cur++;
                }
                else
                {
                    ans = Math.Max(ans, cur);
                    cur = 0;
                }
            }

            ans = Math.Max(ans, cur);

            Console.WriteLine(ans);
        }

        static void DoubleHelix()
        {
            string input = Console.ReadLine();

            string ans = string.Empty;
            if (input == "A")
            {
                ans = "T";
            }
            else if (input == "T")
            {
                ans = "A";
            }
            else if (input == "C")
            {
                ans = "G";
            }
            else if (input == "G")
            {
                ans = "C";
            }

            Console.WriteLine(ans);
        }
    }

    #region common

    public static class Util
    {
        public static void Times(this int times, Action<int> action)
        {
            for(int i = 0; i < times; i++)
            {
                action(i);
            }
        }

        public static T[] ReverseSort<T>(T[] array)
        {
            Array.Sort<T>(array);
            Array.Reverse(array);
            return array;
        }

        public static int[] ReadBinaryString()
        {
            return Console.ReadLine().Select(c => int.Parse(c.ToString())).ToArray();
        }

        public static bool[] ReadBoolArray()
        {
            return Console.ReadLine().Select(c => c == '1').ToArray();
        }

        public static long ReadLong()
        {
            return long.Parse(Console.ReadLine());
        }
        public static long[] ReadLongArray()
        {
            return Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        }

        public static int ReadInt()
        {
            return int.Parse(Console.ReadLine());
        }

        public static int[] ReadIntArray()
        {
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }
    }

    /// <summary>
    /// EqualsとGetHashCodeを提供します。IEqualityComparer<T>を実装するクラスです。
    /// HashSetのコンストラクタに渡すために使います。
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
