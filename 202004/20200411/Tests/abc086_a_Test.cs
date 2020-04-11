using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200411.Tests
{
    [TestClass]
    public class abc086_a_Test
    {
        [TestMethod]
        public void abc086_a_sample_1()
        {
            string input =
@"3 4
";
            string output =
@"Even
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc086_a_sample_2()
        {
            string input =
@"1 21
";
            string output =
@"Odd
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc086_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
