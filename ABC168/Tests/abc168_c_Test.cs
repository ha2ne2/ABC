using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC168.Tests
{
    [TestClass]
    public class abc168_c_Test
    {
        [TestMethod]
        public void abc168_c_sample_1()
        {
            string input =
@"3 4 9 0
";
            string output =
@"5.00000000000000000000
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc168_c_sample_2()
        {
            string input =
@"3 4 10 40
";
            string output =
@"4.56425719433005567605
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc168_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
