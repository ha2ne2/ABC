using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static _20200219.Cin;
using static _20200219.Util;
using Pair = _20200219.VTuple<long, long>;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<long>>;
using System.Text;

namespace _20200219
{
    public class Program
    {
        public static void _Main(string[] args)
        {
            // ARC033_B(); 17min
            // Nikkei2019_2_B();
            Tenka1_2018_C();
        }

        public static void Tenka1_2018_C()
        {
            long N = rl;
            long[] A = new long[N];
            for (int i = 0; i < N; i++)
            {
                A[i] = rl;
            }
            Sort(A);

            if (N % 2 == 0)
            {
                long ans = 0;
                for (int i = 0; i < N / 2 - 1; i++) ans += A[i] * -2;
                ans -= A[N / 2 - 1];
                ans += A[N / 2];
                for (int i = (int)N / 2 + 1; i < N; i++) ans += A[i] * 2;
                Console.WriteLine(ans);
            }
            else
            {
                long res1 = 0;
                for (int i = 0; i < N / 2; i++) res1 += A[i] * -2;
                res1 += A[N / 2];
                res1 += A[N / 2 + 1];
                for (int i = (int)N / 2 + 2; i < N; i++) res1 += A[i] * 2;

                long res2 = 0;
                for (int i = 0; i < N / 2 - 1; i++) res2 += A[i] * -2;
                res2 -= A[N / 2 - 1];
                res2 -= A[N / 2];
                for (int i = (int)N / 2 + 1; i < N; i++) res2 += A[i] * 2;

                Console.WriteLine(Max(res1,res2));
            }
        }

        public static void Tenka1_2018_C2()
        {
            long N = rl;
            long[] A = new long[N];
            for (int i = 0; i < N; i++)
            {
                A[i] = rl;
            }
            Sort(A);
            long leftVal = A[0];
            long rightVal = A[N - 1];
            long ans = Abs(leftVal - rightVal);
            long l = 1;
            long r = N - 2;

            while (l <= r)
            {
                long ll = Abs(leftVal - A[l]);
                long lr = Abs(rightVal - A[l]);
                long maxL = Max(ll, lr);
                long _rl = Abs(leftVal - A[r]);
                long rr = Abs(rightVal - A[r]);
                long maxR = Max(_rl, rr);
                if (maxL > maxR)
                {
                    ans += maxL;
                    if (ll > lr) { leftVal = A[l];}
                    else { rightVal = A[l];}
                    l++;
                }
                else
                {
                    ans += maxR;
                    if (_rl > rr) { leftVal = A[r];}
                    else { rightVal = A[r];}
                    r--;
                }
                //Console.WriteLine(s);

            }
            Console.WriteLine(ans);
        }

        public static void Nikkei2019_2_B()
        {
            long N = rl;
            long[] A = rla;
            if (A[0] != 0)
            {
                Console.WriteLine(0);
                return;
            }
            Sort(A);

            HashMap<long, long> hs = new HashMap<long, long>();
            hs[0]++;

            long prev = 0;
            for (int i = 1; i < N; i++)
            {
                if (A[i] == prev)
                {
                    hs[A[i]]++;
                }
                else if (A[i] == prev + 1)
                {
                    prev = A[i];
                    hs[A[i]]++;
                }
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            var kosuAry = hs.Keys.OrderBy(n => n).Select(n => hs[n]).ToArray();
            if (kosuAry[0] != 1)
            {
                Console.WriteLine(0);
                return;
            }
            long ans = 1;
            for (int i = 1; i < kosuAry.Length; i++)
            {
                for (int j = 0; j < kosuAry[i]; j++)
                {
                    ans = (ans * kosuAry[i-1]) % 998244353;
                }
            }

            Console.WriteLine(ans);
        }

        public static void ARC033_B()
        {
            long NA = rl;
            long NB = rl;
            long[] A = rla;
            long[] B = rla;
            HashSet<long> hsA = new HashSet<long>();
            foreach (var a in A) hsA.Add(a);
            long bunsi = 0;
            foreach(var b in B)
            {
                if (hsA.Contains(b))
                    bunsi++;
            }
            foreach (var b in B)
            {
                hsA.Add(b);
            }
            long bunbo = hsA.Count;
            Console.WriteLine(bunsi / (double)bunbo);
        }
    }

