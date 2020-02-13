using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
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

        private readonly List<T> Heap;
        private readonly Comparison<T> Compare;
        private int Size;

        #endregion

    }
}