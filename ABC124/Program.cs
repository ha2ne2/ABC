using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC124
{
    class Program
    {
        static void Main(string[] args)
        {
            //Buttons(); // 8min
            //GreatOceanView(); // 15min
            //ColoringColorfully(); // 32min
            Handstand();
        }

        static void Handstand()
        {
            int[] tmp = ReadIntArray();
            int n = tmp[0];
            int k = tmp[1];

            bool[] xs = ReadBoolArray();

            List<int> ary = new List<int>();

            if (xs[0] == false)
            {
                ary.Add(0);
            }

            // 連続する個数のリストに変換する
            for (int i = 0; i < n;)
            {
                int j = i;
                while (j < n && xs[j] == xs[i])
                    j++;

                ary.Add(j - i);
                i = j;
            }

            if (xs[n - 1] == false)
            {
                ary.Add(0);
            }

            // 累積和を作る
            int len = ary.Count() + 1;
            int[] cusum = new int[len];
            for (int i = 0; i < len - 1; i++)
            {
                cusum[i + 1] = cusum[i] + ary[i];
            }

            // 答えを出す
            int ans = 0;
            for (int i = 0; i < len; i += 2)
            {
                int left = i;
                int right = Math.Min(len - 1, i + k * 2 + 1);
                ans = Math.Max(ans, cusum[right] - cusum[left]);
            }

            Console.WriteLine(ans);
        }

        static void ColoringColorfully()
        {
            bool[] xs = ReadBoolArray();

            int n = xs.Length;

            int ans = 0;

            for(int i = 0; i < n; i++)
            {
                if (xs[i] == (i % 2 == 0))
                {
                    ans++;
                }
            }

            ans = Math.Min(ans, n - ans);

            Console.WriteLine(ans);
        }

        static void GreatOceanView()
        {
            int n = ReadInt();
            int[] xs = ReadIntArray();

            int ans = 0;
            int max = 0;

            for(int i = 0; i < n; i++)
            {
                if (max <= xs[i])
                {
                    max = xs[i];
                    ans++;
                }
            }

            Console.WriteLine(ans);
        }

        static void Buttons()
        {
            int[] xs = ReadIntArray();

            int ans = 0;

            for(int i = 0; i < 2; i++)
            {
                if (xs[0] > xs[1])
                {
                    ans += xs[0]--;
                }
                else
                {
                    ans += xs[1]--;
                }
            }

            Console.WriteLine(ans);
        }

        public static bool[] ReadBoolArray()
        {
            return Console.ReadLine().Select(c => c == '1').ToArray();
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
}
