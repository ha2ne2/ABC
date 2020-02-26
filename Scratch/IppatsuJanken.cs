using System;

namespace Scratch
{
    public class Janken
    {
        //public static void Main()
        //{
        //    JankenTest();
        //}

        public static void JankenTest()
        {
            int testCount = 1000000;
            int nMax = 100;
            for (int n = 2; n <= nMax; n++)
            {
                long[] winCount = new long[6];
                Console.Write($"{n}人勝負 ");
                for (int i = 0; i < testCount; i++)
                {
                    winCount[IppatsuJanken(n)]++;
                }
                for (int i = 0; i < 6; i++)
                {
                    Console.Write("{0,4:0.0}% ", (winCount[i] * 100 / (double)testCount));
                }
                Console.WriteLine();
            }

        }

        static Random Random = new Random();
        public static int IppatsuJanken(int n)
        {
            int[] handCount = new int[5];
            for (int i = 0; i < n; i++)
            {
                handCount[Random.Next(5)]++;
            }

            int max = -1;
            for (int i = 0; i < 5; i++)
            {
                if (handCount[i] == 1)
                    max = i;
            }

            if (max == 4 && handCount[0] == 1)
            {
                return 1;
            }
            else
            {
                return max + 1;
            }
        }
    }
}
