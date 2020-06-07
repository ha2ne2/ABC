using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC163.Tests
{
    [TestClass]
    public class abc163_f_Test
    {
        [TestMethod]
        public void abc163_f_sample_1()
        {
            string input =
@"3
1 2 1
1 2
2 3
";
            string output =
@"5
4
0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_f_sample_2()
        {
            string input =
@"1
1
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_f_sample_3()
        {
            string input =
@"2
1 2
1 2
";
            string output =
@"2
2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_f_sample_4()
        {
            string input =
@"5
1 2 3 4 5
1 2
2 3
3 4
3 5
";
            string output =
@"5
8
10
5
5
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc163_f_sample_5()
        {
            string input =
@"8
2 7 2 5 4 1 7 5
3 1
1 2
2 7
4 5
5 6
6 8
7 8
";
            string output =
@"18
15
0
14
23
0
23
0
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc163_f.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
