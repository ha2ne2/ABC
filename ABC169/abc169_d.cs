using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static ABC169.abc169_d.Cin;
using static ABC169.abc169_d.Util;
using Pair = ABC169.abc169_d.VTuple<long, long>;

/// <summary>
/// ABC169
/// D - Div Game
/// https://atcoder.jp/contests/ABC169/tasks/abc169_d
/// </summary>
namespace ABC169.abc169_d
{
    public class Program
    {
        public static void Main(string[] args)
        {
            long N = rl;
            var dict = PrimeFactorize(N);

            long ans = 0;
            foreach(var kvp in dict)
            {
                var val = kvp.Value;

                for (int i = 1; i <= val; i++)
                {
                    val -= i;
                    ans++;
                }
            }

            Console.WriteLine(ans);

        }
        
        /// <summary>
        /// nを素因数分解し、キーが素数、値が指数のディクショナリを返す
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Dictionary<long,long> PrimeFactorize(long n)
        {
            Dictionary<long, long> dic = new Dictionary<long, long>();

            if (n % 2 == 0)
            {
                n /= 2;
                dic[2] = 1;
                while (n % 2 == 0)
                {
                    n /= 2;
                    dic[2]++;
                }
            }

            for (long i = 3; i * i <= n; i+=2)
            {
                if (n % i == 0)
                {
                    n /= i;
                    dic[i] = 1;
                    while (n % i == 0)
                    {
                        n /= i;
                        dic[i]++;
                    }
                }
            }

            if (n != 1)
                dic[n] = 1;

            return dic;
        }
    }

