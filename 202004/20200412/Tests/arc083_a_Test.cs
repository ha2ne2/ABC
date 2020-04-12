using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200412.Tests
{
    [TestClass]
    public class arc083_a_Test
    {
        [TestMethod]
        public void arc083_a_sample_1()
        {
            string input =
@"1 2 10 20 15 200
";
            string output =
@"110 10
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc083_a_sample_2()
        {
            string input =
@"1 2 1 2 100 1000
";
            string output =
@"200 100
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc083_a_sample_3()
        {
            string input =
@"17 19 22 26 55 2802
";
            string output =
@"2634 934
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            arc083_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
