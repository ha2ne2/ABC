using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200412.Tests
{
    [TestClass]
    public class agc013_a_Test
    {
        [TestMethod]
        public void agc013_a_sample_1()
        {
            string input =
@"6
1 2 3 2 2 1
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void agc013_a_sample_2()
        {
            string input =
@"9
1 2 1 2 1 2 1 2 1
";
            string output =
@"5
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void agc013_a_sample_3()
        {
            string input =
@"7
1 2 3 2 1 999999999 1000000000
";
            string output =
@"3
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            agc013_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
