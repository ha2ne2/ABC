using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200412.Tests
{
    [TestClass]
    public class abc147_c_Test
    {
        [TestMethod]
        public void abc147_c_sample_1()
        {
            string input =
@"3
1
2 1
1
1 1
1
2 0
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc147_c_sample_2()
        {
            string input =
@"3
2
2 1
3 0
2
3 1
1 0
2
1 1
2 0
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc147_c_sample_3()
        {
            string input =
@"2
1
2 0
1
1 0
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc147_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
