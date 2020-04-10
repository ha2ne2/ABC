using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200410.Tests
{
    [TestClass]
    public class abc154_d_Test
    {
        [TestMethod]
        public void abc154_d_sample_1()
        {
            string input =
@"5 3
1 2 2 4 5
";
            string output =
@"7.000000000000
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc154_d_sample_2()
        {
            string input =
@"4 1
6 6 6 6
";
            string output =
@"3.500000000000
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc154_d_sample_3()
        {
            string input =
@"10 4
17 13 13 12 15 20 10 13 17 11
";
            string output =
@"32.000000000000
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc154_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
