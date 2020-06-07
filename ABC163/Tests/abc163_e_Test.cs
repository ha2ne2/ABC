using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC163.Tests
{
    [TestClass]
    public class abc163_e_Test
    {
        [TestMethod]
        public void abc163_e_sample_1()
        {
            string input =
@"4
1 3 4 2
";
            string output =
@"20
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_e_sample_2()
        {
            string input =
@"6
5 5 6 1 1 1
";
            string output =
@"58
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_e_sample_3()
        {
            string input =
@"6
8 6 9 1 2 1
";
            string output =
@"85
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc163_e.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
