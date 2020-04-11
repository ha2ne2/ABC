using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200411.Tests
{
    [TestClass]
    public class abc073_c_Test
    {
        [TestMethod]
        public void abc073_c_sample_1()
        {
            string input =
@"3
6
2
6
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc073_c_sample_2()
        {
            string input =
@"4
2
5
5
2
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc073_c_sample_3()
        {
            string input =
@"6
12
22
16
22
18
12
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc073_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
