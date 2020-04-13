using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC162.Tests
{
    [TestClass]
    public class abc162_d_Test
    {
        [TestMethod]
        public void abc162_d_sample_1()
        {
            string input =
@"4
RRGB
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc162_d_sample_2()
        {
            string input =
@"39
RBRBGRBGGBBRRGBBRRRBGGBRBGBRBGBRBBBGBBB
";
            string output =
@"1800
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc162_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
