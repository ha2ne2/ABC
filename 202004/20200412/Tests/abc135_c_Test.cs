using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200412.Tests
{
    [TestClass]
    public class abc135_c_Test
    {
        [TestMethod]
        public void abc135_c_sample_1()
        {
            string input =
@"2
3 5 2
4 5
";
            string output =
@"9
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc135_c_sample_2()
        {
            string input =
@"3
5 6 3 8
5 100 8
";
            string output =
@"22
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc135_c_sample_3()
        {
            string input =
@"2
100 1 1
1 100
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
            abc135_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
