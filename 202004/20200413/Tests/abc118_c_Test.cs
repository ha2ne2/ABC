using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200413.Tests
{
    [TestClass]
    public class abc118_c_Test
    {
        [TestMethod]
        public void abc118_c_sample_1()
        {
            string input =
@"4
2 10 8 40
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc118_c_sample_2()
        {
            string input =
@"4
5 13 8 1000000000
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc118_c_sample_3()
        {
            string input =
@"3
1000000000 1000000000 1000000000
";
            string output =
@"1000000000
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc118_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
