using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200413.Tests
{
    [TestClass]
    public class arc101_a_Test
    {
        [TestMethod]
        public void arc101_a_sample_1()
        {
            string input =
@"5 3
-30 -10 10 20 50
";
            string output =
@"40
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc101_a_sample_2()
        {
            string input =
@"3 2
10 20 30
";
            string output =
@"20
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc101_a_sample_3()
        {
            string input =
@"1 1
0
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc101_a_sample_4()
        {
            string input =
@"8 5
-9 -7 -4 -3 1 2 3 4
";
            string output =
@"10
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            arc101_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
