using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    [TestClass]
    public class MintTest
    {
        [TestMethod]
        public void FastPowTest()
        {
            Mint m = 2;
            var x = Mint.Pow(m, 4);
            Assert.AreEqual(16, x);
        }
    }
}
