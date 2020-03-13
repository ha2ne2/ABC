using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static _20200312.Cin;
using static _20200312.Util;
using Pair = _20200312.VTuple<long, long>;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<long>>;
using System.Text;

namespace _20200312
{
    public class Dijkstra
    {
        public int N;
        public long[] Costs;
        public List<List<VTuple<long, int>>> Graph; // first:cost, second:v
        public Dijkstra(int n)
        {
            N = n;
            Graph = new List<List<VTuple<long, int>>>();
            for (int i = 0; i < N; i++)
            {
                Graph.Add(new List<VTuple<long, int>>());
            }
            Costs = new long[N];
        }

        public void AddPath(int from, int to, long cost)
        {
            Graph[from].Add(new VTuple<long, int>(cost, to));
        }

        public void Solve(int from)
        {
            Util.FillArray(Costs, long.MaxValue);
            Costs[from] = 0;
            var pq = new PriorityQueue<VTuple<long, int>>(); // first:cost, second:v
            pq.Enqueue(new VTuple<long, int>(0, from));
            while (pq.Any())
            {
                var v = pq.Dequeue();
                if (v.First > Costs[v.Second]) continue;

                foreach(var edge in Graph[v.Second])
                {
                    var nCost = Costs[v.Second] + edge.First;
                    if(nCost < Costs[edge.Second])
                    {
                        Costs[edge.Second] = nCost;
                        pq.Enqueue(new VTuple<long, int>(nCost, edge.Second));
                    }
                }
            }
        }
    }
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

        private readonly List<T> Heap;
        private readonly Comparison<T> Compare;
        private int Size;

        #endregion

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Joi2009ho_B(); 37m
            // Arc084_A();    36m
            // Abc099_C(); 30m
            // Abc027_B(); 30m
            // Abc076_C(); 30m