    public class HashMap<K,V>:Dictionary<K,V>{V i;static Func<V>j=System.Linq.Expressions.Expression.Lambda<Func<V>>(System.Linq.Expressions.Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V a){i=a;}new public V this[K a]{get{V b;if(TryGetValue(a,out b))return b;else return base[a]=i!=null?i:j();}set{base[a]=value;}}}public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public static void DontAutoFlush(){var a=new System.IO.StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(a);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]a){Array.Sort<T>(a);return a;}public static T[]SortDecend<T>(T[]a){Array.Sort<T>(a);Array.Reverse(a);return a;}public static void Swap<T>(ref T a,ref T b){T c=a;a=b;b=c;}public static int GCD(int a,int b){return(b==0)?a:GCD(b,a%b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static long ModAdd(long a,long b){long c=a+b;if(c>=MOD)return c%MOD;return c;}public static long ModMul(long a,long b){long c=a*b;if(c>=MOD)return c%MOD;return c;}public static void ChModAdd(ref long a,long b){a+=b;if(a>=MOD)a%=MOD;}public static void ChModMul(ref long a,long b){a*=b;if(a>=MOD)a%=MOD;}public static void FillArray<T>(T[]a,T b){int c=a.Length;for(int d=0;d<c;d++)a[d]=b;}public static void FillArray<T>(T[,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);for(int e=0;e<c;e++)for(int f=0;f<d;f++){a[e,f]=b;}}public static void FillArray<T>(T[,,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);int e=a.GetLength(2);for(int f=0;f<c;f++)for(int g=0;g<d;g++){for(int h=0;h<e;h++){a[f,g,h]=b;}}}public static long[]Accumulate(long[]a){long[]b=new long[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}public static double[]Accumulate(double[]a){double[]b=new double[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}}public static class Cin{public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static int ReadInt(){return int.Parse(k());}public static long ReadLong(){return long.Parse(k());}public static double ReadDouble(){return double.Parse(k());}public static string ReadString(){return k();}public static int[]ReadIntArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static void ReadCols(out long[]a,out long[]b,long c){a=new long[c];b=new long[c];for(int d=0;d<c;d++){a[d]=ReadLong();b[d]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long d){a=new long[d];b=new long[d];c=new long[d];for(int e=0;e<d;e++){a[e]=ReadLong();b[e]=ReadLong();c[e]=ReadLong();}}public static int[][]ReadIntTable(int a){i=null;int[][]b=new int[a][];for(int c=0;c<a;c++)b[c]=ReadIntArray();return b;}public static long[][]ReadLongTable(long a){i=null;long[][]b=new long[a][];for(long c=0;c<a;c++)b[c]=ReadLongArray();return b;}static string[]i{get;set;}static int j{get;set;}static string k(){if(i==null||i.Length<=j){i=Console.ReadLine().Split(' ');j=0;}return i[j++];}}public struct VTuple<T1,T2>:IComparable<VTuple<T1,T2>>,IEquatable<VTuple<T1,T2>>{public T1 First;public T2 Second;public VTuple(T1 a,T2 b){First=a;Second=b;}public int CompareTo(VTuple<T1,T2>a){int b=Comparer<T1>.Default.Compare(First,a.First);if(b!=0)return b;return Comparer<T2>.Default.Compare(Second,a.Second);}public override bool Equals(object a){return a is VTuple<T1,T2>&&Equals((VTuple<T1,T2>)a);}public bool Equals(VTuple<T1,T2>a){return EqualityComparer<T1>.Default.Equals(First,a.First)&&EqualityComparer<T2>.Default.Equals(Second,a.Second);}public override int GetHashCode(){int a=First!=null?First.GetHashCode():0;int b=Second!=null?Second.GetHashCode():0;uint c=((uint)a<<5)|((uint)a>>27);return((int)c+a)^b;}}
}
