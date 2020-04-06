using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static Judge_Update_202004.D.Cin;
using static Judge_Update_202004.D.Util;
using Pair = Judge_Update_202004.D.VTuple<long, long>;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<long>>;
using System.Text;

namespace Judge_Update_202004
{
    public class D
    {
        public static void DontAutoFlush()
        {
            if (Console.IsOutputRedirected)
                return;

            var a = new System.IO.StreamWriter(Console.OpenStandardOutput()) {
                AutoFlush = false
            };            
            Console.SetOut(a);
        }


        public static void Main(string[] args)
        {
            int N = ri;
            int Q = ri;
            long[] A = rla;
            long[] S = rla;

            long[] B = new long[N];
            B[0] = A[0];
            for (int i = 0; i < N-1; i++)
            {
                B[i+1] = GCD(B[i], A[i + 1]);
            }

            DontAutoFlush();
            for (int i = 0; i < Q; i++)
            {
                if (GCD(B[N - 1], S[i]) != 1)
                {
                    Console.WriteLine(GCD(B[N - 1], S[i]));
                }
                else
                {
                    int ok = N - 1;
                    int ng = -1;
                    while(1 < Abs(ok - ng))
                    {
                        int mid = (ok + ng) / 2;
                        if (GCD(B[mid], S[i]) == 1)
                        {
                            ok = mid;
                        }
                        else
                        {
                            ng = mid;
                        }
                    }

                    Console.WriteLine(ok + 1);
                }
            }
            Flush();
        }

