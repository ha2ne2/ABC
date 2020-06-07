using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC164.Tests
{
    [TestClass]
    public class abc164_c_Test
    {
        [TestMethod]
        public void abc164_c_sample_1()
        {
            string input =
@"3
apple
orange
apple
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc164_c_sample_2()
        {
            string input =
@"5
grape
grape
grape
grape
grape
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc164_c_sample_3()
        {
            string input =
@"4
aaaa
a
aaa
aa
";
            string output =
@"4
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc164_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
