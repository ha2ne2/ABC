using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static ABC159.E.Cin;
using static ABC159.E.Util;
using Pair = ABC159.E.VTuple<long, long>;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<long>>;
using System.Text;

namespace ABC159
{
    public class E
    {
        public static void Main(string[] args)
        {
            long H = rl;
            long W = rl;
            long K = rl;
            long[,] A = new long[H, W];
            for (int i = 0; i < H; i++)
            {
                string tmp = rs;
                for (int j = 0; j < W; j++)
                {
                    A[i, j] = tmp[j]-'0';
                }
            }

            long[,] s = new long[H + 1, W + 1];
            for (int i = 0; i < H; ++i)
            {
                for (int j = 0; j < W; ++j)
                {
                    s[i + 1, j + 1] = s[i, j + 1] + s[i + 1, j] - s[i, j] + A[i, j];
                }
            }

            var memo = new HashMap<VTuple<VTuple<int, int>, VTuple<int, int>>, int>();
            Func<int, int, int, int, int> rec = null;
            rec = (x1, y1, x2, y2) =>
            {
                var t = s[x2, y2] - s[x1, y2] - s[x2, y1] + s[x1, y1];
                if (t <= K)
                {
                    return 0;
                }
                else
                {
                    var from = new VTuple<int, int>(x1, y1);
                    var to = new VTuple<int, int>(x2, y2);
                    var key = new VTuple<VTuple<int, int>, VTuple<int, int>>(from, to);

                    if (memo.ContainsKey(key))
                    {
                        return memo[key];
                    }
                    int min = int.MaxValue;

                    // horizontal cut
                    for (int h = x1 + 1; h < x2; h++)
                    {
                        var t1 = rec(x1, y1, h, y2);
                        var t2 = rec(h, y1, x2, y2);
                        min = Min(min, t1 + t2 + 1);
                    }

                    // vertical cut
                    for (int w = y1 + 1; w < y2; w++)
                    {
                        var t1 = rec(x1, y1, x2, w);
                        var t2 = rec(x1, w, x2, y2);
                        min = Min(min, t1 + t2 + 1);
                    }

                    memo[key] = min;
                    return min;
                }
            };

            int ans = rec(0, 0, (int)H, (int)W);
            Console.WriteLine(ans);
        }


        public struct VTuple<T1,T2>:System.IComparable<VTuple<T1,T2>>,System.IEquatable<VTuple<T1,T2>>{public T1 First;public T2 Second;public VTuple(T1 a,T2 b){First=a;Second=b;}public int CompareTo(VTuple<T1,T2>a){int b=Comparer<T1>.Default.Compare(First,a.First);if(b!=0)return b;return Comparer<T2>.Default.Compare(Second,a.Second);}public override bool Equals(object a){return a is VTuple<T1,T2>&&Equals((VTuple<T1,T2>)a);}public bool Equals(VTuple<T1,T2>a){return EqualityComparer<T1>.Default.Equals(First,a.First)&&EqualityComparer<T2>.Default.Equals(Second,a.Second);}public override int GetHashCode(){int a=First!=null?First.GetHashCode():0;int b=Second!=null?Second.GetHashCode():0;uint c=((uint)a<<5)|((uint)a>>27);return((int)c+a)^b;}}public class HashMap<K,V>:System.Collections.Generic.Dictionary<K,V>{V i;static Func<V>j=System.Linq.Expressions.Expression.Lambda<Func<V>>(System.Linq.Expressions.Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V a){i=a;}new public V this[K a]{get{V b;if(TryGetValue(a,out b))return b;else return base[a]=i!=null?i:j();}set{base[a]=value;}}}public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public readonly static int[]DXY4={0,1,0,-1,0};public readonly static int[]DXY8={1,1,0,1,-1,0,-1,-1,1};public static void DontAutoFlush(){var a=new System.IO.StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(a);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]a){Array.Sort<T>(a);return a;}public static T[]SortDecend<T>(T[]a){Array.Sort<T>(a);Array.Reverse(a);return a;}public static void Swap<T>(ref T a,ref T b){T c=a;a=b;b=c;}public static int GCD(int a,int b){return(b==0)?a:GCD(b,a%b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static long ModAdd(long a,long b){long c=a+b;if(c>=MOD)return c%MOD;return c;}public static long ModMul(long a,long b){long c=a*b;if(c>=MOD)return c%MOD;return c;}public static void ChModAdd(ref long a,long b){a+=b;if(a>=MOD)a%=MOD;}public static void ChModMul(ref long a,long b){a*=b;if(a>=MOD)a%=MOD;}public static void FillArray<T>(T[]a,T b){int c=a.Length;for(int d=0;d<c;d++)a[d]=b;}public static void FillArray<T>(T[,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);for(int e=0;e<c;e++)for(int f=0;f<d;f++){a[e,f]=b;}}public static void FillArray<T>(T[,,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);int e=a.GetLength(2);for(int f=0;f<c;f++)for(int g=0;g<d;g++){for(int h=0;h<e;h++){a[f,g,h]=b;}}}public static long[]Accumulate(long[]a){long[]b=new long[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}public static double[]Accumulate(double[]a){double[]b=new double[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}}public static class Cin{public static int ri{get{return ReadInt();}}public static int[]ria{get{return ReadIntArray();}}public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static string[]rsa{get{return ReadStringArray();}}public static int ReadInt(){return int.Parse(i());}public static long ReadLong(){return long.Parse(i());}public static double ReadDouble(){return double.Parse(i());}public static string ReadString(){return i();}public static int[]ReadIntArray(){g=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){g=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){g=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static string[]ReadStringArray(){g=null;return Console.ReadLine().Split(' ');}public static void ReadCol(out long[]a,long b){a=new long[b];for(int c=0;c<b;c++)a[c]=ReadLong();}public static void ReadCols(out long[]a,out long[]b,long c){a=new long[c];b=new long[c];for(int d=0;d<c;d++){a[d]=ReadLong();b[d]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long d){a=new long[d];b=new long[d];c=new long[d];for(int e=0;e<d;e++){a[e]=ReadLong();b[e]=ReadLong();c[e]=ReadLong();}}public static int[,]ReadIntTable(int a,int b){g=null;int[,]c=new int[a,b];for(int d=0;d<a;d++)for(int e=0;e<b;e++){c[d,e]=ReadInt();}return c;}public static long[,]ReadLongTable(long a,long b){g=null;long[,]c=new long[a,b];for(int d=0;d<a;d++)for(int e=0;e<b;e++){c[d,e]=ReadLong();}return c;}public static char[,]ReadCharTable(int a,int b){g=null;char[,]c=new char[a,b];for(int d=0;d<a;d++){var e=ReadString();for(int f=0;f<b;f++)c[d,f]=e[f];}return c;}static string[]g;static int h;static string i(){if(g==null||g.Length<=h){g=Console.ReadLine().Split(' ');h=0;}return g[h++];}}
    }
}