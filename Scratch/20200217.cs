﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using static _20200217.Cin;
using static _20200217.Util;

namespace _20200217
{
    public class Program
    {
        public static void _Main(string[] args)
        {
            int[] cost = new int[] { 0, 1, 2, 3, 4, 5, 4, 3, 2, 1, 0 };
            string S = rs;
            int ans = 0;
            bool carry = false;
            for (int i = S.Length - 1; i >= 0; i--)
            {
                int n = S[i] - '0';
                if (carry) n++;
                ans += cost[n];
                carry = (n > 5);
                if (n == 5 && i > 0 && S[i - 1] > '4')
                    carry = true;
            }
            if (carry) ans++;
            Console.WriteLine(ans);
        }
    }

    public class HashMap<K,V>:Dictionary<K,V>{V i;static Func<V>j=Expression.Lambda<Func<V>>(Expression.New(typeof(V))).Compile();public HashMap(){}public HashMap(V a){i=a;}new public V this[K a]{get{V b;if(TryGetValue(a,out b))return b;else return base[a]=i!=null?i:j();}set{base[a]=value;}}}public static class Util{public static readonly long INF=(long)1e17;public readonly static long MOD=(long)1e9+7;public static void DontAutoFlush(){var a=new StreamWriter(Console.OpenStandardOutput()){AutoFlush=false};Console.SetOut(a);}public static void Flush(){Console.Out.Flush();}public static T[]Sort<T>(T[]a){Array.Sort<T>(a);return a;}public static T[]SortDecend<T>(T[]a){Array.Sort<T>(a);Array.Reverse(a);return a;}public static void Swap<T>(ref T a,ref T b){T c=a;a=b;b=c;}public static int GCD(int a,int b){return(b==0)?a:GCD(b,a%b);}public static void ChMax(ref long a,long b){if(a<b)a=b;}public static void ChMin(ref long a,long b){if(a>b)a=b;}public static long ModAdd(long a,long b){long c=a+b;if(c>=MOD)return c%MOD;return c;}public static long ModMul(long a,long b){long c=a*b;if(c>=MOD)return c%MOD;return c;}public static void ChModAdd(ref long a,long b){a+=b;if(a>=MOD)a%=MOD;}public static void ChModMul(ref long a,long b){a*=b;if(a>=MOD)a%=MOD;}public static void FillArray<T>(T[]a,T b){int c=a.Length;for(int d=0;d<c;d++)a[d]=b;}public static void FillArray<T>(T[,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);for(int e=0;e<c;e++)for(int f=0;f<d;f++){a[e,f]=b;}}public static void FillArray<T>(T[,,]a,T b){int c=a.GetLength(0);int d=a.GetLength(1);int e=a.GetLength(2);for(int f=0;f<c;f++)for(int g=0;g<d;g++){for(int h=0;h<e;h++){a[f,g,h]=b;}}}public static long[]Accumulate(long[]a){long[]b=new long[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}public static double[]Accumulate(double[]a){double[]b=new double[a.Length+1];for(int c=0;c<a.Length;c++)b[c+1]=b[c]+a[c];return b;}}public static class Cin{public static long rl{get{return ReadLong();}}public static long[]rla{get{return ReadLongArray();}}public static double rd{get{return ReadDouble();}}public static double[]rda{get{return ReadDoubleArray();}}public static string rs{get{return ReadString();}}public static int ReadInt(){return int.Parse(k());}public static long ReadLong(){return long.Parse(k());}public static double ReadDouble(){return double.Parse(k());}public static string ReadString(){return k();}public static int[]ReadIntArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);}public static long[]ReadLongArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);}public static double[]ReadDoubleArray(){i=null;return Array.ConvertAll(Console.ReadLine().Split(' '),double.Parse);}public static void ReadCols(out long[]a,out long[]b,long c){a=new long[c];b=new long[c];for(int d=0;d<c;d++){a[d]=ReadLong();b[d]=ReadLong();}}public static void ReadCols(out long[]a,out long[]b,out long[]c,long d){a=new long[d];b=new long[d];c=new long[d];for(int e=0;e<d;e++){a[e]=ReadLong();b[e]=ReadLong();c[e]=ReadLong();}}public static int[][]ReadIntTable(int a){i=null;int[][]b=new int[a][];for(int c=0;c<a;c++)b[c]=ReadIntArray();return b;}public static long[][]ReadLongTable(long a){i=null;long[][]b=new long[a][];for(long c=0;c<a;c++)b[c]=ReadLongArray();return b;}static string[]i{get;set;}static int j{get;set;}static string k(){if(i==null||i.Length<=j){i=Console.ReadLine().Split(' ');j=0;}return i[j++];}}
}
