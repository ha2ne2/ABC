using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
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
}
