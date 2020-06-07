using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC169.Tests
{
    [TestClass]
    public class abc169_f_Test
    {
        [TestMethod]
        public void abc169_f_sample_1()
        {
            string input =
@"3 4
2 2 4
";
            string output =
@"6
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc169_f_sample_2()
        {
            string input =
@"5 8
9 9 9 9 9
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc169_f_sample_3()
        {
            string input =
@"10 10
3 1 4 1 5 9 2 6 5 3
";
            string output =
@"3296
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc169_f.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
