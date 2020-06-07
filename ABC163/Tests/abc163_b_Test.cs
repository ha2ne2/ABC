using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC163.Tests
{
    [TestClass]
    public class abc163_b_Test
    {
        [TestMethod]
        public void abc163_b_sample_1()
        {
            string input =
@"41 2
5 6
";
            string output =
@"30
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_b_sample_2()
        {
            string input =
@"10 2
5 6
";
            string output =
@"-1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_b_sample_3()
        {
            string input =
@"11 2
5 6
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_b_sample_4()
        {
            string input =
@"314 15
9 26 5 35 8 9 79 3 23 8 46 2 6 43 3
";
            string output =
@"9
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc163_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
