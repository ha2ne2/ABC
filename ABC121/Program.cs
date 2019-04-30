using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ABC121.Util;

namespace ABC121
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
                // WhiteCells();       // 12min
                // CanYouSolveThis();  // 24min
                // EnergyDrinkCollector(); // 45min
                XORWorld(); // 3h20min toketa
#if DEBUG
            }
#endif
        }

        static int[] LongToBinaryArray(long n)
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

        static long BinaryArrayToLong(int[] binaryArray)
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

        static int[] CalcGap(long n, int[] binaryArray, bool up = true)
        {
            var lst = new List<int>();

            int len = binaryArray.Length;

            for (int i = 0; i < len; i++)
            {
                if (binaryArray[i] == 0)
                {
                    lst.Add(0);
                }
                else
                {
                    binaryArray[i] = 0;
                    long zerorized = BinaryArrayToLong(binaryArray);
                    lst.Add((n - zerorized + (up ? 0 : 1)) % 2 == 0 ? 0 : 1);
                }
            }

            return lst.ToArray();
        }


        static void XORWorld()
        {
            long[] tmp = ReadLongArray();
            long A = tmp[0];
            long B = tmp[1];

            var a = CalcGap(A, LongToBinaryArray(A), up: true);
            var b = CalcGap(B, LongToBinaryArray(B), up: false);

            var alen = a.Length;
            var blen = b.Length;
            int[] tmp2 = new int[blen];

            for (int i = 0; i < blen; i++)
            {
                if (alen <= i)
                {
                    tmp2[i] = (b[i] % 2 == 0) ? 0 : 1;
                } 
                else
                {
                    tmp2[i] = ((a[i] + b[i]) % 2 == 0) ? 0 : 1;
                }
            }

            if (A == 0 && B == 0)
            {

            }
            else if (A - B == 0)
            {
                tmp2[0] = 0;
            }
            else
            {
                tmp2[0] = (int)((B - A + 1 + (A % 2 == 1 ? 1 : 0)) / 2 % 2);
            }

            long ans = BinaryArrayToLong(tmp2);

            Console.WriteLine(ans);
        }

        static void EnergyDrinkCollector()
        {
            var tmp = ReadIntArray();
            int N = tmp[0];
            int M = tmp[1];

            int[][] A = new int[N][];
            N.Times(n =>
            {
                A[n] = ReadIntArray();
            });

            A = A.OrderBy(i => i[0]).ToArray();

            long curPrice = 0;
            int curBottle = 0;

            for (int i = 0; i < N; i++)
            {
                long price = A[i][0];
                int maxBottle = A[i][1];

                long maxPrice = price * maxBottle;
                if (curBottle + maxBottle >= M)
                {
                    while (curBottle < M)
                    {
                        curPrice += price;
                        curBottle++;
                    }
                    break;
                }
                else
                {
                    curPrice += maxPrice;
                    curBottle += maxBottle;
                }
            }

            Console.WriteLine(curPrice);
        }

        static void CanYouSolveThis()
        {
            var tmp = ReadIntArray();
            int N = tmp[0];
            int M = tmp[1];
            int C = tmp[2];

            int[] B = ReadIntArray();
            int[][] A = new int[N][];
            N.Times(i =>
                A[i] = ReadIntArray()
            );

            int ans = 0;
            N.Times(n =>
            {
                int sum = 0;
                M.Times(m =>
                {
                    sum += A[n][m] * B[m];
                });

                if (sum + C > 0)
                    ans++;
            });

            Console.WriteLine(ans);
        }

        static void WhiteCells()
        {
            var HW = ReadIntArray();
            var H = HW[0];
            var W = HW[1];
            var hw = ReadIntArray();
            var h = hw[0];
            var w = hw[1];

            bool[,] board = new bool[H, W];

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    board[i, j] = true;
                }
            }

            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    board[i, j] = true;
                }
            }

            int ans = 0;
            H.Times(i =>
            W.Times(j =>
            {
                if (board[i, j] == false) ans++;
            }));

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