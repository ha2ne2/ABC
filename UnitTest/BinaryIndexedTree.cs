using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    [TestClass]
    public class BinaryIndexedTreeTest
    {
        [TestMethod]
        public void SumTest()
        {
            BinaryIndexedTree bit = new BinaryIndexedTree(10);
            bit.Add(0, 1);
            bit.Add(1, 2);
            bit.Add(2, 3);
            bit.Add(3, 4);
            bit.Add(4, 5);

            Assert.AreEqual(15, bit.Sum(4));
        }

        [TestMethod]
        public void SumTest2()
        {
            BinaryIndexedTree bit = new BinaryIndexedTree(10);
            bit.Add(0, 1);
            bit.Add(1, 2);
            bit.Add(2, 3);
            bit.Add(3, 4);
            bit.Add(4, 5);

            Assert.AreEqual(14, bit.Sum(1,4));
            Assert.AreEqual(15, bit.Sum(0,4));
        }

        [TestMethod]
        public void InitTest()
        {
            BinaryIndexedTree bit = new BinaryIndexedTree(10);
            bit.Init(2);
            bit.Add(0, 1);
            bit.Add(1, 2);
            bit.Add(2, 3);
            bit.Add(3, 4);
            bit.Add(4, 5);

            Assert.AreEqual(22, bit.Sum(1,4));
            Assert.AreEqual(25, bit.Sum(0,4));
        }
    }
}
