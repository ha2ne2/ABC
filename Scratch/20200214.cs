using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;
using Pair = System.Tuple<long, long>;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<long>>;
using static _20200214.Cin;
using static _20200214.Util;

namespace _20200214
{
    public class Program
    {
        public static void _Main(string[] args)
        {
            // ABC006_B(); 12min
            // ABC075_C(); 20min
            // ABC028_D(); 25min
            // ABC124_D(); 30min
            ABC002_D();
        }

        public static void ABC002_D()
        {
            long N = rl;
            long M = rl;
            long[] rel = new long[N];
            for (int i = 0; i < N; i++)
            {
                rel[i] = 1 << i;
            }
            for (int i = 0; i < M; i++)
            {
                long a = rl - 1;
                long b = rl - 1;
                rel[a] |= (long)1 << (int)b;
                rel[b] |= (long)1 << (int)a;
            }

            long max = 1;
            for (int mask = 0; mask < 1 << (int)N; mask++)
            {
                List<long> ps = new List<long>();
                for (int i = 0; i < N; i++)
                {
                    if (((mask >> i) & 1) == 1)
                        ps.Add(i);
                }

                if (ps.Count <= max)
                    continue;

                bool ok = true;
                foreach (var p in ps)
                {
                    if ((rel[p] & mask) != mask)
                    {
                        ok = false;
                        break;
                    }                        
                }

                if(ok)
                    max = ps.Count;
            }

            Console.WriteLine(max);

        }

        /// <summary>
        /// D - Handstand
        /// </summary>
        public static void ABC124_D()
        {
            long N = rl;
            long K = rl;
            string S = rs;
            List<long> a = new List<long>();
            if (S[0] == '0')
                a.Add(0);
            for (int i = 0; i < N;)
            {
                int j = i;
                while (j < N && S[j] == S[i])
                    j++;
                a.Add(j - i);
                i = j;
            } 
            if (S[S.Length - 1] == '0')
                a.Add(0);
            var len = a.Count;
            var acc = Accumulate(a.ToArray());
            long ans = 0;
            if (2 * K + 1 > len)
                ans = acc[len];
            for (int i = 0; i + 2 * K + 1 <= len; i+=2)
            {
                ChMax(ref ans, acc[i + 2 * K + 1] - acc[i]);
            }
            Console.WriteLine(ans);
        }

        /// <summary>
        /// D - 乱数生成
        /// </summary>
        public static void ABC028_D()
        {
            long N = rl;
            long K = rl;

            double ans = 0;
            // K が 3個
            ans += 1;

            // K が 2個
            ans += (N - 1) * 3;

            // K が 1個
            ans += (K - 1) * (N - K) * 3 * 2;

            ans /= N;
            ans /= N;
            ans /= N;

            Console.WriteLine(ans);
        }

        /// <summary>
        /// C - Bridge
        /// </summary>
        public static void ABC075_C()
        {
            long N = rl;
            long M = rl;
            Pair[] edges = new Pair[M];
            for (int i = 0; i < M; i++)
            {
                edges[i] = new Pair(rl - 1, rl - 1);
            }
            List<long>[] edgeIndexes = new List<long>[N];
            for (int i = 0; i < N; i++)
            {
                edgeIndexes[i] = new List<long>();
            }
            for (int i = 0; i < M; i++)
            {
                edgeIndexes[edges[i].Item1].Add(i);
                edgeIndexes[edges[i].Item2].Add(i);
            }

            long cnt = 0;
            for (int i = 0; i < M; i++)
            {
                bool[] vis = new bool[N];
                Queue<long> q = new Queue<long>();
                q.Enqueue(0);
                while (q.Any())
                {
                    long v = q.Dequeue();
                    vis[v] = true;
                    foreach (var idx in edgeIndexes[v])
                    {
                        if (idx == i)
                            continue;
                        long v2 = edges[idx].Item1 + edges[idx].Item2 - v;
                        if (vis[v])
                            continue;
                        q.Enqueue(v2);
                    }
                }

                if (vis.Any(v => !v))
                    cnt++;
            }

            Console.WriteLine(cnt);
        }

        /// <summary>
        /// B - トリボナッチ数列
        /// </summary>
        public static void ABC006_B()
        {
            long N = rl;
            long[] table = new long[3];
            table[0] = 0;
            table[1] = 0;
            table[2] = 1;
            for (int i = 3; i < N; i++)
            {
                table[i % 3] = (table[0] + table[1] + table[2]) % 10007;
            }

            Console.WriteLine(table[(N-1)%3]);
        }
    }

    public class HashMap<K,V>:Dictionary<K,V>{V i;static Func<V>j=Expression.Lambda<Func<V>>(Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V a){i=a;}new public V this[K a]{get{V b;if(TryGetValue(a,out b))return b;else return base[a]=i!=null?i:j();}set{base[a]=value;}}}public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public static void DontAutoFlush(){var a=new StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(a);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]a){Array.Sort<T>(a);return a;}public static T[]SortDecend<T>(T[]a){Array.Sort<T>(a);Array.Reverse(a);return a;}public static void Swap<T>(ref T a,ref T b){T c=a;a=b;b=c;}public static int GCD(int a,int b){return(b==0)?a:GCD(b,a%b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static long ModAdd(long a,long b){long c=a+b;if(c>=MOD)return c%MOD;return c;}public static long ModMul(long a,long b){long c=a*b;if(c>=MOD)return c%MOD;return c;}public static void ChModAdd(ref long a,long b){a+=b;if(a>=MOD)a%=MOD;}public static void ChModMul(ref long a,long b){a*=b;if(a>=MOD)a%=MOD;}public static void FillArray<T>(T[]a,T b){int c=a.Length;for(int d=0;d<c;d++)a[d]=b;}public static void FillArray<T>(T[,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);for(int e=0;e<c;e++)for(int f=0;f<d;f++){a[e,f]=b;}}public static void FillArray<T>(T[,,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);int e=a.GetLength(2);for(int f=0;f<c;f++)for(int g=0;g<d;g++){for(int h=0;h<e;h++){a[f,g,h]=b;}}}public static long[]Accumulate(long[]a){long[]b=new long[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}public static double[]Accumulate(double[]a){double[]b=new double[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}}public static class Cin{public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static int ReadInt(){return int.Parse(k());}public static long ReadLong(){return long.Parse(k());}public static double ReadDouble(){return double.Parse(k());}public static string ReadString(){return k();}public static int[]ReadIntArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static void ReadCols(out long[]a,out long[]b,long c){a=new long[c];b=new long[c];for(int d=0;d<c;d++){a[d]=ReadLong();b[d]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long d){a=new long[d];b=new long[d];c=new long[d];for(int e=0;e<d;e++){a[e]=ReadLong();b[e]=ReadLong();c[e]=ReadLong();}}public static int[][]ReadIntTable(int a){i=null;int[][]b=new int[a][];for(int c=0;c<a;c++)b[c]=ReadIntArray();return b;}public static long[][]ReadLongTable(long a){i=null;long[][]b=new long[a][];for(long c=0;c<a;c++)b[c]=ReadLongArray();return b;}static string[]i{get;set;}static int j{get;set;}static string k(){if(i==null||i.Length<=j){i=Console.ReadLine().Split(' ');j=0;}return i[j++];}}
}
