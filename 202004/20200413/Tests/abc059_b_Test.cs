using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200413.Tests
{
    [TestClass]
    public class abc059_b_Test
    {
        [TestMethod]
        public void abc059_b_sample_1()
        {
            string input =
@"36
24
";
            string output =
@"GREATER
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc059_b_sample_2()
        {
            string input =
@"850
3777
";
            string output =
@"LESS
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc059_b_sample_3()
        {
            string input =
@"9720246
22516266
";
            string output =
@"LESS
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc059_b_sample_4()
        {
            string input =
@"123456789012345678901234567890
234567890123456789012345678901
";
            string output =
@"LESS
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc059_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
