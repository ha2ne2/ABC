using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC142.Tests
{
    [TestClass]
    public class abc142_a_Test
    {
        [TestMethod]
        public void abc142_a_sample_1()
        {
            string input =
@"4
";
            string output =
@"0.5000000000
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc142_a_sample_2()
        {
            string input =
@"5
";
            string output =
@"0.6000000000
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc142_a_sample_3()
        {
            string input =
@"1
";
            string output =
@"1.0000000000
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc142_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
