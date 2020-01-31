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
using Pair = System.Tuple<long, long>;

namespace DPMatome
{
    public class Program
    {
        public static void Main(string[] args)
        {
        START:
            // A(); 20m
            // B();  7m
            // C(); 42m
            // D(); 70m
            //----------------------------- 2020/01/28
            // E();  70m -> 13m -> 5m
            // F(); 127m -> 27m -> 3m
            // G(); 160m -> 11m -> 6m
            // H();  20m -> 4m
            // I();  70m -> 4m
            //----------------------------- 2020/01/30
            // J(); 120m -> 13m -> 8m
            // K();  25m ->  3m
            // L();  65m ->  6m -> 3m
            // M();  80m ->  8m -> 3m
            // N(); 130m ->
            // O();  50m -> 10m
            //----------------------------- 2020/01/31
            // P();  80m -> 15m -> 6m
            Q();

#if DEBUG
            goto START;
#endif
        }

        public static void Q()
        {
            long N = rl;
            long[] h = rla;
            long[] a = rla;

            long[] memo = new long[N];
            FillArray(memo, -1);
            
            Func<long,long> rec = null;
            rec = (i) =>
            {
                if (memo[i] != -1) return memo[i];

                long res = 0;
                for (int j = (int)i+1; j < N; j++)
                {
                    if (h[i] <= h[j])
                        ChMax(ref res, rec(j));
                }

                memo[i] = res + a[i];
                return memo[i];
            };

            long ans = 0;
            for (int i = 0; i < N; i++)
            {
                ChMax(ref ans, rec(i));
            }

            Console.WriteLine(ans);
        }

        public static void P()
        {
            long N = rl;
            long[] xs = new long[N - 1];
            long[] ys = new long[N - 1];
            for (int i = 0; i < N-1; i++)
            {
                xs[i] = rl - 1;
                ys[i] = rl - 1;
            }

            List<List<long>> G = new List<List<long>>();
            for (int i = 0; i < N; i++)
            {
                G.Add(new List<long>());
            }
            for (int i = 0; i < N-1; i++)
            {
                G[(int)xs[i]].Add(ys[i]);
                G[(int)ys[i]].Add(xs[i]);
            }

            long[,] memo = new long[N, 2];
            FillArray(memo, -1);

            Func<long, long, long, long> rec = null;
            rec = (from, v, w) =>
            {
                if (memo[v, w] != -1) return memo[v, w];

                long res = 1;
                foreach(long nv in G[(int)v])
                {
                    if (nv == from)
                        continue;
                    long res1 = 0;
                    if (w == 0)
                        res1 = rec(v, nv, 1);
                    long res2 = rec(v, nv, 0);

                    res = ModMul(res, ModAdd(res1, res2));
                }

                memo[v, w] = res;
                return res;
            };

            long ans = ModAdd(rec(-1, 0, 0), rec(-1, 0, 1));
            Console.WriteLine(ans);
        }













        public static void P2()
        {
            long N = ReadInt();
            long[] xs = new long[N - 1];
            long[] ys = new long[N - 1];
            for (int i = 0; i < N - 1; i++)
            {
                xs[i] = ReadLong() - 1;
                ys[i] = ReadLong() - 1;
            }

            List<List<long>> G = new List<List<long>>();
            for (int i = 0; i < N; i++)
            {
                G.Add(new List<long>());
            }
            for (int i = 0; i < N - 1; i++)
            {
                G[(int)xs[i]].Add(ys[i]);
                G[(int)ys[i]].Add(xs[i]);
            }

            long[,] memo = new long[N, 2];
            FillArray(memo, -1);

            Func<long, long, long, long> rec = null;
            rec = (from, v, w) =>
            {
                if (memo[v, w] != -1) return memo[v, w];

                long res = 1;
                foreach(var nv in G[(int)v])
                {
                    if (nv == from)
                        continue;

                    long res1 = 0;
                    if (w == 0)
                        res1 = rec(v, nv, 1);
                    long res2 = rec(v, nv, 0);

                    res = (res * ((res1 + res2) % MOD)) % MOD;
                }

                memo[v, w] = res;
                return res;
            };

            long ans = (rec(-1, 0, 0) + rec(-1, 0, 1)) % MOD;
            Console.WriteLine(ans);

        }

