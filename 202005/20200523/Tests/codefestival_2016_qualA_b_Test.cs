using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200523.Tests
{
    [TestClass]
    public class codefestival_2016_qualA_b_Test
    {
        [TestMethod]
        public void codefestival_2016_qualA_b_sample_1()
        {
            string input =
@"4
2 1 4 3
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void codefestival_2016_qualA_b_sample_2()
        {
            string input =
@"3
2 3 1
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void codefestival_2016_qualA_b_sample_3()
        {
            string input =
@"5
5 5 5 5 1
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
            codefestival_2016_qualA_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
