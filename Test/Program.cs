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

namespace Test
{
    class Program
    {

        static void Main(string[] args)
        {
        START:
            D127();
            // 1 3 6 14 38 77
            // A(); 1m
            // B(); 5m
            // C(); 8m
            // D(); 10m
            // E(); 30m
            // F(); // 36m

#if DEBUG
            goto START;
#endif
        }

        private static void D127()
        {
            long N = ReadLong();
            long M = ReadLong();
            long[] As = ReadLongArray();

            List<Tuple<long, long>> BC = new List<Tuple<long, long>>();
            for(int i = 0; i < M; i++)
            {
                long b = ReadLong();
                long c = ReadLong();
                BC.Add(new Tuple<long, long>(b, c));                
            }

            BC = BC.OrderByDescending(bc => bc.Item2).ToList();
            As = As.OrderBy(a => a).ToArray();

            long jSum = 0;
            for (int i = 0; i < M; i++)
            {                
                for (int j = 0; j < BC[i].Item1; j++)
                {
                    long nj = jSum + j;
                    if (N <= nj || BC[i].Item2 <= As[nj])
                        goto BIG_BREAK;

                    As[nj] = BC[i].Item2;
                }
                jSum += BC[i].Item1;
            }
        BIG_BREAK:
            long ans = As.Sum();
            WriteLine(ans);
        }


        class Monster
        {
            public long X { get; set; }
            public long H { get; set; }
        }

        private static void F()
        {
            long N = ReadLong();
            long D = ReadLong();
            long A = ReadLong();
            Monster[] monsters = new Monster[N];
            for(int i = 0; i < N; i++)
            {
                var m = new Monster();
                m.X = ReadLong();
                m.H = ReadLong();
                monsters[i] = m;
            }

            monsters = monsters.OrderBy(m => m.X).ToArray();

            long countSum = 0;
            long[] counts = new long[N];
            int l = 0;

            for(int i = 0; i < N; i++)
            {
                while (monsters[l].X + 2 * D < monsters[i].X)
                {
                    countSum -= counts[l];
                    l++;
                }

                var hp = Max(monsters[i].H - countSum * A, 0);
                var cnt = hp / A;
                if (hp % A != 0) cnt++;

                counts[i] = cnt;
                countSum += cnt;
            }

            WriteLine(counts.Sum());
        }

        private static void E()
        {
            long H = ReadLong();
            long N = ReadLong();
            long[] A = new long[N];
            long[] B = new long[N];

            for (int i = 0; i < N; i++)
            {
                A[i] = ReadLong();
                B[i] = ReadLong();
            }

            long[] dp = new long[H+1];
            for (int i = 0; i <= H; i++)
                dp[i] = long.MaxValue;

            dp[0] = 0;

            for (int i = 0; i <= H; i++)
            {
                if (dp[i] == long.MaxValue) continue;
                for (int j = 0; j < N; j++)
                {
                    long ni = Min(H, i + A[j]);
                    dp[ni] = Min(dp[ni], dp[i] + B[j]);
                }
            }

            WriteLine(dp[H]);
        }

        private static void D()
        {
            long H = ReadLong();

            long cnt = 0;
            while(0 < H)
            {
                H /= 2;
                cnt++;
            }

            long ans = 0;
            for (; 0 < cnt; cnt--)
                ans = ans * 2 + 1;

            WriteLine(ans);
        }

        private static void C()
        {
            long N = ReadLong();
            int K = ReadInt();
            long[] H = ReadLongArray();
            var ans = H.OrderByDescending(h => h).Skip(K).Sum();

            WriteLine(ans);
        }

        private static void B()
        {
            long H = ReadLong();
            long N = ReadLong();
            long[] A = ReadLongArray();
            
            WriteLine(A.Sum() >= H ? "Yes" : "No");
        }

        private static void A()
        {
            long H = ReadLong();
            long A = ReadLong();

            long ans = H / A;
            if (H % A != 0)
                ans++;

            WriteLine(ans);
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
        public int[] Node;

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
