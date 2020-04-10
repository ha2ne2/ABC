using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC142.Tests
{
    [TestClass]
    public class abc142_d_Test
    {
        [TestMethod]
        public void abc142_d_sample_1()
        {
            string input =
@"1000000000000 1000000000000
";
            string output =
@"3
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc142_d_sample_2()
        {
            string input =
@"420 660
";
            string output =
@"4
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc142_d_sample_3()
        {
            string input =
@"1 2019
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc142_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
