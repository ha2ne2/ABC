using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200523.Tests
{
    [TestClass]
    public class abc080_c_Test
    {
        [TestMethod]
        public void abc080_c_sample_1()
        {
            string input =
@"1
1 1 0 1 0 0 0 1 0 1
3 4 5 6 7 8 9 -2 -3 4 -2
";
            string output =
@"8
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc080_c_sample_2()
        {
            string input =
@"2
1 1 1 1 1 0 0 0 0 0
0 0 0 0 0 1 1 1 1 1
0 -2 -2 -2 -2 -2 -1 -1 -1 -1 -1
0 -2 -2 -2 -2 -2 -1 -1 -1 -1 -1
";
            string output =
@"-2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc080_c_sample_3()
        {
            string input =
@"3
1 1 1 1 1 1 0 0 1 1
0 1 0 1 1 1 1 0 1 0
1 0 1 1 0 1 0 1 0 1
-8 6 -2 -8 -8 4 8 7 -6 2 2
-9 2 0 1 7 -5 0 -2 -6 5 5
6 -6 7 -9 6 -5 8 0 -9 -7 -7
";
            string output =
@"23
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc080_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
