using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Math;
using static ABC156.Cin;
using static ABC156.Util;
using Pair = ABC156.VTuple<long, long>;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<long>>;

namespace ABC156
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Abc156_A(); 4m
            // Abc156_B(); 10m
            // Abc156_C(); 15m
            Abc156_D();
            // Abc156_E();
            // Abc156_F();
        }

        public static void Abc156_F()
        {

        }

        public static void Abc156_E()
        {

        }

        /// <summary>
        /// 繰り返し二乗法
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <param name="mod"></param>
        /// <returns></returns>
        static long Pow(long n, long p, long mod)
        {
            if (p == 0) return 1;
            if (p % 2 == 0)
            {
                long t = Pow(n, p / 2, mod);
                return t * t % mod;
            }
            return Pow(n, p / 2, mod) * n % mod;
        }

        /// <summary>
        /// nが大きくてkが小さいときに使える。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        static long nCk(long n, long k)
        {
            long x = 1;
            long y = 1;
            for (int i = 0; i < k; i++)
            {
                x = x * (n - i) % MOD;
                y = y * (i + 1) % MOD;
            }
            // 逆元を取る
            y = Pow(y, MOD - 2, MOD);
            return x * y % MOD;
        }

        public static void Abc156_D()
        {
            long n = rl;
            long a = rl;
            long b = rl;

            var total = Pow(2, n, MOD) - 1;
            if (total < 0) total += MOD;

            long a1 = nCk(n, a);
            total -= a1;
            if (total < 0) total += MOD;
            
            long b1 = nCk(n, b);
            total -= b1;
            if (total < 0) total += MOD;

            Console.WriteLine(total);
        }

        public static void Abc156_C()
        {
            long n = rl;
            long[] A = rla;

            long ans = INF;
            for (int i = 1; i <= 100; i++)
            {
                long res = 0;
                foreach (var a in A)
                {
                    res += (i - a) * (i - a);
                }
                ChMin(ref ans, res);
            }

            Console.WriteLine(ans);
        }

        public static void Abc156_B()
        {
            long n = rl;
            long k = rl;
            long keta = 0;
            do {
                n /= k;
                keta++;
            } while (n != 0);
            Console.WriteLine(keta);
        }

        public static void Abc156_A()
        {
            long n = rl;
            long r = rl;

            if (n >= 10)
            {
                Console.WriteLine(r);
            }
            else
            {
                Console.WriteLine(r+100*(10-n));
            }

        }
    }

    public class HashMap<K,V>:Dictionary<K,V>{V i;static Func<V>j=System.Linq.Expressions.Expression.Lambda<Func<V>>(System.Linq.Expressions.Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V a){i=a;}new public V this[K a]{get{V b;if(TryGetValue(a,out b))return b;else return base[a]=i!=null?i:j();}set{base[a]=value;}}}public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public static void DontAutoFlush(){var a=new System.IO.StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(a);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]a){Array.Sort<T>(a);return a;}public static T[]SortDecend<T>(T[]a){Array.Sort<T>(a);Array.Reverse(a);return a;}public static void Swap<T>(ref T a,ref T b){T c=a;a=b;b=c;}public static int GCD(int a,int b){return(b==0)?a:GCD(b,a%b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static long ModAdd(long a,long b){long c=a+b;if(c>=MOD)return c%MOD;return c;}public static long ModMul(long a,long b){long c=a*b;if(c>=MOD)return c%MOD;return c;}public static void ChModAdd(ref long a,long b){a+=b;if(a>=MOD)a%=MOD;}public static void ChModMul(ref long a,long b){a*=b;if(a>=MOD)a%=MOD;}public static void FillArray<T>(T[]a,T b){int c=a.Length;for(int d=0;d<c;d++)a[d]=b;}public static void FillArray<T>(T[,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);for(int e=0;e<c;e++)for(int f=0;f<d;f++){a[e,f]=b;}}public static void FillArray<T>(T[,,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);int e=a.GetLength(2);for(int f=0;f<c;f++)for(int g=0;g<d;g++){for(int h=0;h<e;h++){a[f,g,h]=b;}}}public static long[]Accumulate(long[]a){long[]b=new long[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}public static double[]Accumulate(double[]a){double[]b=new double[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}}public static class Cin{public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static int ReadInt(){return int.Parse(k());}public static long ReadLong(){return long.Parse(k());}public static double ReadDouble(){return double.Parse(k());}public static string ReadString(){return k();}public static int[]ReadIntArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static void ReadCols(out long[]a,out long[]b,long c){a=new long[c];b=new long[c];for(int d=0;d<c;d++){a[d]=ReadLong();b[d]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long d){a=new long[d];b=new long[d];c=new long[d];for(int e=0;e<d;e++){a[e]=ReadLong();b[e]=ReadLong();c[e]=ReadLong();}}public static int[][]ReadIntTable(int a){i=null;int[][]b=new int[a][];for(int c=0;c<a;c++)b[c]=ReadIntArray();return b;}public static long[][]ReadLongTable(long a){i=null;long[][]b=new long[a][];for(long c=0;c<a;c++)b[c]=ReadLongArray();return b;}static string[]i{get;set;}static int j{get;set;}static string k(){if(i==null||i.Length<=j){i=Console.ReadLine().Split(' ');j=0;}return i[j++];}}public struct VTuple<T1,T2>:IComparable<VTuple<T1,T2>>,IEquatable<VTuple<T1,T2>>{public T1 First;public T2 Second;public VTuple(T1 a,T2 b){First=a;Second=b;}public int CompareTo(VTuple<T1,T2>a){int b=Comparer<T1>.Default.Compare(First,a.First);if(b!=0)return b;return Comparer<T2>.Default.Compare(Second,a.Second);}public override bool Equals(object a){return a is VTuple<T1,T2>&&Equals((VTuple<T1,T2>)a);}public bool Equals(VTuple<T1,T2>a){return EqualityComparer<T1>.Default.Equals(First,a.First)&&EqualityComparer<T2>.Default.Equals(Second,a.Second);}public override int GetHashCode(){int a=First!=null?First.GetHashCode():0;int b=Second!=null?Second.GetHashCode():0;uint c=((uint)a<<5)|((uint)a>>27);return((int)c+a)^b;}}
}
