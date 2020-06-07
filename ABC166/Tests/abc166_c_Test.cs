using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC166.Tests
{
    [TestClass]
    public class abc166_c_Test
    {
        [TestMethod]
        public void abc166_c_sample_1()
        {
            string input =
@"4 3
1 2 3 4
1 3
2 3
2 4
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc166_c_sample_2()
        {
            string input =
@"6 5
8 6 9 1 2 1
1 3
4 2
4 3
4 6
4 6
";
            string output =
@"3
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc166_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
