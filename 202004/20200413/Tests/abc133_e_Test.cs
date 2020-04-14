using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200413.Tests
{
    [TestClass]
    public class abc133_e_Test
    {
        [TestMethod]
        public void abc133_e_sample_1()
        {
            string input =
@"4 3
1 2
2 3
3 4
";
            string output =
@"6
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc133_e_sample_2()
        {
            string input =
@"5 4
1 2
1 3
1 4
4 5
";
            string output =
@"48
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc133_e_sample_3()
        {
            string input =
@"16 22
12 1
3 1
4 16
7 12
6 2
2 15
5 16
14 16
10 11
3 10
3 13
8 6
16 8
9 12
4 3
";
            string output =
@"271414432
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc133_e.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
