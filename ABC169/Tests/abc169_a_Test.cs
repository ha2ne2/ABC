using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC169.Tests
{
    [TestClass]
    public class abc169_a_Test
    {
        [TestMethod]
        public void abc169_a_sample_1()
        {
            string input =
@"2 5
";
            string output =
@"10
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc169_a_sample_2()
        {
            string input =
@"100 100
";
            string output =
@"10000
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc169_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
