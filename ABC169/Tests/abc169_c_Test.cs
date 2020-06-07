using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC169.Tests
{
    [TestClass]
    public class abc169_c_Test
    {
        [TestMethod]
        public void abc169_c_sample_1()
        {
            string input =
@"198 1.10
";
            string output =
@"217
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc169_c_sample_2()
        {
            string input =
@"1 0.01
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc169_c_sample_3()
        {
            string input =
@"1000000000000000 9.99
";
            string output =
@"9990000000000000
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc169_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