        public static void O()
        {
            long N = rl;
            long[][] table = ReadLongTable(N);

            long[] memo = new long[1 << (int)N];
            FillArray(memo, -1);

            Func<long, long, long> dfs = null;
            dfs = (state, c) =>
            {
                if (memo[state] != -1) return memo[state];
                if (state == 0)
                {
                    memo[state] = 1;
                    return 1;
                }

                long res = 0;
                for (int i = 0; i < N; i++)
                {
                    if (((state & (1 << i)) == (1 << i)) &&
                        table[c][i] == 1)
                    {
                        res = (res + dfs(state ^ (1 << i), c + 1)) % MOD;
                    }
                }

                memo[state] = res;
                return res;
            };

            Console.WriteLine(dfs((1 << (int)N) - 1, 0));
        }

        public static void O1()
        {
            long N = rl;
            long[][] table = ReadLongTable(N);

            long[] memo = new long[1 << (int)N];
            FillArray(memo, -1);

            Func<long, long, long> dfs = null;
            dfs = (state, c) =>
            {
                if (memo[state] != -1) return memo[state];
                if (state == 0)
                {
                    memo[state] = 1;
                    return 1;
                }

                long res = 0;
                for (int i = 0; i < N; i++)
                {
                    if (((state & (1 << i)) == (1 << i))
                        && table[c][i] == 1)
                    {
                        res = (res + dfs(state ^ (1 << i), c + 1)) % MOD;
                    }
                }
                memo[state] = res;
                return res;
            };

            Console.WriteLine(dfs((1 << (int)N) - 1, 0));

        }

        public static void N()
        {
            long N = rl;
            long[] A = rla;

            long[,] dp = new long[N + 1, N + 1];
            FillArray(dp, INF);

            long[] acc = new long[N + 1];
            for (int i = 0; i < N; i++)
            {
                acc[i + 1] = acc[i] + A[i];
            }

            Func<int, int, long> rec = null;
            rec = (l, r) =>
            {
                if (dp[l, r] != INF) return dp[l, r];

                if(l + 1 == r)
                {
                    dp[l, r] = 0;
                    return 0;
                }

                long res = INF;
                for (int i = l + 1; i < r; i++)
                {
                    ChMin(ref res, rec(l, i) + rec(i, r));
                }
                res += acc[r] - acc[l];
                dp[l, r] = res;
                return res;
            };

            Console.WriteLine(rec(0,(int)N));
        }

        public static void N2()
        {
            long N = rl;
            long[] A = rla;

            long[,] dp = new long[N + 1, N + 1];

            long[] acc = new long[N + 1];
            for (int i = 1; i <= N; i++)
            {
                acc[i] = acc[i - 1] + A[i - 1] ;
            }

            for (int w = 2; w <= N; w++)
            {
                for (int l = 0; l + w <= N; l++)
                {
                    int r = l + w;
                    long ans = INF;
                    for (int m = l + 1; m < r; m++)
                    {
                        ChMin(ref ans, dp[l, m] + dp[m, r]);
                    }
                    dp[l, r] = ans + acc[r] - acc[l];
                }
            }

            Console.WriteLine(dp[0, N]);
        }

        public static void M()
        {
            long N = rl;
            long K = rl;
            long[] A = rla;

            long[,] dp = new long[N + 1, K + 1];
            for (int i = 0; i <= N; i++)
            {
                dp[i, 0] = 1;
            }

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    dp[i, j] = (dp[i - 1, j] + dp[i, j - 1]) % MOD;

                    if (j - A[i - 1] - 1 >= 0)
                        dp[i, j] = (
                            dp[i, j]
                            + MOD
                            - dp[i - 1, j - A[i - 1] - 1])
                            % MOD;
                }
            }

