using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC162.Tests
{
    [TestClass]
    public class abc162_c_Test
    {
        [TestMethod]
        public void abc162_c_sample_1()
        {
            string input =
@"2
";
            string output =
@"9
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc162_c_sample_2()
        {
            string input =
@"200
";
            string output =
@"10813692
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc162_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
