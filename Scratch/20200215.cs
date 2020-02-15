using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;
using Pair = System.Tuple<long, long>;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<long>>;
using static _20200215.Cin;
using static _20200215.Util;

namespace _20200215
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DontAutoFlush();

            // ABC036_C(); 13m
            // AGC038_A(); 140m
            // Tenka1_2017_C(); 60m
            // ARC067_D(); 20m
            Diverta2019_2_B(); //180m

            Flush();
        }

        /// <summary>
        /// B - Picking Up
        /// </summary>
        public static void Diverta2019_2_B()
        {
            long N = rl;
            long[] a, b;
            ReadCols(out a, out b, N);

            var hm = new HashMap<long, HashMap<long, long>>();

            for (int i = 0; i < N-1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    var dx = a[j] - a[i];
                    var dy = b[j] - b[i];
                    hm[dx][dy]++;
                    hm[-dx][-dy]++;
                }
            }

            long cnt = 0;
            foreach(var dx in hm.Keys)
            {
                foreach(var dy in hm[dx].Keys)
                {
                    ChMax(ref cnt, hm[dx][dy]);
                }
            }

            long ans = N - cnt;
            Console.WriteLine(ans);
        }

        /// <summary>
        /// D - Walk and Teleport
        /// </summary>
        public static void ARC067_D()
        {
            long N = rl;
            long A = rl;
            long B = rl;
            long[] X = rla;

            long ans = 0;
            for (int i = 1; i < N; i++)
            {
                long diff = X[i] - X[i-1];
                ans += Math.Min(diff * A, B);
            }

            Console.WriteLine(ans);
        }

        /// <summary>
        /// C - 4/N
        /// </summary>
        public static void Tenka1_2017_C()
        {
            long N = rl;

            for (int h = 1; h <= 3500; h++)
            {
                for (int n = 1; n <= 3500; n++)
                {
                    long hnN = h * n * N;
                    long bunbo = 4 * h * n - n * N - h * N;
                    if (bunbo <= 0)
                        continue;
                    if(hnN % bunbo == 0)
                    {
                        Console.WriteLine("{0} {1} {2}", h, n, hnN/bunbo);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// A - 01 Matrix
        /// </summary>
        public static void AGC038_A()
        {
            long H = rl;
            long W = rl;
            long A = rl;
            long B = rl;

            string s1 = new string('1', (int)A) + new string('0', (int)(W - A));
            string s2 = new string('0', (int)A) + new string('1', (int)(W - A));

            for (int i = 0; i < B; i++)
            {
                Console.WriteLine(s1);
            }
            for (int i = 0; i < H-B; i++)
            {
                Console.WriteLine(s2);
            }
        }

        /// <summary>
        /// C - 座圧
        /// </summary>
        public static void ABC036_C()
        {
            long N = rl;
            long[] A = new long[N];
            for (int i = 0; i < N; i++)
            {
                A[i] = rl;
            }

            var sorted = A.OrderBy(a => a).Distinct().ToArray();
            Dictionary<long, long> dic = new Dictionary<long, long>();
            for (int i = 0; i < sorted.Length; i++)
            {
                dic[sorted[i]] = i;
            }

            foreach(var a in A)
            {
                Console.WriteLine(dic[a]);
            }
        }

    }

    public class HashMap<K,V>:Dictionary<K,V>{V i;static Func<V>j=Expression.Lambda<Func<V>>(Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V a){i=a;}new public V this[K a]{get{V b;if(TryGetValue(a,out b))return b;else return base[a]=i!=null?i:j();}set{base[a]=value;}}}public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public static void DontAutoFlush(){var a=new StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(a);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]a){Array.Sort<T>(a);return a;}public static T[]SortDecend<T>(T[]a){Array.Sort<T>(a);Array.Reverse(a);return a;}public static void Swap<T>(ref T a,ref T b){T c=a;a=b;b=c;}public static int GCD(int a,int b){return(b==0)?a:GCD(b,a%b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static long ModAdd(long a,long b){long c=a+b;if(c>=MOD)return c%MOD;return c;}public static long ModMul(long a,long b){long c=a*b;if(c>=MOD)return c%MOD;return c;}public static void ChModAdd(ref long a,long b){a+=b;if(a>=MOD)a%=MOD;}public static void ChModMul(ref long a,long b){a*=b;if(a>=MOD)a%=MOD;}public static void FillArray<T>(T[]a,T b){int c=a.Length;for(int d=0;d<c;d++)a[d]=b;}public static void FillArray<T>(T[,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);for(int e=0;e<c;e++)for(int f=0;f<d;f++){a[e,f]=b;}}public static void FillArray<T>(T[,,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);int e=a.GetLength(2);for(int f=0;f<c;f++)for(int g=0;g<d;g++){for(int h=0;h<e;h++){a[f,g,h]=b;}}}public static long[]Accumulate(long[]a){long[]b=new long[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}public static double[]Accumulate(double[]a){double[]b=new double[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}}public static class Cin{public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static int ReadInt(){return int.Parse(k());}public static long ReadLong(){return long.Parse(k());}public static double ReadDouble(){return double.Parse(k());}public static string ReadString(){return k();}public static int[]ReadIntArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static void ReadCols(out long[]a,out long[]b,long c){a=new long[c];b=new long[c];for(int d=0;d<c;d++){a[d]=ReadLong();b[d]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long d){a=new long[d];b=new long[d];c=new long[d];for(int e=0;e<d;e++){a[e]=ReadLong();b[e]=ReadLong();c[e]=ReadLong();}}public static int[][]ReadIntTable(int a){i=null;int[][]b=new int[a][];for(int c=0;c<a;c++)b[c]=ReadIntArray();return b;}public static long[][]ReadLongTable(long a){i=null;long[][]b=new long[a][];for(long c=0;c<a;c++)b[c]=ReadLongArray();return b;}static string[]i{get;set;}static int j{get;set;}static string k(){if(i==null||i.Length<=j){i=Console.ReadLine().Split(' ');j=0;}return i[j++];}}
}