            Console.WriteLine(dp[N,K]);
        }



        public static void M1()
        {
            long N = rl;
            long K = rl;
            long[] A = rla;

            long[,] dp = new long[N + 1, K + 1];
            for (int i = 0; i <= N; i++)
            {
                dp[i, 0] = 1;
            }

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    dp[i, j] = (dp[i - 1, j] + dp[i, j - 1]) % MOD;

                    if (j - A[i - 1] - 1 >= 0)
                        dp[i, j] =
                            (dp[i, j]
                            + MOD
                            - dp[i - 1, j - A[i - 1] - 1])
                            % MOD;
                }
            }

            long ans = dp[N, K];
            Console.WriteLine(ans);

        }

        public static void L()
        {
            long N = rl;
            long[] A = rla;

            long[,] dp = new long[N + 1, N + 1];
            FillArray(dp, -1);

            Func<long, long, long> rec = null;
            rec = (l, r) =>
            {
                if (dp[l, r] != -1) return dp[l, r];

                if (l == r)
                {
                    dp[l, r] = 0;
                    return 0;
                }

                bool turnOfA = ((N - r + l) % 2 == 0);

                long res;
                if (turnOfA)
                {
                    res = Max(
                            rec(l + 1, r) + A[l],
                            rec(l, r - 1) + A[r - 1]
                        );
                }
                else
                {
                    res = Min(
                            rec(l + 1, r) - A[l],
                            rec(l, r - 1) - A[r - 1]
                        );
                }

                dp[l, r] = res;
                return res;
            };

            rec(0, N);
            long ans = dp[0, N];
            Console.WriteLine(ans);
        }

        public static void L1()
        {
            long N = rl;
            long[] A = rla;

            long[,] dp = new long[N + 1, N + 1];
            FillArray(dp, -1);

            Func<long, long, long> rec = null;
            rec = (l, r) =>
            {
                if (dp[l, r] != -1) return dp[l, r];

                if (l == r)
                {
                    dp[l, r] = 0;
                    return 0;
                }

                bool turnOfA = ((N - r + l) % 2 == 0);

                long res;
                if (turnOfA)
                {
                    res = Max(
                            rec(l + 1, r) + A[l],
                            rec(l, r - 1) + A[r - 1]
                        );
                }
                else
                {
                    res = Min(
                            rec(l + 1, r) - A[l],
                            rec(l, r - 1) - A[r - 1]
                        );
                }

                dp[l, r] = res;
                return res;
            };

            rec(0, N);
            long ans = dp[0, N];
            Console.WriteLine(ans);
        }

        public static void K()
        {
            long N = rl;
            long K = rl;
            long[] A = rla;

            bool[] dp = new bool[K + 1];

            for (int i = 0; i <= K; i++)
            {
                bool res = false;
                for (int j = 0; j < N; j++)
                {
                    if (i - A[j] < 0) break;
                    if (dp[i - A[j]] == false)
                    {
                        res = true;
                        break;
                    }
                }
                dp[i] = res;
            }

            string ans = dp[K] ? "First" : "Second";
            Console.WriteLine(ans);
        }

        public static void K_()
        {
            long N = rl;
            long K = rl;
            long[] A = rla;

            bool[] dp = new bool[K + 1];
            for (int i = 0; i <= K; i++)
            {
                bool res = false;
                for (int j = 0; j < N; j++)
                {
                    if (i - A[j] < 0) break;
                    if (dp[i - A[j]] == false)
                    {
                        res = true;
                        break;
                    }                        
                }
                dp[i] = res;
            }

            bool ans = dp[K];
            Console.WriteLine(ans ? "First" : "Second");
        }

        public static void J()
        {
            long N = rl;
            long[] A = rla;

            double[,,] dp = new double[N + 1, N + 1, N + 1];
            FillArray(dp, -1);

            Func<int, int, int, double> rec = null;
            rec = (i, j, k) =>
            {
                if (dp[i, j, k] != -1) return dp[i, j, k];
                if (i == 0 && j == 0 && k == 0) return 0;

                double res = 0;
                if (0 < i) res += rec(i - 1, j, k) * i;
                if (0 < j) res += rec(i + 1, j - 1, k) * j;
                if (0 < k) res += rec(i, j + 1, k - 1) * k;
                res += N;
                res /= i + j + k;
                dp[i, j, k] = res;

                return res;
            };

            int[] sara = new int[3];
            foreach (var a in A)
            {
                sara[a - 1]++;
            }

            double ans = rec(sara[0], sara[1], sara[2]);
            Console.WriteLine(ans);
        }
        
        public static void J_()
        {
            long N = rl;
            long[] A = rla;

            double[,,] dp = new double[N+1,N+1,N+1];
            FillArray(dp, -1);

            Func<int, int, int, double> rec = null;
            rec = (int i, int j, int k) =>
            {
                if (dp[i, j, k] != -1) return dp[i, j, k];
                if (i == 0 && j == 0 && k == 0) return 0;

                double res = 0;
                if (0 < i) res += rec(i - 1, j, k) * i;
                if (0 < j) res += rec(i + 1, j - 1, k) * j;
                if (0 < k) res += rec(i, j + 1, k - 1) * k;
                res += N;
                res /= i + j + k;
                dp[i, j, k] = res;
                return res;
            };

            int[] sara = new int[3];
            foreach (var a in A)
            {
                sara[a - 1]++;
            }
            
            double ans = rec(sara[0], sara[1], sara[2]);
            Console.WriteLine(ans);
        }

        public static void I()
        {
            long N = rl;
            double[] ps = rda;

            double[,] dp = new double[N + 1, N + 1];
            dp[0, 0] = 1;

            for (int i = 0; i < N; i++) 
            {
                for (int j = 0; j < N; j++)
                {
                    dp[i + 1, j] += dp[i, j] * (1 - ps[i]);
                    dp[i + 1, j + 1] = dp[i, j] * ps[i];
                }
            }

            long iMax = N / 2;
            double ans = 1.0;
            for (int i = 0; i <= iMax; i++)
            {
                ans -= dp[N,i];
            }

            WriteLine(ans);
        }
        
        public static void H()
        {
            long H = rl;
            long W = rl;
            string[] table = new string[H];
            for(int i = 0; i < H; i++)
            {
                table[i] = ReadString();
            }

            long[,] dp = new long[H, W];
            dp[0, 0] = 1;

            for(int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    if (table[i][j] == '#')
                        continue;

                    if (i == 0)
                        dp[i, j] = dp[i, j - 1];
                    else if (j == 0)
                        dp[i, j] = dp[i - 1, j];
                    else
                        dp[i, j] = (dp[i - 1, j] + dp[i, j - 1]) % MOD;
                }
            }

            WriteLine(dp[H - 1, W - 1]);
        }
        
        public static void G()
        {
            long N = ReadLong();
            long M = ReadLong();
            List<List<long>> G = new List<List<long>>();
            for (int i = 0; i < N; i++)
            {
                G.Add(new List<long>());
            }
            for (int i = 0; i < M; i++)
            {
                long from = ReadLong() - 1;
                long to = ReadLong() - 1;
                G[(int)from].Add(to);
            }

            long[] dp = new long[N];
            FillArray(dp, -1);

            Func<long, long> rec = null;
            rec = (long v) =>
            {
                if (dp[v] != -1) return dp[v];

                if (!G[(int)v].Any())
                    return dp[v] = 0;

                long res = 0;
                foreach (var nv in G[(int)v])
                {
                    ChMax(ref res, rec(nv) + 1);
                }

                return dp[v] = res;
            };

            long ans = 0;
            for (int i = 0; i < N; i++)
            {
                ChMax(ref ans, rec(i));
            }

            WriteLine(ans);
        }


        public static void F()
        {
            string s = ReadString();
            string t = ReadString();

            int n = s.Length;
            int m = t.Length;

            long[,] dp = new long[n + 1, m + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Max(dp[i, j - 1], dp[i - 1, j]);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            int x = n;
            int y = m;
            while (0 < x && 0 < y)
            {
                if (dp[x, y] == dp[x - 1, y])
                    x--;
                else if (dp[x, y] == dp[x, y - 1])
                    y--;
                else
                {
                    x--;
                    y--;
                    sb.Append(s[x]);
                }
            }

            string ans = string.Concat(sb.ToString().Reverse());
            WriteLine(ans);
        }

        public static void E()
        {
            long N = ReadLong();
            long W = ReadLong();
            long[] ws, vs;
            ReadArrays(out ws, out vs, N);

            long maxValue = 100000;
            long[,] dp = new long[N + 1, maxValue + 1];
            FillArray(dp, INF);

            dp[0, 0] = 0;

            for(int i = 0; i < N; i++)
            {
                for (int j = 0; j <= maxValue; j++)
                {
                    if (j - vs[i] >= 0)
                    {
                        dp[i + 1, j] = Min(
                            dp[i,j],
                            dp[i,j-vs[i]] + ws[i]
                            );
                    }
                    else
                    {
                        dp[i + 1, j] = dp[i, j];
                    }
                }
            }

            long ans = 0;
            for(int i = 0; i <= maxValue; i++)
            {
                if (dp[N, i] <= W)
                    ans = i;
            }

            WriteLine(ans);
        }
        
        class Jewel
        {
            public long w { get; set; }
            public long v { get; set; }
        }

        private static void D()
        {
            long N = ReadLong();
            long W = ReadLong();
            Jewel[] jewels = new Jewel[N];
            for (int i = 0; i < N; i++)
            {
                var j = new Jewel();
                j.w = ReadLong();
                j.v = ReadLong();
                jewels[i] = j;
            }

            long[,] dp = new long[N + 1, W + 1];

            for (int i = 0; i < N; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (w < jewels[i].w)
                    {
                        dp[i + 1, w] = dp[i, w];
                    }
                    else
                    {
                        dp[i+1, w] = Max(
                            dp[i, w],
                            dp[i, w - jewels[i].w] + jewels[i].v);
                    }
                }
            }

            WriteLine(dp[N,W]);
        }

        private static void C()
        {
            long N = ReadLong();
            long[] A = new long[N];
            long[] B = new long[N];
            long[] C = new long[N];

            for (int i = 0; i < N; i++)
            {
                A[i] = ReadLong();
                B[i] = ReadLong();
                C[i] = ReadLong();
            }

            long[,] dp = new long[N, 3];
            dp[0, 0] = A[0];
            dp[0, 1] = B[0];
            dp[0, 2] = C[0];

            for (int i = 0; i < N-1; i++)
            {
                int ni = i + 1;

                // Aからの遷移
                dp[ni, 1] = Max(dp[ni, 1], dp[i, 0] + B[ni]);
                dp[ni, 2] = Max(dp[ni, 2], dp[i, 0] + C[ni]);

                // Bからの遷移
                dp[ni, 0] = Max(dp[ni, 0], dp[i, 1] + A[ni]);
                dp[ni, 2] = Max(dp[ni, 2], dp[i, 1] + C[ni]);

                // Cからの遷移
                dp[ni, 0] = Max(dp[ni, 0], dp[i, 2] + A[ni]);
                dp[ni, 1] = Max(dp[ni, 1], dp[i, 2] + B[ni]);
            }

            long ans = Max(Max(dp[N - 1, 0], dp[N - 1, 1]), dp[N - 1, 2]);

            WriteLine(ans);
        }

       
        private static void B()
        {
            long N = ReadLong();
            long K = ReadLong();
            long[] H = ReadLongArray();

            long[] dp = new long[N];

            for (int i = 0; i < N; i++)
                dp[i] = long.MaxValue;

            dp[0] = 0;

            for (int i = 0; i < N; i++)
            {
                if (dp[i] == long.MaxValue) continue;
                for (int j = 1; j <= K; j++)
                {
                    if (i + j < N)
                        dp[i + j] = Min(dp[i + j], dp[i] + Abs(H[i] - H[i + j]));
                }
            }

            WriteLine(dp[N - 1]);
        }

        private static void A()
        {
            long N = ReadLong();
            long[] H = ReadLongArray();

            long[] dp = new long[N];

            for (int i = 0; i < N; i++)
                dp[i] = long.MaxValue;

            dp[0] = 0;

            for(int i = 0; i < N; i++)
            {
                if (dp[i] == long.MaxValue) continue;
                if (i + 1 < N)
                    dp[i + 1] = Min(dp[i + 1], dp[i] + Abs(H[i] - H[i + 1]));

                if (i + 2 < N)
                    dp[i + 2] = Min(dp[i + 2], dp[i] + Abs(H[i] - H[i + 2]));
            }

            WriteLine(dp[N-1]);
        }
    }
}

