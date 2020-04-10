using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC142.Tests
{
    [TestClass]
    public class abc142_f_Test
    {
        [TestMethod]
        public void abc142_f_sample_1()
        {
            string input =
@"4 5
1 2
2 3
2 4
4 1
4 3
";
            string output =
@"3
1
2
4
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc142_f_sample_2()
        {
            string input =
@"4 5
1 2
2 3
2 4
1 4
4 3
";
            string output =
@"-1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc142_f_sample_3()
        {
            string input =
@"6 9
1 2
2 3
3 4
4 5
5 6
5 1
5 2
6 1
6 2
";
            string output =
@"4
2
3
4
5
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc142_f.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
