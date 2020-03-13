using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static _20200227.Cin;
using static _20200227.Util;
using Pair = _20200227.VTuple<long, long>;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<long>>;
using System.Text;

namespace _20200227
{
    public class Program
    {
        public static void _Main(string[] args)
        {
            // Abc089_B(); 4m
            // Arc090_A(); 10m
            // Abc133_C(); 24m
            // Abc075_C(); 42m
            // Agc024_C();

            Abc023_D();
        }

        public static void Abc023_D()
        {
            long N = rl;
            long[] H, S;
            ReadCols(out H, out S, N);

            Func<long, bool> check = (score) =>
            {
                long[] tmp = new long[N];
                for (int i = 0; i < N; i++)
                {
                    if(score - H[i] < 0)
                    {
                        return false;
                    }

                    tmp[i] = (score - H[i]) / S[i];
                }

                Sort(tmp);
                for (int i = 0; i < N; i++)
                {
                    if(tmp[i] < i)
                    {
                        return false;
                    }
                }

                return true;
            };

            long ok = long.MaxValue / 2;
            long ng = -1;
            while(Abs(ok-ng) != 1)
            {
                long mid = (ok + ng) / 2;
                if (check(mid))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }

            Console.WriteLine(ok);
        }

        public static void Agc024_C()
        {
            long N = rl;
            long[] A = new long[N];
            for (int i = 0; i < N; i++)
            {
                A[i] = rl;
            }

            if (A[0] != 0)
            {
                Console.WriteLine(-1);
                return;
            }

            long ans = 0;
            for (int i = 1; i < N; i++)
            {
                if (A[i] - A[i-1] > 1)
                {
                    Console.WriteLine(-1);
                    return;
                }

                if (A[i] == A[i-1] + 1)
                {
                    ans += 1;
                }
                else
                {
                    ans += A[i];
                }
                
            }
            Console.WriteLine(ans);
            
        }

        public static void Abc075_C()
        {
            long N = rl;
            long M = rl;
            Pair[] edges = new Pair[M];
            List<long>[] edgeIndexes = new List<long>[N];
            for (int i = 0; i < N; i++)
            {
                edgeIndexes[i] = new List<long>();
            }
            for (int i = 0; i < M; i++)
            {
                long a = rl - 1;
                long b = rl - 1;
                edges[i] = new Pair(a, b);
                edgeIndexes[a].Add(i);
                edgeIndexes[b].Add(i);
            }

            long ans = 0;
            for (int skipEdge = 0; skipEdge < M; skipEdge++)
            {
                bool[] vis = new bool[N];
                Queue<long> q = new Queue<long>();
                q.Enqueue(0);

                while (q.Any())
                {
                    var v = q.Dequeue();
                    vis[v] = true;

                    foreach (var ei in edgeIndexes[v])
                    {
                        if (ei == skipEdge)
                            continue;
                        var e = edges[ei];
                        var nv = e.First + e.Second - v;
                        if(!vis[nv])                       
                            q.Enqueue(nv);
                    }
                }

                if (vis.Any(b => !b))
                    ans++;
            }

            Console.WriteLine(ans);

        }

        public static void Abc133_C()
        {
            long L = rl;
            long R = rl;

            if (R - L + 1 >= 2019)
            {
                Console.WriteLine(0);
            }
            else
            {
                long min = INF;
                for (int l = (int)L; l < R; l++)
                {
                    for (int r = l+1; r <= R; r++)
                    {
                        ChMin(ref min, ((l % 2019) * (r % 2019)) % 2019);
                    }
                }

                Console.WriteLine(min);
            }
        }

        public static void Arc090_A()
        {
            long N = rl;
            long[] A = rla;
            long[] B = rla;
            A = Accumulate(A);
            B = Accumulate(B);

            long max = 0;
            for (int i = 1; i <= N; i++)
            {
                ChMax(ref max, A[i] + B[N] - B[i - 1]);
            }

            Console.WriteLine(max);
        }

        public static void Abc089_B()
        {
            long N = rl;
            HashSet<string> hs = new HashSet<string>();
            for (int i = 0; i < N; i++)
            {
                hs.Add(rs);
            }

            if (hs.Count == 3)
            {
                Console.WriteLine("Three");
            }
            else
            {
                Console.WriteLine("Four");
            }
        }

    }

