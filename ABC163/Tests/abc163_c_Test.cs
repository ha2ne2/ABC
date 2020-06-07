using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC163.Tests
{
    [TestClass]
    public class abc163_c_Test
    {
        [TestMethod]
        public void abc163_c_sample_1()
        {
            string input =
@"5
1 1 2 2
";
            string output =
@"2
2
0
0
0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_c_sample_2()
        {
            string input =
@"10
1 1 1 1 1 1 1 1 1
";
            string output =
@"9
0
0
0
0
0
0
0
0
0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_c_sample_3()
        {
            string input =
@"7
1 2 3 4 5 6
";
            string output =
@"1
1
1
1
1
1
0
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc163_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
