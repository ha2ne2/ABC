using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200413.Tests
{
    [TestClass]
    public class abc120_b_Test
    {
        [TestMethod]
        public void abc120_b_sample_1()
        {
            string input =
@"8 12 2
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc120_b_sample_2()
        {
            string input =
@"100 50 4
";
            string output =
@"5
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc120_b_sample_3()
        {
            string input =
@"1 1 1
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
            abc120_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
