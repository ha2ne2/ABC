using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC162.Tests
{
    [TestClass]
    public class abc162_e_Test
    {
        [TestMethod]
        public void abc162_e_sample_1()
        {
            string input =
@"3 2
";
            string output =
@"9
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc162_e_sample_2()
        {
            string input =
@"3 200
";
            string output =
@"10813692
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc162_e_sample_3()
        {
            string input =
@"100000 100000
";
            string output =
@"742202979
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc162_e.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
