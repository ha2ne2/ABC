using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC151.Tests
{
    [TestClass]
    public class abc151_c_Test
    {
        [TestMethod]
        public void abc151_c_sample_1()
        {
            string input =
@"2 5
1 WA
1 AC
2 WA
2 AC
2 WA
";
            string output =
@"2 2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc151_c_sample_2()
        {
            string input =
@"100000 3
7777 AC
7777 AC
7777 AC
";
            string output =
@"1 0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc151_c_sample_3()
        {
            string input =
@"6 0
";
            string output =
@"0 0
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc151_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
