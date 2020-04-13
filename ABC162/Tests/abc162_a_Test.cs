using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC162.Tests
{
    [TestClass]
    public class abc162_a_Test
    {
        [TestMethod]
        public void abc162_a_sample_1()
        {
            string input =
@"117
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc162_a_sample_2()
        {
            string input =
@"123
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc162_a_sample_3()
        {
            string input =
@"777
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc162_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
