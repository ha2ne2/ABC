using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC151.Tests
{
    [TestClass]
    public class abc151_a_Test
    {
        [TestMethod]
        public void abc151_a_sample_1()
        {
            string input =
@"a
";
            string output =
@"b
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc151_a_sample_2()
        {
            string input =
@"y
";
            string output =
@"z
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc151_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
