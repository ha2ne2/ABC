using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Math;
using static ABC155.Cin;
using static ABC155.Util;
using Pair = ABC155.VTuple<long, long>;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<long>>;

namespace ABC155
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DontAutoFlush();

            // A(); 4m
            // B(); 8m
            C();
            //E();
            //D();
            //E();
            //F();

            Flush();
        }

        public static void F()
        {

        }

        public static void E()
        {
            string S = rs;
            long N = S.Length;
            long[,] dp = new long[N + 1, 2];
            dp[0, 1] = 1;
            for (int i = 0; i < N; i++)
            {
                int n = S[i] - '0';
                dp[i + 1, 0] = Min(dp[i, 0] + n, dp[i, 1] + 10 - n);
                dp[i + 1, 1] = Min(dp[i, 0] + n + 1, dp[i, 1] + 9 - n);
            }
        }

        public static void D()
        {
            
        }

        public static void C()
        {
            long N = rl;
            string[] S = new string[N];
            for (int i = 0; i < N; i++)
            {
                S[i] = rs;
            }

            long max = 0;
            HashMap<string, int> hm = new HashMap<string, int>();
            for (int i = 0; i < N; i++)
            {
                hm[S[i]]++;
                ChMax(ref max, hm[S[i]]);
            }

            List<string> lst = new List<string>();
            foreach (var key in hm.Keys)
            {
                if (hm[key] == max)
                {
                    lst.Add(key);
                }
            }

            string[] ary = lst.ToArray();
            Array.Sort(ary, StringComparer.Ordinal);
            foreach (var item in ary)
            {
                Console.WriteLine(item);
            }
        }

        public static void B()
        {
            long N = rl;
            long[] A = rla;
            if (A.Where(a => a % 2 == 0).All(a => (a % 3 == 0) || (a % 5 == 0)))
            {
                Console.WriteLine("APPROVED");
            }
            else
            {
                Console.WriteLine("DENIED");
            }
        }

        public static void A()
        {
            long A = rl;
            long B = rl;
            long C = rl;
            if ((A == B && B != C) ||
                (A == C && B != C) ||
                (B == C && A != B))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }

    public class HashMap<K,V>:Dictionary<K,V>{V i;static Func<V>j=System.Linq.Expressions.Expression.Lambda<Func<V>>(System.Linq.Expressions.Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V a){i=a;}new public V this[K a]{get{V b;if(TryGetValue(a,out b))return b;else return base[a]=i!=null?i:j();}set{base[a]=value;}}}public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public static void DontAutoFlush(){var a=new System.IO.StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(a);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]a){Array.Sort<T>(a);return a;}public static T[]SortDecend<T>(T[]a){Array.Sort<T>(a);Array.Reverse(a);return a;}public static void Swap<T>(ref T a,ref T b){T c=a;a=b;b=c;}public static int GCD(int a,int b){return(b==0)?a:GCD(b,a%b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static long ModAdd(long a,long b){long c=a+b;if(c>=MOD)return c%MOD;return c;}public static long ModMul(long a,long b){long c=a*b;if(c>=MOD)return c%MOD;return c;}public static void ChModAdd(ref long a,long b){a+=b;if(a>=MOD)a%=MOD;}public static void ChModMul(ref long a,long b){a*=b;if(a>=MOD)a%=MOD;}public static void FillArray<T>(T[]a,T b){int c=a.Length;for(int d=0;d<c;d++)a[d]=b;}public static void FillArray<T>(T[,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);for(int e=0;e<c;e++)for(int f=0;f<d;f++){a[e,f]=b;}}public static void FillArray<T>(T[,,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);int e=a.GetLength(2);for(int f=0;f<c;f++)for(int g=0;g<d;g++){for(int h=0;h<e;h++){a[f,g,h]=b;}}}public static long[]Accumulate(long[]a){long[]b=new long[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}public static double[]Accumulate(double[]a){double[]b=new double[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}}public static class Cin{public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static int ReadInt(){return int.Parse(k());}public static long ReadLong(){return long.Parse(k());}public static double ReadDouble(){return double.Parse(k());}public static string ReadString(){return k();}public static int[]ReadIntArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static void ReadCols(out long[]a,out long[]b,long c){a=new long[c];b=new long[c];for(int d=0;d<c;d++){a[d]=ReadLong();b[d]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long d){a=new long[d];b=new long[d];c=new long[d];for(int e=0;e<d;e++){a[e]=ReadLong();b[e]=ReadLong();c[e]=ReadLong();}}public static int[][]ReadIntTable(int a){i=null;int[][]b=new int[a][];for(int c=0;c<a;c++)b[c]=ReadIntArray();return b;}public static long[][]ReadLongTable(long a){i=null;long[][]b=new long[a][];for(long c=0;c<a;c++)b[c]=ReadLongArray();return b;}static string[]i{get;set;}static int j{get;set;}static string k(){if(i==null||i.Length<=j){i=Console.ReadLine().Split(' ');j=0;}return i[j++];}}public struct VTuple<T1,T2>:IComparable<VTuple<T1,T2>>,IEquatable<VTuple<T1,T2>>{public T1 First;public T2 Second;public VTuple(T1 a,T2 b){First=a;Second=b;}public int CompareTo(VTuple<T1,T2>a){int b=Comparer<T1>.Default.Compare(First,a.First);if(b!=0)return b;return Comparer<T2>.Default.Compare(Second,a.Second);}public override bool Equals(object a){return a is VTuple<T1,T2>&&Equals((VTuple<T1,T2>)a);}public bool Equals(VTuple<T1,T2>a){return EqualityComparer<T1>.Default.Equals(First,a.First)&&EqualityComparer<T2>.Default.Equals(Second,a.Second);}public override int GetHashCode(){int a=First!=null?First.GetHashCode():0;int b=Second!=null?Second.GetHashCode():0;uint c=((uint)a<<5)|((uint)a>>27);return((int)c+a)^b;}}
}