    public struct VTuple<T1,T2>:IComparable<VTuple<T1,T2>>,IEquatable<VTuple<T1,T2>>{public T1 First;public T2 Second;public VTuple(T1 a,T2 b){First=a;Second=b;}public int CompareTo(VTuple<T1,T2>a){int b=Comparer<T1>.Default.Compare(First,a.First);if(b!=0)return b;return Comparer<T2>.Default.Compare(Second,a.Second);}public override bool Equals(object a){return a is VTuple<T1,T2>&&Equals((VTuple<T1,T2>)a);}public bool Equals(VTuple<T1,T2>a){return EqualityComparer<T1>.Default.Equals(First,a.First)&&EqualityComparer<T2>.Default.Equals(Second,a.Second);}public override int GetHashCode(){int a=First!=null?First.GetHashCode():0;int b=Second!=null?Second.GetHashCode():0;uint c=((uint)a<<5)|((uint)a>>27);return((int)c+a)^b;}}
    public class HashMap<K,V>:Dictionary<K,V>{V i;static Func<V>j=System.Linq.Expressions.Expression.Lambda<Func<V>>(System.Linq.Expressions.Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V a){i=a;}new public V this[K a]{get{V b;if(TryGetValue(a,out b))return b;else return base[a]=i!=null?i:j();}set{base[a]=value;}}}
    public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public readonly static int[]DXY4={0,1,0,-1,0};public readonly static int[]DXY8={1,1,0,1,-1,0,-1,-1,1};public static void DontAutoFlush(){var a=new System.IO.StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(a);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]a){Array.Sort<T>(a);return a;}public static T[]SortDecend<T>(T[]a){Array.Sort<T>(a);Array.Reverse(a);return a;}public static void Swap<T>(ref T a,ref T b){T c=a;a=b;b=c;}public static int GCD(int a,int b){return(b==0)?a:GCD(b,a%b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static long ModAdd(long a,long b){long c=a+b;if(c>=MOD)return c%MOD;return c;}public static long ModMul(long a,long b){long c=a*b;if(c>=MOD)return c%MOD;return c;}public static void ChModAdd(ref long a,long b){a+=b;if(a>=MOD)a%=MOD;}public static void ChModMul(ref long a,long b){a*=b;if(a>=MOD)a%=MOD;}public static void FillArray<T>(T[]a,T b){int c=a.Length;for(int d=0;d<c;d++)a[d]=b;}public static void FillArray<T>(T[,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);for(int e=0;e<c;e++)for(int f=0;f<d;f++){a[e,f]=b;}}public static void FillArray<T>(T[,,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);int e=a.GetLength(2);for(int f=0;f<c;f++)for(int g=0;g<d;g++){for(int h=0;h<e;h++){a[f,g,h]=b;}}}public static long[]Accumulate(long[]a){long[]b=new long[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}public static double[]Accumulate(double[]a){double[]b=new double[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}}
    public static class Cin{public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static int ReadInt(){return int.Parse(k());}public static long ReadLong(){return long.Parse(k());}public static double ReadDouble(){return double.Parse(k());}public static string ReadString(){return k();}public static int[]ReadIntArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static void ReadCols(out long[]a,out long[]b,long c){a=new long[c];b=new long[c];for(int d=0;d<c;d++){a[d]=ReadLong();b[d]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long d){a=new long[d];b=new long[d];c=new long[d];for(int e=0;e<d;e++){a[e]=ReadLong();b[e]=ReadLong();c[e]=ReadLong();}}public static int[][]ReadIntTable(int a){i=null;int[][]b=new int[a][];for(int c=0;c<a;c++)b[c]=ReadIntArray();return b;}public static long[][]ReadLongTable(long a){i=null;long[][]b=new long[a][];for(long c=0;c<a;c++)b[c]=ReadLongArray();return b;}static string[]i{get;set;}static int j{get;set;}static string k(){if(i==null||i.Length<=j){i=Console.ReadLine().Split(' ');j=0;}return i[j++];}}
}
