using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static _20200218.Cin;
using static _20200218.Util;
using Pair = _20200218.VTuple<long, long>;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<long>>;
using System.Text;

namespace _20200218
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // A(); 15m
            // B(); 21m
            // C(); 32m
            // D(); 43m
            // E(); 67m
            // F(); 92m
            // G(); 110m

            // ABC057_C();  11m
            // ABC142_D();  60m
            // ARC087_D(); 240m
        }

        public static void ARC087_D()
        {
            const long MC = 8001;
            string s = rs;
            long x = rl;
            long y = rl;
            bool[][] dp = new bool[2][];
            dp[0] = new bool[MC];
            dp[1] = new bool[MC];
            dp[0][0] = true;
            dp[1][0] = true;

            s += "T";
            int i = 0;
            while (i < s.Length && s[i] == 'F')
                i++;
            x -= i;
            if (Abs(x) + i >= MC)
            {
                Console.WriteLine("No");
                return;
            }

            int turn = 0;
            long cnt = 0;
            for (; i < s.Length; i++)
            {
                if(s[i] == 'F')
                {
                    cnt++;
                }
                else
                {
                    if (cnt > 0)
                    {
                        bool[] nxt = new bool[MC];
                        for (int j = 0; j <= i; j++)
                        {
                            if (!dp[turn][j]) continue;
                            nxt[j + cnt] = nxt[Abs(j - cnt)] = true;
                        }
                        dp[turn] = nxt;
                    }
                    cnt = 0;
                    turn ^= 1;
                }
            }

            string ans = dp[0][Abs(x)] && dp[1][Abs(y)] ? "Yes" : "No";
            Console.WriteLine(ans);
        }

        public static void ABC142_D()
        {
            long A = rl;
            long B = rl;

            List<long> primes = new List<long>();
            primes.Add(1);
            if (A % 2 == 0)
            {
                primes.Add(2);
                while (A % 2 == 0)
                    A /= 2;
            }
            for (long i = 3; i * i <= A; i+=2)
            {
                if (A % i == 0)
                {
                    primes.Add(i);
                    while (A % i == 0)
                        A /= i;                        
                }
            }
            if (A != 1)
                primes.Add(A);

            long ans = 0;
            foreach(var p in primes)
            {
                if (B % p == 0)
                    ans++;
            }

            Console.WriteLine(ans);
        }

        public static void ABC057_C()
        {
            long N = rl;
            long root = (long)Sqrt(N);
            long A = 1;
            for (int i = 2; i <= root; i++)
            {
                if(N % i == 0)
                {
                    A = i;
                }
            }

            long B = N / A;
            long ans = 0;
            while (B != 0)
            {
                B /= 10;
                ans++;
            }

            Console.WriteLine(ans);
        }

        public static void G()
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
                int x = (int)rl-1;
                int y = (int)rl-1;
                G[x].Add(y);
            }

            int[] memo = new int[N + 1];
            FillArray(memo, -1);
            Func<int, int> rec = null;
            rec = (v) =>
            {
                if (memo[v] != -1) return memo[v];

                if (!G[v].Any())
                {
                    return memo[v] = 0;
                }

                long res = 0;
                foreach(int nv in G[v])
                {
                    ChMax(ref res, rec(nv) + 1);
                };
                                
                return memo[v] = (int)res;
            };

            long ans = -1;
            for (int i = 0; i < N; i++)
            {
                ChMax(ref ans, rec(i));
            }

            Console.WriteLine(ans);
        }

        public static void F()
        {
            string s = rs;
            string t = rs;

            long[,] dp = new long[s.Length + 1, t.Length + 1];
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= t.Length; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            // 復元
            int x = s.Length;
            int y = t.Length;
            StringBuilder sb = new StringBuilder();
            while (dp[x,y] != 0)
            {
                while (dp[x - 1, y] == dp[x, y])
                    x--;
                while (dp[x, y - 1] == dp[x, y])
                    y--;

                x--;
                y--;
                sb.Append(s[x]);
            }

            string ans = string.Concat(sb.ToString().Reverse());
            Console.WriteLine(ans);
        }

        public static void E()
        {
            long N = rl;
            long W = rl;
            long[] w, v;
            ReadCols(out w, out v, N);
            long MAX_V = 1000 * N;
            long[,] dp = new long[N + 1, MAX_V + 1];
            FillArray(dp, INF);
            dp[0, 0] = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j <= MAX_V; j++)
                {
                    if(j - v[i] < 0)
                        dp[i + 1, j] = dp[i, j];
                    else
                    {
                        dp[i + 1, j] = Min(dp[i, j], dp[i, j - v[i]] + w[i]);
                    }
                }
            }

            long ans = 0;
            for (long i = 0; i <= MAX_V; i++)
            {
                if (dp[N, i] <= W)
                {
                    ans = i;
                }
            }

            Console.WriteLine(ans);
        }

        public static void D()
        {
            long N = rl;
            long W = rl;
            long[] w, v;
            ReadCols(out w, out v, N);
            long[,] dp = new long[N + 1, W + 1];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    if (j - w[i] < 0)
                    {
                        dp[i + 1, j] = dp[i, j];
                    }
                    else
                    {
                        dp[i + 1, j] = Max(dp[i, j], dp[i, j - w[i]] + v[i]);
                    }
                }                
            }
            Console.WriteLine(dp[N, W]);
        }

        public static void C()
        {
            long N = rl;
            long[] a, b, c;
            ReadCols(out a, out b, out c, N);

            long[,] dp = new long[N+1, 3];
            for (int i = 0; i < N; i++)
            {
                dp[i + 1, 0] = Max(dp[i, 1], dp[i, 2]) + a[i];
                dp[i + 1, 1] = Max(dp[i, 0], dp[i, 2]) + b[i];
                dp[i + 1, 2] = Max(dp[i, 0], dp[i, 1]) + c[i];
            }

            long ans = Max(dp[N, 0], Max(dp[N, 1], dp[N, 2]));
            Console.WriteLine(ans);
        }

        public static void B()
        {
            long N = rl;
            long K = rl;
            long[] A = rla;
            long[] dp = new long[N];
            FillArray(dp, INF);
            dp[0] = 0;
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = 1; j <= K && i + j < N; j++)
                {
                    dp[i + j] = Min(dp[i + j], dp[i] + Abs(A[i + j] - A[i]));
                }
            }

            Console.WriteLine(dp[N-1]);
        }

        public static void A()
        {
            long N = rl;
            long[] A = rla;

            long[] dp = new long[N];
            FillArray(dp, INF);
            dp[0] = 0;
            for (int i = 0; i < N - 1; i++)
            {
                dp[i + 1] = Min(dp[i + 1], dp[i] + Abs(A[i + 1] - A[i]));
                if (i + 2 < N)
                    dp[i + 2] = dp[i] + Abs(A[i + 2] - A[i]);
            }

            Console.WriteLine(dp[N-1]);
        }
    }

    public class HashMap<K,V>:Dictionary<K,V>{V i;static Func<V>j=System.Linq.Expressions.Expression.Lambda<Func<V>>(System.Linq.Expressions.Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V a){i=a;}new public V this[K a]{get{V b;if(TryGetValue(a,out b))return b;else return base[a]=i!=null?i:j();}set{base[a]=value;}}}public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public static void DontAutoFlush(){var a=new System.IO.StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(a);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]a){Array.Sort<T>(a);return a;}public static T[]SortDecend<T>(T[]a){Array.Sort<T>(a);Array.Reverse(a);return a;}public static void Swap<T>(ref T a,ref T b){T c=a;a=b;b=c;}public static int GCD(int a,int b){return(b==0)?a:GCD(b,a%b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static long ModAdd(long a,long b){long c=a+b;if(c>=MOD)return c%MOD;return c;}public static long ModMul(long a,long b){long c=a*b;if(c>=MOD)return c%MOD;return c;}public static void ChModAdd(ref long a,long b){a+=b;if(a>=MOD)a%=MOD;}public static void ChModMul(ref long a,long b){a*=b;if(a>=MOD)a%=MOD;}public static void FillArray<T>(T[]a,T b){int c=a.Length;for(int d=0;d<c;d++)a[d]=b;}public static void FillArray<T>(T[,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);for(int e=0;e<c;e++)for(int f=0;f<d;f++){a[e,f]=b;}}public static void FillArray<T>(T[,,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);int e=a.GetLength(2);for(int f=0;f<c;f++)for(int g=0;g<d;g++){for(int h=0;h<e;h++){a[f,g,h]=b;}}}public static long[]Accumulate(long[]a){long[]b=new long[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}public static double[]Accumulate(double[]a){double[]b=new double[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}}public static class Cin{public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static int ReadInt(){return int.Parse(k());}public static long ReadLong(){return long.Parse(k());}public static double ReadDouble(){return double.Parse(k());}public static string ReadString(){return k();}public static int[]ReadIntArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static void ReadCols(out long[]a,out long[]b,long c){a=new long[c];b=new long[c];for(int d=0;d<c;d++){a[d]=ReadLong();b[d]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long d){a=new long[d];b=new long[d];c=new long[d];for(int e=0;e<d;e++){a[e]=ReadLong();b[e]=ReadLong();c[e]=ReadLong();}}public static int[][]ReadIntTable(int a){i=null;int[][]b=new int[a][];for(int c=0;c<a;c++)b[c]=ReadIntArray();return b;}public static long[][]ReadLongTable(long a){i=null;long[][]b=new long[a][];for(long c=0;c<a;c++)b[c]=ReadLongArray();return b;}static string[]i{get;set;}static int j{get;set;}static string k(){if(i==null||i.Length<=j){i=Console.ReadLine().Split(' ');j=0;}return i[j++];}}public struct VTuple<T1,T2>:IComparable<VTuple<T1,T2>>,IEquatable<VTuple<T1,T2>>{public T1 First;public T2 Second;public VTuple(T1 a,T2 b){First=a;Second=b;}public int CompareTo(VTuple<T1,T2>a){int b=Comparer<T1>.Default.Compare(First,a.First);if(b!=0)return b;return Comparer<T2>.Default.Compare(Second,a.Second);}public override bool Equals(object a){return a is VTuple<T1,T2>&&Equals((VTuple<T1,T2>)a);}public bool Equals(VTuple<T1,T2>a){return EqualityComparer<T1>.Default.Equals(First,a.First)&&EqualityComparer<T2>.Default.Equals(Second,a.Second);}public override int GetHashCode(){int a=First!=null?First.GetHashCode():0;int b=Second!=null?Second.GetHashCode():0;uint c=((uint)a<<5)|((uint)a>>27);return((int)c+a)^b;}}
}
