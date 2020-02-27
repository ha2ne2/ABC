using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public static class Cin
    {
        #region public

        public static int ri { get { return ReadInt(); } }
        public static int[] ria { get { return ReadIntArray(); } }
        public static long rl { get { return ReadLong(); } }
        public static long[] rla { get { return ReadLongArray(); } }
        public static double rd { get { return ReadDouble(); } }
        public static double[] rda { get { return ReadDoubleArray(); } }
        public static string rs { get { return ReadString(); } }
        public static string[] rsa { get { return ReadStringArray(); } }

        public static int ReadInt()
        {
            return int.Parse(Next());
        }

        public static long ReadLong()
        {
            return long.Parse(Next());
        }

        public static double ReadDouble()
        {
            return double.Parse(Next());
        }

        public static string ReadString()
        {
            return Next();
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

        public static double[] ReadDoubleArray()
        {
            Tokens = null;
            return Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
        }

        public static string[] ReadStringArray()
        {
            Tokens = null;
            return Console.ReadLine().Split(' ');
        }

        public static void ReadCol(out long[] a, long N)
        {
            a = new long[N];
            for (int i = 0; i < N; i++)
            {
                a[i] = ReadLong();
            }
        }

        public static void ReadCols(out long[] a, out long[] b, long N)
        {
            a = new long[N];
            b = new long[N];
            for (int i = 0; i < N; i++)
            {
                a[i] = ReadLong();
                b[i] = ReadLong();
            }
        }

        public static void ReadCols(out long[] a, out long[] b, out long[] c, long N)
        {
            a = new long[N];
            b = new long[N];
            c = new long[N];
            for (int i = 0; i < N; i++)
            {
                a[i] = ReadLong();
                b[i] = ReadLong();
                c[i] = ReadLong();
            }
        }

        public static int[,] ReadIntTable(int h, int w)
        {
            Tokens = null;
            int[,] ret = new int[h,w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    ret[i, j] = ReadInt();
                }
            }

            return ret;
        }

        public static long[,] ReadLongTable(long h, long w)
        {
            Tokens = null;
            long[,] ret = new long[h,w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    ret[i, j] = ReadLong();
                }
            }

            return ret;
        }

        public static char[,] ReadCharTable(int h, int w)
        {
            Tokens = null;
            char[,] res = new char[h, w];
            for (int i = 0; i < h; i++)
            {
                string s = ReadString();
                for (int j = 0; j < w; j++)
                {
                    res[i, j] = s[j];
                }
            }

            return res;
        }

        #endregion

        #region private

        private static string[] Tokens;

        private static int Pointer;

        private static string Next()
        {
            if (Tokens == null || Tokens.Length <= Pointer)
            {
                Tokens = Console.ReadLine().Split(' ');
                Pointer = 0;
            }

            return Tokens[Pointer++];
        }

        #endregion

    }
}
