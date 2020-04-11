using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200411.Tests
{
    [TestClass]
    public class arc090_b_Test
    {
        [TestMethod]
        public void arc090_b_sample_1()
        {
            string input =
@"3 3
1 2 1
2 3 1
1 3 2
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc090_b_sample_2()
        {
            string input =
@"3 3
1 2 1
2 3 1
1 3 5
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc090_b_sample_3()
        {
            string input =
@"4 3
2 1 1
2 3 5
3 4 2
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc090_b_sample_4()
        {
            string input =
@"10 3
8 7 100
7 9 100
9 8 100
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void arc090_b_sample_5()
        {
            string input =
@"100 0
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            arc090_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
