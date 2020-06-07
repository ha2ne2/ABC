using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC164.Tests
{
    [TestClass]
    public class abc164_e_Test
    {
        [TestMethod]
        public void abc164_e_sample_1()
        {
            string input =
@"3 2 1
1 2 1 2
1 3 2 4
1 11
1 2
2 5
";
            string output =
@"2
14
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc164_e_sample_2()
        {
            string input =
@"4 4 1
1 2 1 5
1 3 4 4
2 4 2 2
3 4 1 1
3 1
3 1
5 2
6 4
";
            string output =
@"5
5
7
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc164_e_sample_3()
        {
            string input =
@"6 5 1
1 2 1 1
1 3 2 1
2 4 5 1
3 5 11 1
1 6 50 1
1 10000
1 3000
1 700
1 100
1 1
100 1
";
            string output =
@"1
9003
14606
16510
16576
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc164_e_sample_4()
        {
            string input =
@"4 6 1000000000
1 2 50 1
1 3 50 5
1 4 50 7
2 3 50 2
2 4 50 4
3 4 50 3
10 2
4 4
5 5
7 7
";
            string output =
@"1
3
5
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc164_e_sample_5()
        {
            string input =
@"2 1 0
1 2 1 1
1 1000000000
1 1
";
            string output =
@"1000000001
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc164_e.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
