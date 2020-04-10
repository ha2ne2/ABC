using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200410.Tests
{
    [TestClass]
    public class abc101_b_Test
    {
        [TestMethod]
        public void abc101_b_sample_1()
        {
            string input =
@"12
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc101_b_sample_2()
        {
            string input =
@"101
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc101_b_sample_3()
        {
            string input =
@"999999999
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc101_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
