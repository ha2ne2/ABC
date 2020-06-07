using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200523.Tests
{
    [TestClass]
    public class arc097_a_Test
    {
        [TestMethod]
        public void arc097_a_sample_1()
        {
            string input =
@"aba
4
";
            string output =
@"b
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc097_a_sample_2()
        {
            string input =
@"atcoderandatcodeer
5
";
            string output =
@"andat
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc097_a_sample_3()
        {
            string input =
@"z
1
";
            string output =
@"z
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            arc097_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
