using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC142.Tests
{
    [TestClass]
    public class abc142_c_Test
    {
        [TestMethod]
        public void abc142_c_sample_1()
        {
            string input =
@"3
2 3 1
";
            string output =
@"3 1 2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc142_c_sample_2()
        {
            string input =
@"5
1 2 3 4 5
";
            string output =
@"1 2 3 4 5
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc142_c_sample_3()
        {
            string input =
@"8
8 2 7 3 4 5 6 1
";
            string output =
@"8 2 4 5 6 7 3 1
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc142_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
