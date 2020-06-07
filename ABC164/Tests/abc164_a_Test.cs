using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC164.Tests
{
    [TestClass]
    public class abc164_a_Test
    {
        [TestMethod]
        public void abc164_a_sample_1()
        {
            string input =
@"4 5
";
            string output =
@"unsafe
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc164_a_sample_2()
        {
            string input =
@"100 2
";
            string output =
@"safe
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc164_a_sample_3()
        {
            string input =
@"10 10
";
            string output =
@"unsafe
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc164_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
