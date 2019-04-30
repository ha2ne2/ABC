using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ABC123.Util;
using Data2 = System.Tuple<long, int[]>;

namespace ABC123
{
    class Program
    {
        static void Main(string[] args)
        {
            // FiveAntennas(); // 25min
            // FiveDishes(); // 35min
            // FiveTransportation(); // 1h11m
            Cake123_pq2();
        }

        public static void Cake123_pq2()
        {
            int[] N = new int[3];
            int[] tmp = ReadIntArray();
            for (int i = 0; i < 3; i++)
            {
                N[i] = tmp[i];
            }
            int K = tmp[3];

            List<long[]> v = new List<long[]>();
            v.Add(ReverseSort(ReadLongArray()));
            v.Add(ReverseSort(ReadLongArray()));
            v.Add(ReverseSort(ReadLongArray()));

            PriorityQueue<Data2> que = new PriorityQueue<Data2>(K * 3, 
                (a,b) => b.Item1.CompareTo(a.Item1));

            HashSet<Data2> set = new HashSet<Data2>(
                new EqualityComparer<Data2>(
                    (a,b) => a.Item1 == b.Item1 && a.Item2.SequenceEqual(b.Item2),
                    (obj) => obj.Item1.GetHashCode() ^ obj.Item2[0] ^ obj.Item2[1] ^ obj.Item2[2]));

            Data2 first = new Data2(v[0][0] + v[1][0] + v[2][0], new int[] { 0, 0, 0 });
            que.Push(first);

            for (int k = 0; k < K; k++)
            {
                var data = que.Pop();
                Console.WriteLine(data.Item1);

                // 次の3候補
                for (int i = 0; i < 3; i++)
                {
                    if (data.Item2[i] + 1 < N[i])
                    {
                        var sum = data.Item1 - v[i][data.Item2[i]] + v[i][data.Item2[i] + 1];
                        int[] num = new int[3];
                        data.Item2.CopyTo(num, 0);
                        num[i]++;
                        var d = new Data2(sum, num);

                        if (!set.Contains(d))
                        {
                            set.Add(d);
                            que.Push(d);
                        }
                    }
                }
            }
        }

        public static void Cake123_old()
        {
            int[] tmp = ReadIntArray();
            int k = tmp[3];
            int x = Math.Min(tmp[0],k);
            int y = Math.Min(tmp[1],k);
            int z = Math.Min(tmp[2],k);

            long[] aa = ReadLongArray();
            long[] bb = ReadLongArray();
            long[] cc = ReadLongArray();

            // aとbの合計だけを計算してeとする
            int e = x*y;
            long[] ee = new long[e];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    ee[y * i + j] = aa[i] + bb[j];
                }
            }

            ReverseSort(ee);
            int e2 = Math.Min(e, k);
            long[] ans = new long[e2*z];
            for (int i = 0; i < e2; i++)
            {
                for (int j = 0; j < z; j++)
                {
                    ans[z * i + j] = ee[i] + cc[j];
                }
            }

            ReverseSort(ans);
            for (int i = 0; i < k; i++)
            {
                Console.WriteLine(ans[i]);
            }
        }

        public static void FiveTransportation()
        {
            long n = ReadLong();
            long[] time = new long[5];
            for (int i = 0; i < 5; i++)
            {
                time[i] = ReadLong();
            }

            long min = time.Min();

            long ans = (long)Math.Ceiling(n * 1.0m / min) + 4;

            Console.WriteLine(ans);
        }

        public static void FiveDishes()
        {
            int[] dishes = new int[5];
            for(int i = 0; i < 5; i++)
            {
                dishes[i] = ReadInt();
            }

            dishes = dishes.OrderByDescending(i => i % 10 == 0 ? 10 : i % 10).ToArray();

            int ans = 0;
            for(int i = 0; i < 4; i++)
            {
                ans += (int)Math.Ceiling(dishes[i] / 10m) * 10;
            }

            ans += dishes[4];

            Console.WriteLine(ans);
        }

        public static void FiveAntennas()
        {
            int[] antennas = new int[5];
            for(int i = 0; i < 5; i++)
            {
                antennas[i] = ReadInt();
            }

            int k = ReadInt();

            string ans = "Yay!";
            if (antennas[0] + k < antennas[4])
            {
                ans = ":(";
            }

            Console.WriteLine(ans);
        }
    }

    public class Util
    {
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
    /// HashSetのコンストラクタに渡します。
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
}
