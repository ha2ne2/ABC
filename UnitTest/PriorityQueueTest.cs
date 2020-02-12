using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    [TestClass]
    public class PriorityQueueTest
    {
        [TestMethod]
        public void EnqueueTest()
        {
            PriorityQueue<long> pq = new PriorityQueue<long>(Comparer<long>.Default.Compare);
            pq.Enqueue(8);
            pq.Enqueue(7);
            pq.Enqueue(6);
            pq.Enqueue(5);
            pq.Enqueue(3);
            pq.Enqueue(4);
            Assert.AreEqual(pq.Count, 6);
            Assert.AreEqual(pq.Dequeue(), 3);
            Assert.AreEqual(pq.Dequeue(), 4);
            Assert.AreEqual(pq.Dequeue(), 5);
            Assert.AreEqual(pq.Dequeue(), 6);
            Assert.AreEqual(pq.Dequeue(), 7);
            Assert.AreEqual(pq.Dequeue(), 8);
            Assert.AreEqual(pq.Count, 0);

        }

        [TestMethod]
        public void EnqueueTest2()
        {
            PriorityQueue<long> pq = new PriorityQueue<long>((x,y) => (int)(y-x));
            pq.Enqueue(8);
            pq.Enqueue(7);
            pq.Enqueue(6);
            pq.Enqueue(5);
            pq.Enqueue(3);
            pq.Enqueue(4);

            Assert.AreEqual(pq.Count, 6);
            Assert.AreEqual(pq.Dequeue(), 8);
            Assert.AreEqual(pq.Dequeue(), 7);
            Assert.AreEqual(pq.Dequeue(), 6);
            Assert.AreEqual(pq.Dequeue(), 5);
            Assert.AreEqual(pq.Dequeue(), 4);
            Assert.AreEqual(pq.Dequeue(), 3);
            Assert.AreEqual(pq.Count, 0);
        }

        [TestMethod]
        public void AscendDescendTest()
        {
            {
                PriorityQueue<long> pq = new PriorityQueue<long>(PriorityQueue<long>.Order.Descend);
                pq.Enqueue(8);
                pq.Enqueue(7);
                pq.Enqueue(6);
                pq.Enqueue(5);
                pq.Enqueue(3);
                pq.Enqueue(4);

                Assert.AreEqual(pq.Count, 6);
                Assert.AreEqual(pq.Dequeue(), 8);
                Assert.AreEqual(pq.Dequeue(), 7);
                Assert.AreEqual(pq.Dequeue(), 6);
                Assert.AreEqual(pq.Dequeue(), 5);
                Assert.AreEqual(pq.Dequeue(), 4);
                Assert.AreEqual(pq.Dequeue(), 3);
                Assert.AreEqual(pq.Count, 0);
            }

            {
                PriorityQueue<long> pq = new PriorityQueue<long>(PriorityQueue<long>.Order.Ascend);
                pq.Enqueue(8);
                pq.Enqueue(7);
                pq.Enqueue(6);
                pq.Enqueue(5);
                pq.Enqueue(3);
                pq.Enqueue(4);

                Assert.AreEqual(pq.Count, 6);
                Assert.AreEqual(pq.Dequeue(), 3);
                Assert.AreEqual(pq.Dequeue(), 4);
                Assert.AreEqual(pq.Dequeue(), 5);
                Assert.AreEqual(pq.Dequeue(), 6);
                Assert.AreEqual(pq.Dequeue(), 7);
                Assert.AreEqual(pq.Dequeue(), 8);
                Assert.AreEqual(pq.Count, 0);
            }
        }
    }
}
