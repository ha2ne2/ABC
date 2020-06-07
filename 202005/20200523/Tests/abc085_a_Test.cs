using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200523.Tests
{
    [TestClass]
    public class abc085_a_Test
    {
        [TestMethod]
        public void abc085_a_sample_1()
        {
            string input =
@"2017/01/07
";
            string output =
@"2018/01/07
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc085_a_sample_2()
        {
            string input =
@"2017/01/31
";
            string output =
@"2018/01/31
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc085_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
