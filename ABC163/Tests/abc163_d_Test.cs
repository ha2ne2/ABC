using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC163.Tests
{
    [TestClass]
    public class abc163_d_Test
    {
        [TestMethod]
        public void abc163_d_sample_1()
        {
            string input =
@"3 2
";
            string output =
@"10
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_d_sample_2()
        {
            string input =
@"200000 200001
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_d_sample_3()
        {
            string input =
@"141421 35623
";
            string output =
@"220280457
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc163_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
