using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    public static class UtilNigun
    {
        /// <summary>
        /// めぐる式二分探索
        /// okにはpredを満たすindexを、ngにはpredを満たさないindexを指定します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="ng"></param>
        /// <param name="ok"></param>
        /// <param name="pred"></param>
        public static void MeguruBinarySearch<T>(
            T[] array,
            ref long ng,
            ref long ok,
            Predicate<T> pred)
        {
            while (Math.Abs(ok - ng) > 1)
            {
                long mid = (ok + ng) / 2;
                if (pred(array[mid]))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
        }

        public static void EachDXY4(ref int h, ref int w, int H, int W, Action<int,int> fn)
        {
            for (int i = 0; i < 4; i++)
            {
                int nh = h + Util.DXY4[i];
                int nw = w + Util.DXY4[i + 1];

                if(0 <= nh && nh < W &&
                   0 <= nw && nw < W)
                {
                    fn(nh, nw);
                }
            }
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

            var array = divisor.ToArray();
            Array.Sort(array);
            return array;
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
        /// nを素因数分解し、キーが素数、値が指数のディクショナリを返す
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Dictionary<long,long> PrimeFactorize(long n)
        {
            Dictionary<long, long> dic = new Dictionary<long, long>();

            if (n % 2 == 0)
            {
                n /= 2;
                dic[2] = 1;
                while (n % 2 == 0)
                {
                    n /= 2;
                    dic[2]++;
                }
            }

            for (long i = 3; i * i <= n; i+=2)
            {
                if (n % i == 0)
                {
                    n /= i;
                    dic[i] = 1;
                    while (n % i == 0)
                    {
                        n /= i;
                        dic[i]++;
                    }
                }
            }

            if (n != 1)
                dic[n] = 1;

            return dic;
        }
        
        /// <summary>
        /// nの素因数のリストを返す
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<long> GetPrimeFactors(long n)
        {
            List<long> primes = new List<long>();

            if (n % 2 == 0)
            {
                primes.Add(2);
                while(n % 2 == 0) n /= 2;
            }

            for (long i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0)
                {
                    primes.Add(i);
                    while(n % i == 0) n /= i;
                }
            }

            if (n != 1)
                primes.Add(n);

            return primes;
        }

        public static void NextPermutation(int[] array)
        {
            // a[left] < a[left+1] を満たす最大のleftを探す
            int left = array.Length - 2;
            while (array[left] > array[left + 1])
            {
                left--;
                if (left < 0) return;
            }

            // a[left] < a[right] を満たす最大のrightを探す
            int leftVal = array[left];
            int right = array.Length - 1;
            while (leftVal > array[right])
            {
                right--;
            }

            // 入れ替える
            Swap(ref array[left], ref array[right]);

            // 後ろを全部入れ替える。入れ替え後は a[left] > a[left+1] < a[left+2] < ... < a[length-1] という不等式が成り立つ。
            left++;
            right = array.Length - 1;
            while (left < right)
            {
                Swap(ref array[left], ref array[right]);
                left++;
                right--;
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        public static long modinv(long a, long mod)
        {
            long b = mod, u = 1, v = 0;
            while(b != 0)
            {
                long t = a / b;
                a -= t * b;
                Swap(ref a, ref b);
                u -= t * v;
                Swap(ref u, ref v);
            }
            u %= mod;
            if (u < 0) u += mod;
            return u;
        }

        public static long modinv2(long a, long mod)
        {
            long x, y;
            ExtGcd(a, mod, out x, out y);
            x %= mod;
            if (x < 0) x += mod;
            return x;
        }

        /// <summary>
        /// 返り値: a と b の最大公約数
        /// ax + by = gcd(a, b) を満たす (x, y) が格納される。
        /// 再帰実装
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static long ExtGcd(long a, long b, out long x, out long y)
        {
            if (b == 0)
            {
                x = 1;
                y = 0;
                return a;
            }
            long d = ExtGcd(b, a % b, out y, out x);
            y -= a / b * x;
            return d;
        }

        /// <summary>
        /// 拡張ユークリッド互除法
        /// ax+by=gcd(a,b)を満たすx,yを引数に格納する。
        /// 戻り値はgcd(a,b)。
        /// 行列演算による非再帰実装。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static long ExtGcd2(long a, long b, out long x, out long y)
        {
            x = 1;
            y = 0;
            long u = 0;
            long v = 1;

            while (b != 0)
            {
                // 行列の累積積
                long k = a / b;
                long _x = u;
                u = x - k * u;
                x = _x;
                long _y = v;
                v = y - k * v;
                y = _y;

                // 現在の係数（Euclid）
                long _a = a;
                a = b;
                b = _a - (k * b);
            }

            return a;
        }



    }
}
