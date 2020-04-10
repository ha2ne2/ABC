using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC142.Tests
{
    [TestClass]
    public class abc142_b_Test
    {
        [TestMethod]
        public void abc142_b_sample_1()
        {
            string input =
@"4 150
150 140 100 200
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc142_b_sample_2()
        {
            string input =
@"1 500
499
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc142_b_sample_3()
        {
            string input =
@"5 1
100 200 300 400 500
";
            string output =
@"5
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc142_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
