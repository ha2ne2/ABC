using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200413.Tests
{
    [TestClass]
    public class abc055_b_Test
    {
        [TestMethod]
        public void abc055_b_sample_1()
        {
            string input =
@"3
";
            string output =
@"6
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc055_b_sample_2()
        {
            string input =
@"10
";
            string output =
@"3628800
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc055_b_sample_3()
        {
            string input =
@"100000
";
            string output =
@"457992974
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc055_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
