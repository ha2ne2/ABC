using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    public static class UtilNigun
    {
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

    }
}
