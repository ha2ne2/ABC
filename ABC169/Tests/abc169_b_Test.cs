using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC169.Tests
{
    [TestClass]
    public class abc169_b_Test
    {
        [TestMethod]
        public void abc169_b_sample_1()
        {
            string input =
@"2
1000000000 1000000000
";
            string output =
@"1000000000000000000
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc169_b_sample_2()
        {
            string input =
@"3
101 9901 999999000001
";
            string output =
@"-1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc169_b_sample_3()
        {
            string input =
@"3
1000000000000000000 1000000000000000000 1
";
            string output =
@"-1
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc169_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
