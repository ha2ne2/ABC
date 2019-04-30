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

            int[] A = new int[M];
            int[] B = new int[M];
            for (int i = 0; i < M; i++)
            {
                int[] tmp2 = ReadIntArray();
                A[i] = tmp2[0] - 1;
                B[i] = tmp2[1] - 1;
            }

            long cur = N * (N - 1) / 2;

            UnionFindTree uf = new UnionFindTree(N);
            List<long> res = new List<long>();
            for (int i = 0; i < M; i++)
            {
                res.Add(cur);

                int a = A[M - 1 - i];
                int b = B[M - 1 - i];
                if (uf.IsSameGroup(a, b)) continue;

                long sa = uf.Size(a);
                long sb = uf.Size(b);

                cur -= sa * sb;
                uf.Merge(a, b);
            }

            res.Reverse();
            int len = res.Count;
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine(res[i]);
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
    }

    /// <summary>
    /// HashSetの比較方法を指定したいときに使います。HashSetのコンストラクタに渡して使います。
    /// EqualsとGetHashCodeを提供します。IEqualityComparer<T>を実装するクラスです。
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

            //// xが、大きなグループを示すようにSwapする
            // -2 > -3 というような比較になる
            if (Node[xr] > Node[yr])
                Swap(ref xr, ref yr);

            // グループの数を合算する
            Node[xr] += Node[yr];

            // 根を張り替える
            Node[yr] = x;
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