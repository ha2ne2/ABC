using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200413.Tests
{
    [TestClass]
    public class abc084_d_Test
    {
        [TestMethod]
        public void abc084_d_sample_1()
        {
            string input =
@"1
3 7
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc084_d_sample_2()
        {
            string input =
@"4
13 13
7 11
7 11
2017 2017
";
            string output =
@"1
0
0
1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc084_d_sample_3()
        {
            string input =
@"6
1 53
13 91
37 55
19 51
73 91
13 49
";
            string output =
@"4
4
1
1
1
2
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc084_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
