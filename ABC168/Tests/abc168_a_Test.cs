using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC168.Tests
{
    [TestClass]
    public class abc168_a_Test
    {
        [TestMethod]
        public void abc168_a_sample_1()
        {
            string input =
@"16
";
            string output =
@"pon
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc168_a_sample_2()
        {
            string input =
@"2
";
            string output =
@"hon
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc168_a_sample_3()
        {
            string input =
@"183
";
            string output =
@"bon
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc168_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
