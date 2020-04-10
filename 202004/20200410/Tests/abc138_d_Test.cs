using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200410.Tests
{
    [TestClass]
    public class abc138_d_Test
    {
        [TestMethod]
        public void abc138_d_sample_1()
        {
            string input =
@"3 3
1 2
1 3
1 10
1 10
1 10
";
            string output =
@"30 30 30
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc138_d_sample_2()
        {
            string input =
@"6 2
1 2
1 3
2 4
3 6
2 5
1 10
1 10
";
            string output =
@"20 20 20 20 20 20
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc138_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
