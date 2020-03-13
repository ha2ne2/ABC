using System;
using System.Collections.Generic;
using System.Text;
using Pair = Lib.VTuple<long, long>;

namespace Lib
{
    public class Dijkstra
    {
        public int N;
        public long[] Costs;
        public HashMap<long, HashMap<long, Pair>> Graph; // first:cost, second:v
        public Dijkstra(int n)
        {
            N = n;
            Graph = new HashMap<long, HashMap<long, Pair>>();
            for (int i = 0; i < N; i++)
            {
                Graph[i] = new HashMap<long, Pair>(new Pair(long.MaxValue, -1));
            }
            Costs = new long[N];
        }

        /// <summary>
        /// パスを追加する。
        /// パスが既に存在する場合、既存のパスより低コストだった場合は更新する。
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cost"></param>
        public void AddPath(long from, long to, long cost)
        {
            var nv = new Pair(cost, to);
            if (nv.First < Graph[from][to].First)
                Graph[from][to] = nv;
        }

        public void Solve(long from)
        {
            Util.FillArray(Costs, long.MaxValue);
            Costs[from] = 0;
            var pq = new PriorityQueue<Pair>(); // first:cost, second:v
            pq.Enqueue(new Pair(0, from));
            while (pq.Any())
            {
                var v = pq.Dequeue();
                if (v.First > Costs[v.Second]) continue;

                foreach(var edge in Graph[v.Second].Values)
                {
                    var nCost = Costs[v.Second] + edge.First;
                    if(nCost < Costs[edge.Second])
                    {
                        Costs[edge.Second] = nCost;
                        pq.Enqueue(new Pair(nCost, edge.Second));
                    }
                }
            }
        }
    }
}
