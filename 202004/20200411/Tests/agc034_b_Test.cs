using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200411.Tests
{
    [TestClass]
    public class agc034_b_Test
    {
        [TestMethod]
        public void agc034_b_sample_1()
        {
            string input =
@"ABCABC
";
            string output =
@"3
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void agc034_b_sample_2()
        {
            string input =
@"C
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void agc034_b_sample_3()
        {
            string input =
@"ABCACCBABCBCAABCB
";
            string output =
@"6
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            agc034_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
