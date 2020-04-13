using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200413.Tests
{
    [TestClass]
    public class abc022_b_Test
    {
        [TestMethod]
        public void abc022_b_sample_1()
        {
            string input =
@"5
1
2
3
2
1
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc022_b_sample_2()
        {
            string input =
@"11
3
1
4
1
5
9
2
6
5
3
5
";
            string output =
@"4
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc022_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
