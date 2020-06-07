using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC167.Tests
{
    [TestClass]
    public class abc167_c_Test
    {
        [TestMethod]
        public void abc167_c_sample_1()
        {
            string input =
@"3 3 10
60 2 2 4
70 8 7 9
50 2 3 9
";
            string output =
@"120
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc167_c_sample_2()
        {
            string input =
@"3 3 10
100 3 1 4
100 1 5 9
100 2 6 5
";
            string output =
@"-1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc167_c_sample_3()
        {
            string input =
@"8 5 22
100 3 7 5 3 1
164 4 5 2 7 8
334 7 2 7 2 9
234 4 7 2 8 2
541 5 4 3 3 6
235 4 8 6 9 7
394 3 6 1 6 2
872 8 4 3 7 2
";
            string output =
@"1067
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc167_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