            Abc035_D();
        }

        public static void Abc035_D()
        {
            long N = rl;
            long M = rl;
            long T = rl;
            long[] A = rla;

            Dijkstra dk = new Dijkstra((int)N);
            Dijkstra dkr = new Dijkstra((int)N);
            for (int i = 0; i < M; i++)
            {
                int from = ri - 1;
                int to = ri - 1;
                long cost = rl;
                dk.AddPath(from, to, cost);
                dkr.AddPath(to, from, cost);
            }
            dk.Solve(0);
            dkr.Solve(0);

            long ans = 0;
            for (int i = 0; i < N; i++)
            {
                if (dk.Costs[i] == long.MaxValue || dkr.Costs[i] == long.MaxValue)
                    continue;
                ChMax(ref ans, A[i] * (T - dk.Costs[i] - dkr.Costs[i]));
            }

            Console.WriteLine(ans);
        }

        public static void Abc076_C()
        {
            string s = rs;
            string t = rs;

            int sLen = s.Length;
            int tLen = t.Length;
            for (int i = sLen - tLen; i >= 0; i--)
            {
                bool ok = true;
                for (int j = 0; j < tLen; j++)
                {
                    if (!(s[i + j] == t[j] || s[i + j] == '?'))
                    {
                        ok = false;
                        break;
                    }                        
                }

                if (ok)
                {
                    char[] ans = s.Replace('?', 'a').ToArray();
                    for (int j = 0; j < tLen; j++)
                    {
                        ans[i + j] = t[j];
                    }
                    Console.WriteLine(new String(ans));
                    return;
                }
            }

            Console.WriteLine("UNRESTORABLE");
        }

        public static void Abc027_B()
        {
            long N = rl;
            long[] A = rla;

            long sum = A.Sum();
            if(sum % N != 0)
            {
                Console.WriteLine(-1);
                return;
            }

            long ave = sum / N;
            long cur = 0;
            long ans = 0;
            for (int i = 0; i < N; i++)
            {
                cur += A[i] - ave;

                if (cur != 0)
                {
                    ans++;
                }
            }

            Console.WriteLine(ans);
        }

        public static void Abc099_C()
        {
            long N = rl;
            long[] dp = new long[N+1];
            FillArray(dp, INF);
            dp[0] = 0;

            List<long> candidates = new List<long>();
            for (int i = 1; i <= 6; i++)
            {
                candidates.Add((long)Math.Pow(9, i));
            }

            for (int i = 1; i <= 7; i++)
            {
                candidates.Add((long)Math.Pow(6, i));
            }

            candidates.Add(1);

            for (int i = 0; i < N; i++)
            {
                foreach(var c in candidates)
                {
                    if (i + c <= N)
                    {
                        dp[i + c] = Min(dp[i + c], dp[i] + 1);
                    }
                }
            }

            Console.WriteLine(dp[N]);
        }

        public static void Arc084_A()
        {
            long n = rl;
            long[] a = rla;
            long[] b = rla;
            long[] c = rla;
            Sort(a);
            Sort(b);
            Sort(c);

            Func<long, long[], long> nibutan = (target, ary) =>
            {
                long ok = n;
                long ng = -1;

                while (Abs(ok - ng) != 1)
                {
                    var mid = (ok + ng) / 2;
                    if (target < ary[mid])
                    {
                        ok = mid;
                    }
                    else
                    {
                        ng = mid;
                    }
                }

                return ok;
            };

            long[] b2 = new long[n];
            for (int i = 0; i < n; i++)
            {
                b2[i] = n - nibutan(b[i], c);
            }
            Array.Reverse(b2);
            var b3 = Accumulate(b2);
            Array.Reverse(b3);

            long ans = 0;
            for (int i = 0; i < n; i++)
            {
                var bIdx = nibutan(a[i], b);
                if (bIdx == n) break;
                ans += b3[bIdx];
            }

            Console.WriteLine(ans);
        }

        public static void Joi2009ho_B()
        {
            long d = rl;
            long n = rl;
            long m = rl;
            long[] a = new long[n+1];
            a[0] = 0;
            a[n] = d;
            for (int i = 1; i < n; i++)
            {
                a[i] = rl;
            }
            Sort(a);
            long[] b;
            ReadCol(out b, m);

            long ans = 0;
           
            foreach (var target in b)
            {
                long ok = n;
                long ng = 0;
                while (Abs(ok - ng) != 1)
                {
                    long mid = (ok + ng) / 2;
                    if (target < a[mid])
                    {
                        ok = mid;
                    }
                    else
                    {
                        ng = mid;
                    }
                }
                ans += Min(Abs(target - a[ok]), Abs(target - a[ng]));
            }

            Console.WriteLine(ans);
        }
    }

    public struct VTuple<T1,T2>:IComparable<VTuple<T1,T2>>,IEquatable<VTuple<T1,T2>>{public T1 First;public T2 Second;public VTuple(T1 a,T2 b){First=a;Second=b;}public int CompareTo(VTuple<T1,T2>a){int b=Comparer<T1>.Default.Compare(First,a.First);if(b!=0)return b;return Comparer<T2>.Default.Compare(Second,a.Second);}public override bool Equals(object a){return a is VTuple<T1,T2>&&Equals((VTuple<T1,T2>)a);}public bool Equals(VTuple<T1,T2>a){return EqualityComparer<T1>.Default.Equals(First,a.First)&&EqualityComparer<T2>.Default.Equals(Second,a.Second);}public override int GetHashCode(){int a=First!=null?First.GetHashCode():0;int b=Second!=null?Second.GetHashCode():0;uint c=((uint)a<<5)|((uint)a>>27);return((int)c+a)^b;}}
    public class HashMap<K,V>:Dictionary<K,V>{V i;static Func<V>j=System.Linq.Expressions.Expression.Lambda<Func<V>>(System.Linq.Expressions.Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V a){i=a;}new public V this[K a]{get{V b;if(TryGetValue(a,out b))return b;else return base[a]=i!=null?i:j();}set{base[a]=value;}}}
    public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public readonly static int[]DXY4={0,1,0,-1,0};public readonly static int[]DXY8={1,1,0,1,-1,0,-1,-1,1};public static void DontAutoFlush(){var a=new System.IO.StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(a);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]a){Array.Sort<T>(a);return a;}public static T[]SortDecend<T>(T[]a){Array.Sort<T>(a);Array.Reverse(a);return a;}public static void Swap<T>(ref T a,ref T b){T c=a;a=b;b=c;}public static int GCD(int a,int b){return(b==0)?a:GCD(b,a%b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static long ModAdd(long a,long b){long c=a+b;if(c>=MOD)return c%MOD;return c;}public static long ModMul(long a,long b){long c=a*b;if(c>=MOD)return c%MOD;return c;}public static void ChModAdd(ref long a,long b){a+=b;if(a>=MOD)a%=MOD;}public static void ChModMul(ref long a,long b){a*=b;if(a>=MOD)a%=MOD;}public static void FillArray<T>(T[]a,T b){int c=a.Length;for(int d=0;d<c;d++)a[d]=b;}public static void FillArray<T>(T[,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);for(int e=0;e<c;e++)for(int f=0;f<d;f++){a[e,f]=b;}}public static void FillArray<T>(T[,,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);int e=a.GetLength(2);for(int f=0;f<c;f++)for(int g=0;g<d;g++){for(int h=0;h<e;h++){a[f,g,h]=b;}}}public static long[]Accumulate(long[]a){long[]b=new long[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}public static double[]Accumulate(double[]a){double[]b=new double[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}}
    public static class Cin{public static int ri{get{return ReadInt();}}public static int[]ria{get{return ReadIntArray();}}public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static string[]rsa{get{return ReadStringArray();}}public static int ReadInt(){return int.Parse(i());}public static long ReadLong(){return long.Parse(i());}public static double ReadDouble(){return double.Parse(i());}public static string ReadString(){return i();}public static int[]ReadIntArray(){g=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){g=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){g=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static string[]ReadStringArray(){g=null;return Console.ReadLine().Split(' ');}public static void ReadCol(out long[]a,long b){a=new long[b];for(int c=0;c<b;c++)a[c]=ReadLong();}public static void ReadCols(out long[]a,out long[]b,long c){a=new long[c];b=new long[c];for(int d=0;d<c;d++){a[d]=ReadLong();b[d]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long d){a=new long[d];b=new long[d];c=new long[d];for(int e=0;e<d;e++){a[e]=ReadLong();b[e]=ReadLong();c[e]=ReadLong();}}public static int[,]ReadIntTable(int a,int b){g=null;int[,]c=new int[a,b];for(int d=0;d<a;d++)for(int e=0;e<b;e++){c[d,e]=ReadInt();}return c;}public static long[,]ReadLongTable(long a,long b){g=null;long[,]c=new long[a,b];for(int d=0;d<a;d++)for(int e=0;e<b;e++){c[d,e]=ReadLong();}return c;}public static char[,]ReadCharTable(int a,int b){g=null;char[,]c=new char[a,b];for(int d=0;d<a;d++){var e=ReadString();for(int f=0;f<b;f++)c[d,f]=e[f];}return c;}static string[]g;static int h;static string i(){if(g==null||g.Length<=h){g=Console.ReadLine().Split(' ');h=0;}return g[h++];}}
}
