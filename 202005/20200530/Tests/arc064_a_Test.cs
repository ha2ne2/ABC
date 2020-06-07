using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200530.Tests
{
    [TestClass]
    public class arc064_a_Test
    {
        [TestMethod]
        public void arc064_a_sample_1()
        {
            string input =
@"3 3
2 2 2
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc064_a_sample_2()
        {
            string input =
@"6 1
1 6 1 2 0 4
";
            string output =
@"11
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc064_a_sample_3()
        {
            string input =
@"5 9
3 1 4 1 5
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc064_a_sample_4()
        {
            string input =
@"2 0
5 5
";
            string output =
@"10
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            arc064_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
