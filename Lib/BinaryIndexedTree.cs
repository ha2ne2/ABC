using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    /// <summary>
    /// BIT 0-indexed
    /// </summary>
    public class BinaryIndexedTree
    {
        long[] Array;
        int N;

        public BinaryIndexedTree(int n)
        {
            Array = new long[n];
            N = n;
        }

        /// <summary>
        /// 各要素をnで初期化する
        /// </summary>
        /// <param name="n"></param>
        public void Init(int n)
        {
            for (int i = 0; i < N; i++)
            {
                Array[i] = n;
            }
            for (int i = 0; i < N; i++)
            {
                if ((i | (i + 1)) < N)
                    Array[i | (i + 1)] += Array[i];
            }
        }

        /// <summary>
        /// 区間[0,i]の累積和を求める
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long Sum(int i)
        {
            long sum = 0;
            while(i >= 0)
            {
                sum += Array[i];
                i = (i & (i + 1)) - 1;
            }
            return sum;
        }

        /// <summary>
        /// 区間[i,j]の総和を求める
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public long Sum(int left, int right)
        {
            long l = Sum(left - 1);
            long r = Sum(right);
            return r - l;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="i"></param>
        /// <param name="n"></param>
        public void Add(int i, long n)
        {
            while (i < N)
            {
                Array[i] += n;
                i |= i + 1;
            }
        }
    }
}
