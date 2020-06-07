using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC164.Tests
{
    [TestClass]
    public class abc164_b_Test
    {
        [TestMethod]
        public void abc164_b_sample_1()
        {
            string input =
@"10 9 10 10
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc164_b_sample_2()
        {
            string input =
@"46 4 40 5
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
            abc164_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
