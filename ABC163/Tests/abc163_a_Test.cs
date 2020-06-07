using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC163.Tests
{
    [TestClass]
    public class abc163_a_Test
    {
        [TestMethod]
        public void abc163_a_sample_1()
        {
            string input =
@"1
";
            string output =
@"6.28318530717958623200
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_a_sample_2()
        {
            string input =
@"73
";
            string output =
@"458.67252742410977361942
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc163_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