    /// <summary>
    /// 競プロライブラリ
    /// https://github.com/ha2ne2/ABC/tree/master/Lib
    /// </summary>
    public struct Mint:System.IComparable<Mint>,System.IEquatable<Mint>{public static readonly long MOD=(long)1e9+7;public long Value;public Mint(long val){Value=val%MOD;if(Value<0)Value+=MOD;}private static Mint Ctor(long val){return new Mint(){Value=val};}public static Mint operator+(Mint a,Mint b){long res=a.Value+b.Value;if(res>MOD)res-=MOD;return Ctor(res);}public static Mint operator-(Mint a,Mint b){long res=a.Value-b.Value;if(res<0)res+=MOD;return Ctor(res);}public static Mint operator*(Mint a,Mint b){long res=a.Value*b.Value;if(res>MOD)res%=MOD;return Ctor(res);}public static Mint operator/(Mint a,Mint b){return a*Inv(b);}public override bool Equals(object obj){return obj is Mint&&Value==((Mint)obj).Value;}public override int GetHashCode(){return Value.GetHashCode();}public override string ToString(){return Value.ToString();}public static implicit operator Mint(long a){return new Mint(a);}public static explicit operator long(Mint a){return a.Value;}public static Mint Pow(Mint a,long n){if(n==0)return new Mint(1);Mint b=Pow(a,n>>1);b*=b;if((n&1)==1)b*=a;return b;}public static Mint Inv(Mint n){long a=n.Value;long b=MOD;long x=1;long u=0;while(b!=0){long k=a/b;long _x=u;u=x-k*u;x=_x;long _a=a;a=b;b=_a-(k*b);}return new Mint(x);}public bool Equals(Mint other){return Value==other.Value;}public int CompareTo(Mint other){return Comparer<long>.Default.Compare(Value,other.Value);}}public class HashMap<K,V>:System.Collections.Generic.Dictionary<K,V>{private V DefaultValue;private static Func<V>CreateInstance=System.Linq.Expressions.Expression.Lambda<Func<V>>(System.Linq.Expressions.Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V defaultValue){DefaultValue=defaultValue;}new public V this[K i]{get{V v;if(TryGetValue(i,out v)){return v;}else{return base[i]=DefaultValue!=null?DefaultValue:CreateInstance();}}set{base[i]=value;}}}public struct VTuple<T1,T2>:System.IComparable<VTuple<T1,T2>>,System.IEquatable<VTuple<T1,T2>>{public T1 Item1;public T2 Item2;public T1 First{get{return Item1;}}public T2 Second{get{return Item2;}}public VTuple(T1 item1,T2 item2){Item1=item1;Item2=item2;}public override bool Equals(object obj){return obj is VTuple<T1,T2>&&Equals((VTuple<T1,T2>)obj);}public override int GetHashCode(){int h1=Item1!=null?Item1.GetHashCode():0;int h2=Item2!=null?Item2.GetHashCode():0;return HashHelpers.CombineHashCodes(h1,h2);}public override string ToString(){return"("+Item1?.ToString()+", "+Item2?.ToString()+")";}public bool Equals(VTuple<T1,T2>other){return EqualityComparer<T1>.Default.Equals(Item1,other.Item1)&&EqualityComparer<T2>.Default.Equals(Item2,other.Item2);}public int CompareTo(VTuple<T1,T2>other){int c=Comparer<T1>.Default.Compare(Item1,other.Item1);if(c!=0)return c;return Comparer<T2>.Default.Compare(Item2,other.Item2);}}public struct VTuple3<T1,T2,T3>:System.IComparable<VTuple3<T1,T2,T3>>,System.IEquatable<VTuple3<T1,T2,T3>>{public T1 Item1;public T2 Item2;public T3 Item3;public VTuple3(T1 item1,T2 item2,T3 item3){Item1=item1;Item2=item2;Item3=item3;}public override bool Equals(object obj){return obj is VTuple3<T1,T2,T3>&&Equals((VTuple3<T1,T2,T3>)obj);}public override int GetHashCode(){int h1=Item1!=null?Item1.GetHashCode():0;int h2=Item2!=null?Item2.GetHashCode():0;int h3=Item3!=null?Item3.GetHashCode():0;return HashHelpers.CombineHashCodes(h1,h2,h3);}public override string ToString(){return"("+Item1?.ToString()+", "+Item2?.ToString()+", "+Item3?.ToString()+")";}public bool Equals(VTuple3<T1,T2,T3>other){return EqualityComparer<T1>.Default.Equals(Item1,other.Item1)&&EqualityComparer<T2>.Default.Equals(Item2,other.Item2)&&EqualityComparer<T3>.Default.Equals(Item3,other.Item3);}public int CompareTo(VTuple3<T1,T2,T3>other){int c=Comparer<T1>.Default.Compare(Item1,other.Item1);if(c!=0)return c;c=Comparer<T2>.Default.Compare(Item2,other.Item2);if(c!=0)return c;return Comparer<T3>.Default.Compare(Item3,other.Item3);}}public struct VTuple4<T1,T2,T3,T4>:System.IComparable<VTuple4<T1,T2,T3,T4>>,System.IEquatable<VTuple4<T1,T2,T3,T4>>{public T1 Item1;public T2 Item2;public T3 Item3;public T4 Item4;public VTuple4(T1 item1,T2 item2,T3 item3,T4 item4){Item1=item1;Item2=item2;Item3=item3;Item4=item4;}public override bool Equals(object obj){return obj is VTuple4<T1,T2,T3,T4>&&Equals((VTuple4<T1,T2,T3,T4>)obj);}public override int GetHashCode(){int h1=Item1!=null?Item1.GetHashCode():0;int h2=Item2!=null?Item2.GetHashCode():0;int h3=Item3!=null?Item3.GetHashCode():0;int h4=Item3!=null?Item4.GetHashCode():0;return HashHelpers.CombineHashCodes(h1,h2,h3,h4);}public override string ToString(){return"("+Item1?.ToString()+", "+Item2?.ToString()+", "+Item3?.ToString()+", "+Item4?.ToString()+")";}public bool Equals(VTuple4<T1,T2,T3,T4>other){return EqualityComparer<T1>.Default.Equals(Item1,other.Item1)&&EqualityComparer<T2>.Default.Equals(Item2,other.Item2)&&EqualityComparer<T3>.Default.Equals(Item3,other.Item3)&&EqualityComparer<T4>.Default.Equals(Item4,other.Item4);}public int CompareTo(VTuple4<T1,T2,T3,T4>other){int c=Comparer<T1>.Default.Compare(Item1,other.Item1);if(c!=0)return c;c=Comparer<T2>.Default.Compare(Item2,other.Item2);if(c!=0)return c;c=Comparer<T3>.Default.Compare(Item3,other.Item3);if(c!=0)return c;return Comparer<T4>.Default.Compare(Item4,other.Item4);}}public static class HashHelpers{public static readonly int RandomSeed=new System.Random().Next(int.MinValue,int.MaxValue);public static int Combine(int h1,int h2){uint rol5=((uint)h1<<5)|((uint)h1>>27);return((int)rol5+h1)^h2;}public static int CombineHashCodes(int h1,int h2){return Combine(Combine(RandomSeed,h1),h2);}public static int CombineHashCodes(int h1,int h2,int h3){return Combine(CombineHashCodes(h1,h2),h3);}public static int CombineHashCodes(int h1,int h2,int h3,int h4){return Combine(CombineHashCodes(h1,h2,h3),h4);}}public static class Cin{public static int ri{get{return ReadInt();}}public static int[]ria{get{return ReadIntArray();}}public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static string[]rsa{get{return ReadStringArray();}}public static int ReadInt(){return int.Parse(Next());}public static long ReadLong(){return long.Parse(Next());}public static double ReadDouble(){return double.Parse(Next());}public static string ReadString(){return Next();}public static int[]ReadIntArray(){Tokens=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){Tokens=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){Tokens=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static string[]ReadStringArray(){Tokens=null;return Console.ReadLine().Split(' ');}public static void ReadCol(out long[]a,long N){a=new long[N];for(int i=0;i<N;i++){a[i]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,long N){a=new long[N];b=new long[N];for(int i=0;i<N;i++){a[i]=ReadLong();b[i]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long N){a=new long[N];b=new long[N];c=new long[N];for(int i=0;i<N;i++){a[i]=ReadLong();b[i]=ReadLong();c[i]=ReadLong();}}public static int[,]ReadIntTable(int h,int w){Tokens=null;int[,]ret=new int[h,w];for(int i=0;i<h;i++){for(int j=0;j<w;j++){ret[i,j]=ReadInt();}}return ret;}public static long[,]ReadLongTable(long h,long w){Tokens=null;long[,]ret=new long[h,w];for(int i=0;i<h;i++){for(int j=0;j<w;j++){ret[i,j]=ReadLong();}}return ret;}public static char[,]ReadCharTable(int h,int w){Tokens=null;char[,]res=new char[h,w];for(int i=0;i<h;i++){string s=ReadString();for(int j=0;j<w;j++){res[i,j]=s[j];}}return res;}private static string[]Tokens;private static int Pointer;private static string Next(){if(Tokens==null||Tokens.Length<=Pointer){Tokens=Console.ReadLine().Split(' ');Pointer=0;}return Tokens[Pointer++];}}public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public readonly static int[]DXY4={0,1,0,-1,0};public readonly static int[]DXY8={1,1,0,1,-1,0,-1,-1,1};public static void DontAutoFlush(){if(Console.IsOutputRedirected)return;var sw=new System.IO.StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(sw);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]array){Array.Sort<T>(array);return array;}public static T[]SortDecend<T>(T[]array){Array.Sort<T>(array);Array.Reverse(array);return array;}public static void Swap<T>(ref T a,ref T b){T _a=a;a=b;b=_a;}public static long GCD(long a,long b){while(b!=0){long _a=a;a=b;b=_a%b;}return a;}public static long LCM(long a,long b){if(a==0||b==0)return 0;return a*b/GCD(a,b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static void ChMax(ref int a,int b){if(a<b)a=b;}public static void ChMin(ref int a,int b){if(a>b)a=b;}public static void FillArray<T>(T[]array,T value){int max=array.Length;for(int i=0;i<max;i++){array[i]=value;}}public static void FillArray<T>(T[,]array,T value){int max0=array.GetLength(0);int max1=array.GetLength(1);for(int i=0;i<max0;i++){for(int j=0;j<max1;j++){array[i,j]=value;}}}public static void FillArray<T>(T[,,]array,T value){int max0=array.GetLength(0);int max1=array.GetLength(1);int max2=array.GetLength(2);for(int i=0;i<max0;i++){for(int j=0;j<max1;j++){for(int k=0;k<max2;k++){array[i,j,k]=value;}}}}public static long[]Accumulate(long[]array){long[]acc=new long[array.Length+1];for(int i=0;i<array.Length;i++){acc[i+1]=acc[i]+array[i];}return acc;}public static double[]Accumulate(double[]array){double[]acc=new double[array.Length+1];for(int i=0;i<array.Length;i++){acc[i+1]=acc[i]+array[i];}return acc;}}
}
