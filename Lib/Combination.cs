using System;
using System.Collections.Generic;
using System.Text;
using Pair = Lib.VTuple<long, long>;

namespace Lib
{
    public class Combination
    {
        static long SIZE = (long)1e7 + 1;
        static Mint[] mFactorial, mFactrialInverse, mInverse;

        private static void Init()
        {
            mFactorial = new Mint[SIZE];
            mFactrialInverse = new Mint[SIZE];
            mInverse = new Mint[SIZE];

            mFactorial[0] = mFactorial[1] = 1;
            mFactrialInverse[0] = mFactrialInverse[1] = 1;
            mInverse[1] = 1;
            for (int i = 2; i < SIZE; i++)
            {
                mFactorial[i] = mFactorial[i - 1] * i;
                mInverse[i] = -1 * mInverse[Mint.MOD % i] * (Mint.MOD / i);
                mFactrialInverse[i] = mFactrialInverse[i - 1] * mInverse[i];
            }
        }

        /// <summary>
        /// calc nCk for O(1)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Mint nCk(int n, int k)
        {
            if (mFactorial == null) Init();
            if (n < k) return 0;
            if (n < 0 || k < 0) return 0;
            return mFactorial[n] * mFactrialInverse[k] * mFactrialInverse[n - k];
        }

        /// <summary>
        /// nが大きくてkが小さいときに使える。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Mint nCkForBigNSmallK(long n, long k)
        {
            Mint x = 1;
            Mint y = 1;
            for (int i = 0; i < k; i++)
            {
                x *= n - i;
                y *= i + 1;
            }
            return x / y;
        }
    }
}
