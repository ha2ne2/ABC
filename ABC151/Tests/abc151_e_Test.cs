using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC151.Tests
{
    [TestClass]
    public class abc151_e_Test
    {
        [TestMethod]
        public void abc151_e_sample_1()
        {
            string input =
@"4 2
1 1 3 4
";
            string output =
@"11
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc151_e_sample_2()
        {
            string input =
@"6 3
10 10 10 -10 -10 -10
";
            string output =
@"360
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc151_e_sample_3()
        {
            string input =
@"3 1
1 1 1
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc151_e_sample_4()
        {
            string input =
@"10 6
1000000000 1000000000 1000000000 1000000000 1000000000 0 0 0 0 0
";
            string output =
@"999998537
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc151_e.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
