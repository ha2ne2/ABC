using System;

namespace Lib
{
    /// <summary>
    /// ユーティリティー
    /// </summary>
    public static class Util
    {
        // 10^17
        public static readonly long INF = (long)1e17;

        // 10^9 + 7
        public readonly static long MOD = (long)1e9 + 7;

        // 4近傍
        public readonly static int[] DXY4 = { 0, 1, 0, -1, 0 };

        // 8近傍
        public readonly static int[] DXY8 = { 1, 1, 0, 1, -1, 0, -1, -1, 1 };


        /// <summary>
        /// Console.WriteLineの自動フラッシュをしないようにする
        /// </summary>
        public static void DontAutoFlush()
        {
            // Console.Outが既に差し替えられている場合（e.g 出力テストの為に出力先をStringWriterに差し替えた）は何もしない
            if (Console.IsOutputRedirected)
                return;

            var sw = new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
        }

        public static void Flush()
        {
            Console.Out.Flush();
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
        /// 降順ソートをして結果を返します。
        /// 破壊的関数です。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] SortDecend<T>(T[] array)
        {
            Array.Sort<T>(array);
            Array.Reverse(array);
            return array;
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

        public static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long _a = a;
                a = b;
                b = _a % b;
            }
            return a;
        }

        public static long LCM(long a, long b)
        {
            if (a == 0 || b == 0)
                return 0;

            return a / GCD(a, b) * b;
        }

        public static void ChMax(ref long a, long b)
        {
            if (a < b) a = b;
        }

        public static void ChMin(ref long a, long b)
        {
            if (a > b) a = b;
        }

        public static void ChMax(ref int a, int b)
        {
            if (a < b) a = b;
        }

        public static void ChMin(ref int a, int b)
        {
            if (a > b) a = b;
        }

        public static void FillArray<T>(T[] array, T value)
        {
            int max = array.Length;
            for (int i = 0; i < max; i++)
            {
                array[i] = value;
            }
        }

        public static void FillArray<T>(T[,] array, T value)
        {
            int max0 = array.GetLength(0);
            int max1 = array.GetLength(1);

            for (int i = 0; i < max0; i++)
            {
                for (int j = 0; j < max1; j++)
                {
                    array[i, j] = value;
                }
            }
        }

        public static void FillArray<T>(T[,,] array, T value)
        {
            int max0 = array.GetLength(0);
            int max1 = array.GetLength(1);
            int max2 = array.GetLength(2);

            for (int i = 0; i < max0; i++)
            {
                for (int j = 0; j < max1; j++)
                {
                    for (int k = 0; k < max2; k++)
                    {
                        array[i, j, k] = value;
                    }
                }
            }
        }

        /// <summary>
        /// 累積和を求めて返します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static long[] Accumulate(long[] array)
        {
            long[] acc = new long[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                acc[i + 1] = acc[i] + array[i];
            }
            return acc;
        }

        public static double[] Accumulate(double[] array)
        {
            double[] acc = new double[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                acc[i + 1] = acc[i] + array[i];
            }
            return acc;
        }

        public static void EachDXY4(int h, int w, int H, int W, Action<int, int> fn)
        {
            for (int i = 0; i < 4; i++)
            {
                int nh = h + Util.DXY4[i];
                int nw = w + Util.DXY4[i + 1];

                if (0 <= nh && nh < H &&
                    0 <= nw && nw < W)
                {
                    fn(nh, nw);
                }
            }
        }
    }
}
