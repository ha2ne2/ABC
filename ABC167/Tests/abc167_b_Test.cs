using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC167.Tests
{
    [TestClass]
    public class abc167_b_Test
    {
        [TestMethod]
        public void abc167_b_sample_1()
        {
            string input =
@"2 1 1 3
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc167_b_sample_2()
        {
            string input =
@"1 2 3 4
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc167_b_sample_3()
        {
            string input =
@"2000000000 0 0 2000000000
";
            string output =
@"2000000000
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc167_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
