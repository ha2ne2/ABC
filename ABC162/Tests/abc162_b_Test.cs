using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC162.Tests
{
    [TestClass]
    public class abc162_b_Test
    {
        [TestMethod]
        public void abc162_b_sample_1()
        {
            string input =
@"15
";
            string output =
@"60
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc162_b_sample_2()
        {
            string input =
@"1000000
";
            string output =
@"266666333332
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc162_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
