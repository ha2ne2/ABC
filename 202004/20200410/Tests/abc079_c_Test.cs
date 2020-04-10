using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200410.Tests
{
    [TestClass]
    public class abc079_c_Test
    {
        [TestMethod]
        public void abc079_c_sample_1()
        {
            string input =
@"1222
";
            string output =
@"1+2+2+2=7
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc079_c_sample_2()
        {
            string input =
@"0290
";
            string output =
@"0-2+9+0=7
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc079_c_sample_3()
        {
            string input =
@"3242
";
            string output =
@"3+2+4-2=7
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc079_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
