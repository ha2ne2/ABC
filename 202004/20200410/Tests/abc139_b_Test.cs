using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200410.Tests
{
    [TestClass]
    public class abc139_b_Test
    {
        [TestMethod]
        public void abc139_b_sample_1()
        {
            string input =
@"4 10
";
            string output =
@"3
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc139_b_sample_2()
        {
            string input =
@"3 1
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc139_b_sample_3()
        {
            string input =
@"8 8
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
            abc139_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
