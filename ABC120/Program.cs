using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ABC120.Util;

namespace ABC120
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            while (true)
            {
#endif
                // 2019/04/29
                // FavoriteSound(); 5min
                // KthCommonDivisor(); // 27min
                // Unification(); // 52min
                DecayedBridges();
#if DEBUG
            }
#endif
        }

        static void DecayedBridges()
        {
            int[] tmp = ReadIntArray();
            int N = tmp[0]; // 島の数
            int M = tmp[1]; // 橋の数

            int[][] nodes = new int[M][];
            M.Times(m => {
                nodes[m] = ReadIntArray();
            });


            int[] data = new int[N];

            foreach(var node in nodes)
            {
                data[node[0]]++;
                data[node[1]]++;
            }
            

        }

        static void Unification()
        {
            int[] blocks = ReadIntArrayFromBinaryString();

            int zero = 0;
            int one = 0;
            foreach(var b in blocks)
            {
                if (b == 0)
                {
                    zero++;
                }
                else
                {
                    one++;
                }
            }

            int ans = Math.Min(zero, one) * 2;

            Console.WriteLine(ans);
        }

        static void KthCommonDivisor()
        {
            int[] tmp = ReadIntArray();
            int A = tmp[0];
            int B = tmp[1];
            int K = tmp[2];

            var aDivisor = new List<int>();

            // Aの約数を取得
            double rootA = Math.Sqrt(A);
            for (int i = 1; i <= rootA; i++)
            {
                if (A % i == 0)
                {
                    aDivisor.Add(i);
                    if (i != rootA)
                        aDivisor.Add(A / i);
                }
            }

            int ans = 0;
            int cnt = 0;
            foreach(var d in aDivisor.OrderByDescending(i => i))
            {
                if (B % d == 0)
                {
                    cnt++;

                    if (cnt == K)
                    {
                        ans = d;
                        break;
                    }
                }
            }

            Console.WriteLine(ans);
        }

        static void FavoriteSound()
        {
            int[] tmp = ReadIntArray();
            int A = tmp[0];
            int B = tmp[1];
            int C = tmp[2];

            int ans = Math.Min(B / A, C);
            Console.WriteLine(ans);
        }
    }

    #region common

    /// <summary>
    /// ユーティリティー
    /// </summary>
    public static class Util
    {
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