        public struct Mint:System.IComparable<Mint>,System.IEquatable<Mint>{public static readonly long MOD=(long)1e9+7;public long Value;public Mint(long a){Value=a%MOD;if(Value<0)Value+=MOD;}static Mint i(long a){return new Mint(){Value=a};}public static Mint operator+(Mint a,Mint b){long c=a.Value+b.Value;if(c>MOD)c-=MOD;return i(c);}public static Mint operator-(Mint a,Mint b){long c=a.Value-b.Value;if(c<0)c+=MOD;return i(c);}public static Mint operator*(Mint a,Mint b){long c=a.Value*b.Value;if(c>MOD)c%=MOD;return i(c);}public static Mint operator/(Mint a,Mint b){return a*Inv(b);}public override bool Equals(object a){return a is Mint&&Value==((Mint)a).Value;}public override int GetHashCode(){return Value.GetHashCode();}public static implicit operator Mint(long a){return new Mint(a);}public static explicit operator long(Mint a){return a.Value;}public static Mint Pow(Mint a,long b){if(b==0)return new Mint(1);Mint c=Pow(a,b>>1);c*=c;if((b&1)==1)c*=a;return c;}public static Mint Inv(Mint a){long b=a.Value;long c=MOD;long d=1;long e=0;while(c!=0){long f=b/c;long g=e;e=d-f*e;d=g;long h=b;b=c;c=h-(f*c);}return new Mint(d);}public bool Equals(Mint a){return Value==a.Value;}public int CompareTo(Mint a){return Comparer<long>.Default.Compare(Value,a.Value);}}public struct VTuple<T1,T2>:System.IComparable<VTuple<T1,T2>>,System.IEquatable<VTuple<T1,T2>>{public T1 Item1;public T2 Item2;public T1 First{get{return Item1;}}public T2 Second{get{return Item2;}}public VTuple(T1 a,T2 b){Item1=a;Item2=b;}public override bool Equals(object a){return a is VTuple<T1,T2>&&Equals((VTuple<T1,T2>)a);}public override int GetHashCode(){int a=Item1!=null?Item1.GetHashCode():0;int b=Item2!=null?Item2.GetHashCode():0;return HashHelpers.CombineHashCodes(a,b);}public bool Equals(VTuple<T1,T2>a){return EqualityComparer<T1>.Default.Equals(Item1,a.Item1)&&EqualityComparer<T2>.Default.Equals(Item2,a.Item2);}public int CompareTo(VTuple<T1,T2>a){int b=Comparer<T1>.Default.Compare(Item1,a.Item1);if(b!=0)return b;return Comparer<T2>.Default.Compare(Item2,a.Item2);}}public struct VTuple<T1,T2,T3>:System.IComparable<VTuple<T1,T2,T3>>,System.IEquatable<VTuple<T1,T2,T3>>{public T1 Item1;public T2 Item2;public T3 Item3;public VTuple(T1 a,T2 b,T3 c){Item1=a;Item2=b;Item3=c;}public override bool Equals(object a){return a is VTuple<T1,T2,T3>&&Equals((VTuple<T1,T2,T3>)a);}public override int GetHashCode(){int a=Item1!=null?Item1.GetHashCode():0;int b=Item2!=null?Item2.GetHashCode():0;int c=Item3!=null?Item3.GetHashCode():0;return HashHelpers.CombineHashCodes(a,b,c);}public bool Equals(VTuple<T1,T2,T3>a){return EqualityComparer<T1>.Default.Equals(Item1,a.Item1)&&EqualityComparer<T2>.Default.Equals(Item2,a.Item2)&&EqualityComparer<T3>.Default.Equals(Item3,a.Item3);}public int CompareTo(VTuple<T1,T2,T3>a){int b=Comparer<T1>.Default.Compare(Item1,a.Item1);if(b!=0)return b;b=Comparer<T2>.Default.Compare(Item2,a.Item2);if(b!=0)return b;return Comparer<T3>.Default.Compare(Item3,a.Item3);}}public struct VTuple<T1,T2,T3,T4>:System.IComparable<VTuple<T1,T2,T3,T4>>,System.IEquatable<VTuple<T1,T2,T3,T4>>{public T1 Item1;public T2 Item2;public T3 Item3;public T4 Item4;public VTuple(T1 a,T2 b,T3 c,T4 d){Item1=a;Item2=b;Item3=c;Item4=d;}public override bool Equals(object a){return a is VTuple<T1,T2,T3,T4>&&Equals((VTuple<T1,T2,T3,T4>)a);}public override int GetHashCode(){int a=Item1!=null?Item1.GetHashCode():0;int b=Item2!=null?Item2.GetHashCode():0;int c=Item3!=null?Item3.GetHashCode():0;int d=Item3!=null?Item4.GetHashCode():0;return HashHelpers.CombineHashCodes(a,b,c,d);}public bool Equals(VTuple<T1,T2,T3,T4>a){return EqualityComparer<T1>.Default.Equals(Item1,a.Item1)&&EqualityComparer<T2>.Default.Equals(Item2,a.Item2)&&EqualityComparer<T3>.Default.Equals(Item3,a.Item3)&&EqualityComparer<T4>.Default.Equals(Item4,a.Item4);}public int CompareTo(VTuple<T1,T2,T3,T4>a){int b=Comparer<T1>.Default.Compare(Item1,a.Item1);if(b!=0)return b;b=Comparer<T2>.Default.Compare(Item2,a.Item2);if(b!=0)return b;b=Comparer<T3>.Default.Compare(Item3,a.Item3);if(b!=0)return b;return Comparer<T4>.Default.Compare(Item4,a.Item4);}}public static class HashHelpers{public static readonly int RandomSeed=new System.Random().Next(int.MinValue,int.MaxValue);public static int Combine(int a,int b){uint c=((uint)a<<5)|((uint)a>>27);return((int)c+a)^b;}public static int CombineHashCodes(int a,int b){return Combine(Combine(RandomSeed,a),b);}public static int CombineHashCodes(int a,int b,int c){return Combine(CombineHashCodes(a,b),c);}public static int CombineHashCodes(int a,int b,int c,int d){return Combine(CombineHashCodes(a,b,c),d);}}public class HashMap<K,V>:System.Collections.Generic.Dictionary<K,V>{V i;static Func<V>j=System.Linq.Expressions.Expression.Lambda<Func<V>>(System.Linq.Expressions.Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V a){i=a;}new public V this[K a]{get{V b;if(TryGetValue(a,out b))return b;else return base[a]=i!=null?i:j();}set{base[a]=value;}}}public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public readonly static int[]DXY4={0,1,0,-1,0};public readonly static int[]DXY8={1,1,0,1,-1,0,-1,-1,1};public static void DontAutoFlush(){var a=new System.IO.StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(a);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]a){Array.Sort<T>(a);return a;}public static T[]SortDecend<T>(T[]a){Array.Sort<T>(a);Array.Reverse(a);return a;}public static void Swap<T>(ref T a,ref T b){T c=a;a=b;b=c;}public static long GCD(long a,long b){while(b!=0){long c=a;a=b;b=c%b;}return a;}public static long LCM(long a,long b){if(a==0||b==0)return 0;return a*b/GCD(a,b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static void ChMax(ref int a,int b){if(a<b)a=b;}public static void ChMin(ref int a,int b){if(a>b)a=b;}public static void FillArray<T>(T[]a,T b){int c=a.Length;for(int d=0;d<c;d++)a[d]=b;}public static void FillArray<T>(T[,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);for(int e=0;e<c;e++)for(int f=0;f<d;f++){a[e,f]=b;}}public static void FillArray<T>(T[,,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);int e=a.GetLength(2);for(int f=0;f<c;f++)for(int g=0;g<d;g++){for(int h=0;h<e;h++){a[f,g,h]=b;}}}public static long[]Accumulate(long[]a){long[]b=new long[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}public static double[]Accumulate(double[]a){double[]b=new double[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}}public static class Cin{public static int ri{get{return ReadInt();}}public static int[]ria{get{return ReadIntArray();}}public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static string[]rsa{get{return ReadStringArray();}}public static int ReadInt(){return int.Parse(i());}public static long ReadLong(){return long.Parse(i());}public static double ReadDouble(){return double.Parse(i());}public static string ReadString(){return i();}public static int[]ReadIntArray(){g=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){g=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){g=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static string[]ReadStringArray(){g=null;return Console.ReadLine().Split(' ');}public static void ReadCol(out long[]a,long b){a=new long[b];for(int c=0;c<b;c++)a[c]=ReadLong();}public static void ReadCols(out long[]a,out long[]b,long c){a=new long[c];b=new long[c];for(int d=0;d<c;d++){a[d]=ReadLong();b[d]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long d){a=new long[d];b=new long[d];c=new long[d];for(int e=0;e<d;e++){a[e]=ReadLong();b[e]=ReadLong();c[e]=ReadLong();}}public static int[,]ReadIntTable(int a,int b){g=null;int[,]c=new int[a,b];for(int d=0;d<a;d++)for(int e=0;e<b;e++){c[d,e]=ReadInt();}return c;}public static long[,]ReadLongTable(long a,long b){g=null;long[,]c=new long[a,b];for(int d=0;d<a;d++)for(int e=0;e<b;e++){c[d,e]=ReadLong();}return c;}public static char[,]ReadCharTable(int a,int b){g=null;char[,]c=new char[a,b];for(int d=0;d<a;d++){var e=ReadString();for(int f=0;f<b;f++)c[d,f]=e[f];}return c;}static string[]g;static int h;static string i(){if(g==null||g.Length<=h){g=Console.ReadLine().Split(' ');h=0;}return g[h++];}}
    }
}