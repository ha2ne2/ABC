using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC151.Tests
{
    [TestClass]
    public class abc151_b_Test
    {
        [TestMethod]
        public void abc151_b_sample_1()
        {
            string input =
@"5 10 7
8 10 3 6
";
            string output =
@"8
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc151_b_sample_2()
        {
            string input =
@"4 100 60
100 100 100
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc151_b_sample_3()
        {
            string input =
@"4 100 60
0 0 0
";
            string output =
@"-1
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc151_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
