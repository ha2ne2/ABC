using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC164.Tests
{
    [TestClass]
    public class abc164_f_Test
    {
        [TestMethod]
        public void abc164_f_sample_1()
        {
            string input =
@"2
0 1
1 0
1 1
1 0
";
            string output =
@"1 1
1 0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc164_f_sample_2()
        {
            string input =
@"2
1 1
1 0
15 15
15 11
";
            string output =
@"15 11
15 11
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc164_f.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