namespace Ha2ne2Util
{
    public static class Cin
    {
        private static string[] Tokens { get; set; }

        private static int Pointer { get; set; }

        public static string Next()
        {
            if (Tokens == null || Tokens.Length <= Pointer)
            {
                Tokens = Console.ReadLine().Split(' ');
                Pointer = 0;
            }

            return Tokens[Pointer++];
        }

        public static int ReadInt()
        {
            return int.Parse(Next());
        }

        public static long rl => ReadLong();
        public static long[] rla => ReadLongArray();
        public static double rd => ReadDouble();
        public static double[] rda => ReadDoubleArray();

        public static long ReadLong()
        {
            return long.Parse(Next());
        }

        public static double ReadDouble()
        {
            return double.Parse(Next());
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

        public static void ReadArrays(out long[] a, out long[] b, long N)
        {
            a = new long[N];
            b = new long[N];
            for(int i = 0; i < N; i++)
            {
                a[i] = ReadLong();
                b[i] = ReadLong();
            }
        }

        public static void ReadArrays(out long[] a, out long[] b, out long[] c, long N)
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
        public static long ModAdd(long a, long b)
        {
            long res = a + b;
            if (res >= MOD)
                return res % MOD;
            return res;
        }
        public static long ModMul(long a, long b)
        {
            long res = a * b;
            if (res >= MOD)
                return res % MOD;
            return res;
        }

        public static void ModAddEqual(ref long a, long b)
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
