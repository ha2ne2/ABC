using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;
using Pair = System.Tuple<long, long>;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<long>>;
using static _20200213.Cin;
using static _20200213.Util;

namespace _20200213
{
    public class Program
    {
        public static void _Main(string[] args)
        {
            // ABC085_D(); 45m
            // ARC066_C(); 17m
            // ABC003_C(); 15m
            // ABC016_C(); 18m
            // AGC034_B(); 50m
            ABC152_D();
        }

        /// <summary>
        /// D - Handstand 2
        /// </summary>
        public static void ABC152_D()
        {
            long N = rl;
            long[,] table = new long[10, 10];
            for (int i = 0; i <= N; i++)
            {
                int r = i % 10;
                int l = i;
                while (l >= 10)
                {
                    l /= 10;
                }
                table[l, r]++;
            }

            long ans = 0;
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    ans += table[i, j] * table[j, i];
                }
            }

            Console.WriteLine(ans);
        }

        /// <summary>
        /// B - ABC
        /// </summary>
        public static void AGC034_B()
        {
            string S = rs;
            int N = S.Length;
            int r = 0;
            int bc = 0;
            long ans = 0;
            for (int l = 0; l < N - 2; l++)
            {
                if(S[l] == 'A')
                {
                    if(r <= l)
                    {
                        bc = 0;
                        r = l + 1;
                        while(r < N-1)
                        {
                            if (S[r] == 'A')
                            {
                                r++;
                            }
                            else if (S[r] == 'B' && S[r + 1] == 'C')
                            {
                                bc++;
                                r += 2;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    ans += bc;
                }
                else if (S[l] == 'B' && S[l+1]== 'C')
                {
                    bc--;
                }
            }

            Console.WriteLine(ans);
        }

        /// <summary>
        /// C - 友達の友達
        /// </summary>
        public static void ABC016_C()
        {
            long N = rl;
            long M = rl;
            Graph G = new Graph();
            for (int i = 0; i < N; i++)
            {
                G.Add(new List<long>());
            }

            for (int i = 0; i < M; i++)
            {
                long a = rl-1;
                long b = rl-1;
                G[(int)a].Add(b);
                G[(int)b].Add(a);

                G[(int)a].Add(a);
                G[(int)b].Add(b);
            }

            for (int i = 0; i < N; i++)
            {
                HashSet<long> hs = new HashSet<long>();
                foreach (var friend in G[i])
                {
                    foreach(var ffriend in G[(int)friend])
                    {
                        if (G[i].Contains(ffriend))
                            continue;
                        hs.Add(ffriend);
                    }
                }

                Console.WriteLine(hs.Count);
            }
        }

        /// <summary>
        /// C - AtCoderプログラミング講座
        /// </summary>
        public static void ABC003_C()
        {
            long N = rl;
            long K = rl;
            long[] A = rla;

            Sort(A);
            double ans = 0;
            for (int i = (int)(N - K); i < N; i++)
            {
                ans = (ans + A[i]) / 2;
            }

            Console.WriteLine(ans);
        }

        /// <summary>
        /// C - Lining Up
        /// </summary>
        public static void ARC066_C()
        {
            long N = rl;
            long[] A = rla;

            bool even = N % 2 == 0;
            HashMap<long, long> hm = new HashMap<long, long>();
            for (int i = 0; i < N/2; i++)
            {
                hm[i * 2 + (even ? 1 : 2)] = 2;
            }

            if (N % 2 == 1)
                hm[0] = 1;

            for (int i = 0; i < N; i++)
            {
                if (!hm.ContainsKey(A[i]))
                {
                    Console.WriteLine(0);
                    return;
                }
                hm[A[i]]--;
                if(hm[A[i]] < 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            long ans = 1;
            for (int i = 0; i < N/2; i++)
            {
                ChModMul(ref ans, 2);
            }
            Console.WriteLine(ans);
        }

        /// <summary>
        /// D - Katana Thrower
        /// </summary>
        public static void ABC085_D()
        {
            long N = rl;
            long H = rl;
            long[] A, B;
            ReadCols(out A, out B, N);

            SortDecend(B);
            long max = A.Max();
            long count = 0;
            for (int i = 0; i < N; i++)
            {
                if (B[i] > max)
                {
                    H -= B[i];
                    count++;
                    if (H <= 0)
                    {
                        Console.WriteLine(count);
                        return;
                    }
                }
                else
                {
                    break;
                }
            }

            count += (H + max - 1) / max;
            Console.WriteLine(count);
        }
    }

    public class HashMap<K,V>:Dictionary<K,V>{V i;static Func<V>j=Expression.Lambda<Func<V>>(Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V a){i=a;}new public V this[K a]{get{V b;if(TryGetValue(a,out b))return b;else return base[a]=i!=null?i:j();}set{base[a]=value;}}}public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public static void DontAutoFlush(){var a=new StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(a);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]a){Array.Sort<T>(a);return a;}public static T[]SortDecend<T>(T[]a){Array.Sort<T>(a);Array.Reverse(a);return a;}public static void Swap<T>(ref T a,ref T b){T c=a;a=b;b=c;}public static int GCD(int a,int b){return(b==0)?a:GCD(b,a%b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static long ModAdd(long a,long b){long c=a+b;if(c>=MOD)return c%MOD;return c;}public static long ModMul(long a,long b){long c=a*b;if(c>=MOD)return c%MOD;return c;}public static void ChModAdd(ref long a,long b){a+=b;if(a>=MOD)a%=MOD;}public static void ChModMul(ref long a,long b){a*=b;if(a>=MOD)a%=MOD;}public static void FillArray<T>(T[]a,T b){int c=a.Length;for(int d=0;d<c;d++)a[d]=b;}public static void FillArray<T>(T[,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);for(int e=0;e<c;e++)for(int f=0;f<d;f++){a[e,f]=b;}}public static void FillArray<T>(T[,,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);int e=a.GetLength(2);for(int f=0;f<c;f++)for(int g=0;g<d;g++){for(int h=0;h<e;h++){a[f,g,h]=b;}}}public static long[]Accumulate(long[]a){long[]b=new long[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}public static double[]Accumulate(double[]a){double[]b=new double[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}}public static class Cin{public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static int ReadInt(){return int.Parse(k());}public static long ReadLong(){return long.Parse(k());}public static double ReadDouble(){return double.Parse(k());}public static string ReadString(){return k();}public static int[]ReadIntArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static void ReadCols(out long[]a,out long[]b,long c){a=new long[c];b=new long[c];for(int d=0;d<c;d++){a[d]=ReadLong();b[d]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long d){a=new long[d];b=new long[d];c=new long[d];for(int e=0;e<d;e++){a[e]=ReadLong();b[e]=ReadLong();c[e]=ReadLong();}}public static int[][]ReadIntTable(int a){i=null;int[][]b=new int[a][];for(int c=0;c<a;c++)b[c]=ReadIntArray();return b;}public static long[][]ReadLongTable(long a){i=null;long[][]b=new long[a][];for(long c=0;c<a;c++)b[c]=ReadLongArray();return b;}static string[]i{get;set;}static int j{get;set;}static string k(){if(i==null||i.Length<=j){i=Console.ReadLine().Split(' ');j=0;}return i[j++];}}
}

