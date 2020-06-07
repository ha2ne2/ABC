using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC169.Tests
{
    [TestClass]
    public class abc169_e_Test
    {
        [TestMethod]
        public void abc169_e_sample_1()
        {
            string input =
@"2
1 2
2 3
";
            string output =
@"3
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc169_e_sample_2()
        {
            string input =
@"3
100 100
10 10000
1 1000000000
";
            string output =
@"9991
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc169_e.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
