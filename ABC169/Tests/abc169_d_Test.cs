using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC169.Tests
{
    [TestClass]
    public class abc169_d_Test
    {
        [TestMethod]
        public void abc169_d_sample_1()
        {
            string input =
@"24
";
            string output =
@"3
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc169_d_sample_2()
        {
            string input =
@"1
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc169_d_sample_3()
        {
            string input =
@"64
";
            string output =
@"3
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc169_d_sample_4()
        {
            string input =
@"1000000007
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc169_d_sample_5()
        {
            string input =
@"997764507000
";
            string output =
@"7
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc169_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
