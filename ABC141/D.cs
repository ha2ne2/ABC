using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static ABC141.D.Cin;
using static ABC141.D.Util;
// using Pair = System.ValueTuple<long, long>;

/// <summary>
/// ABC141
/// D - Powerful Discount Tickets
/// https://atcoder.jp/contests/ABC141/tasks/abc141_d
/// </summary>
namespace ABC141.D
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int N = ri;
            int M = ri;

            PriorityQueue<long> pq =
                new PriorityQueue<long>(PriorityQueue<long>.Order.Descend);

            for (int i = 0; i < N; i++)
            {
                pq.Enqueue(ri);
            }

            for (int i = 0; i < M; i++)
            {
                var max = pq.Dequeue();
                pq.Enqueue(max / 2);
            }

            long ans = pq.Heap.Sum();
            Console.WriteLine(ans);

        }

        /// <summary>
        /// 優先度付きキュー
        /// 2020/02/13
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class PriorityQueue<T>
        {
            #region public

            public enum Order
            {
                Ascend,
                Descend
            }

            public PriorityQueue() : this(Comparer<T>.Default.Compare) { }
            public PriorityQueue(Comparison<T> comparison)
            {
                Heap = new List<T>();
                Compare = comparison;
            }

            public PriorityQueue(Order order)
            {
                Heap = new List<T>();
                Comparison<T> defaultCompare = Comparer<T>.Default.Compare;
                if (order == Order.Descend)
                {
                    Compare = (x, y) => defaultCompare(x, y) * -1;
                }
                else
                {
                    Compare = defaultCompare;
                }
            }

            public void Enqueue(T item)
            {
                Heap.Add(default(T));
                int i = Size;
                Size++;
                while (i > 0)
                {
                    int p = (i - 1) >> 1;
                    if (Compare(Heap[p], item) <= 0)
                        break;
                    Heap[i] = Heap[p];
                    i = p;
                }
                Heap[i] = item;
            }

            public T Dequeue()
            {
                T ret = Heap[0];
                Size--;
                T x = Heap[Size];
                Heap[Size] = default(T);
                int i = 0;
                while ((i << 1) + 1 < Size)
                {
                    int l = (i << 1) + 1;
                    int r = l + 1;
                    if (r < Size && Compare(Heap[r], Heap[l]) < 0)
                        l = r;
                    if (Compare(x, Heap[l]) <= 0)
                        break;
                    Heap[i] = Heap[l];
                    i = l;
                }
                Heap[i] = x;
                return ret;
            }

            public T Peek() { return Heap[0]; }
            public int Count { get { return Size; } }
            public bool Any() { return Size > 0; }
            public bool IsEmpty() { return Size == 0; }

            #endregion

            #region private

            public readonly List<T> Heap;
            private readonly Comparison<T> Compare;
            private int Size;

            #endregion
        }
    }

    /// <summary>
    /// 競プロライブラリ
    /// https://github.com/ha2ne2/ABC/tree/master/Lib
    /// </summary>
    public struct Mint:System.IComparable<Mint>,System.IEquatable<Mint>{public static readonly long MOD=(long)1e9+7;public long Value;public Mint(long val){Value=val%MOD;if(Value<0)Value+=MOD;}private static Mint Ctor(long val){return new Mint(){Value=val};}public static Mint operator+(Mint a,Mint b){long res=a.Value+b.Value;if(res>MOD)res-=MOD;return Ctor(res);}public static Mint operator-(Mint a,Mint b){long res=a.Value-b.Value;if(res<0)res+=MOD;return Ctor(res);}public static Mint operator*(Mint a,Mint b){long res=a.Value*b.Value;if(res>MOD)res%=MOD;return Ctor(res);}public static Mint operator/(Mint a,Mint b){return a*Inv(b);}public override bool Equals(object obj){return obj is Mint&&Value==((Mint)obj).Value;}public override int GetHashCode(){return Value.GetHashCode();}public override string ToString(){return Value.ToString();}public static implicit operator Mint(long a){return new Mint(a);}public static explicit operator long(Mint a){return a.Value;}public static Mint Pow(Mint a,long n){if(n==0)return new Mint(1);Mint b=Pow(a,n>>1);b*=b;if((n&1)==1)b*=a;return b;}public static Mint Inv(Mint n){long a=n.Value;long b=MOD;long x=1;long u=0;while(b!=0){long k=a/b;long _x=u;u=x-k*u;x=_x;long _a=a;a=b;b=_a-(k*b);}return new Mint(x);}public bool Equals(Mint other){return Value==other.Value;}public int CompareTo(Mint other){return Comparer<long>.Default.Compare(Value,other.Value);}}public class HashMap<K,V>:System.Collections.Generic.Dictionary<K,V>{private V DefaultValue;private static Func<V>CreateInstance=System.Linq.Expressions.Expression.Lambda<Func<V>>(System.Linq.Expressions.Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V defaultValue){DefaultValue=defaultValue;}new public V this[K i]{get{V v;if(TryGetValue(i,out v)){return v;}else{return base[i]=DefaultValue!=null?DefaultValue:CreateInstance();}}set{base[i]=value;}}}public static class Cin{public static int ri{get{return ReadInt();}}public static int[]ria{get{return ReadIntArray();}}public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static string[]rsa{get{return ReadStringArray();}}public static int ReadInt(){return int.Parse(Next());}public static long ReadLong(){return long.Parse(Next());}public static double ReadDouble(){return double.Parse(Next());}public static string ReadString(){return Next();}public static int[]ReadIntArray(){Tokens=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){Tokens=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){Tokens=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static string[]ReadStringArray(){Tokens=null;return Console.ReadLine().Split(' ');}public static void ReadCol(out long[]a,long N){a=new long[N];for(int i=0;i<N;i++){a[i]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,long N){a=new long[N];b=new long[N];for(int i=0;i<N;i++){a[i]=ReadLong();b[i]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long N){a=new long[N];b=new long[N];c=new long[N];for(int i=0;i<N;i++){a[i]=ReadLong();b[i]=ReadLong();c[i]=ReadLong();}}public static int[,]ReadIntTable(int h,int w){Tokens=null;int[,]ret=new int[h,w];for(int i=0;i<h;i++){for(int j=0;j<w;j++){ret[i,j]=ReadInt();}}return ret;}public static long[,]ReadLongTable(long h,long w){Tokens=null;long[,]ret=new long[h,w];for(int i=0;i<h;i++){for(int j=0;j<w;j++){ret[i,j]=ReadLong();}}return ret;}public static char[,]ReadCharTable(int h,int w){Tokens=null;char[,]res=new char[h,w];for(int i=0;i<h;i++){string s=ReadString();for(int j=0;j<w;j++){res[i,j]=s[j];}}return res;}private static string[]Tokens;private static int Pointer;private static string Next(){if(Tokens==null||Tokens.Length<=Pointer){Tokens=Console.ReadLine().Split(' ');Pointer=0;}return Tokens[Pointer++];}}public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public readonly static int[]DXY4={0,1,0,-1,0};public readonly static int[]DXY8={1,1,0,1,-1,0,-1,-1,1};public static void DontAutoFlush(){if(Console.IsOutputRedirected)return;var sw=new System.IO.StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(sw);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]array){Array.Sort<T>(array);return array;}public static T[]SortDecend<T>(T[]array){Array.Sort<T>(array);Array.Reverse(array);return array;}public static void Swap<T>(ref T a,ref T b){T _a=a;a=b;b=_a;}public static long GCD(long a,long b){while(b!=0){long _a=a;a=b;b=_a%b;}return a;}public static long LCM(long a,long b){if(a==0||b==0)return 0;return a*b/GCD(a,b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static void ChMax(ref int a,int b){if(a<b)a=b;}public static void ChMin(ref int a,int b){if(a>b)a=b;}public static void FillArray<T>(T[]array,T value){int max=array.Length;for(int i=0;i<max;i++){array[i]=value;}}public static void FillArray<T>(T[,]array,T value){int max0=array.GetLength(0);int max1=array.GetLength(1);for(int i=0;i<max0;i++){for(int j=0;j<max1;j++){array[i,j]=value;}}}public static void FillArray<T>(T[,,]array,T value){int max0=array.GetLength(0);int max1=array.GetLength(1);int max2=array.GetLength(2);for(int i=0;i<max0;i++){for(int j=0;j<max1;j++){for(int k=0;k<max2;k++){array[i,j,k]=value;}}}}public static long[]Accumulate(long[]array){long[]acc=new long[array.Length+1];for(int i=0;i<array.Length;i++){acc[i+1]=acc[i]+array[i];}return acc;}public static double[]Accumulate(double[]array){double[]acc=new double[array.Length+1];for(int i=0;i<array.Length;i++){acc[i+1]=acc[i]+array[i];}return acc;}}
}
