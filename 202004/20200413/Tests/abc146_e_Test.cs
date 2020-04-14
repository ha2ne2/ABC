using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200413.Tests
{
    [TestClass]
    public class abc146_e_Test
    {
        [TestMethod]
        public void abc146_e_sample_1()
        {
            string input =
@"5 4
1 4 2 3 5
";
            string output =
@"4
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc146_e_sample_2()
        {
            string input =
@"8 4
4 2 4 2 4 2 4 2
";
            string output =
@"7
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc146_e_sample_3()
        {
            string input =
@"10 7
14 15 92 65 35 89 79 32 38 46
";
            string output =
@"8
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc146_e.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
