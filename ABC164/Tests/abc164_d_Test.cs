using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC164.Tests
{
    [TestClass]
    public class abc164_d_Test
    {
        [TestMethod]
        public void abc164_d_sample_1()
        {
            string input =
@"1817181712114
";
            string output =
@"3
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc164_d_sample_2()
        {
            string input =
@"14282668646
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc164_d_sample_3()
        {
            string input =
@"2119
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc164_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
