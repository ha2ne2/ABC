using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC166.Tests
{
    [TestClass]
    public class abc166_e_Test
    {
        [TestMethod]
        public void abc166_e_sample_1()
        {
            string input =
@"6
2 3 3 1 3 1
";
            string output =
@"3
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc166_e_sample_2()
        {
            string input =
@"6
5 2 4 2 8 8
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc166_e_sample_3()
        {
            string input =
@"32
3 1 4 1 5 9 2 6 5 3 5 8 9 7 9 3 2 3 8 4 6 2 6 4 3 3 8 3 2 7 9 5
";
            string output =
@"22
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc166_e.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
