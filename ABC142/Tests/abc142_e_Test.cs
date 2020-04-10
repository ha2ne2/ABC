using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC142.Tests
{
    [TestClass]
    public class abc142_e_Test
    {
        [TestMethod]
        public void abc142_e_sample_1()
        {
            string input =
@"2 3
10 1
1
15 1
2
30 2
1 2
";
            string output =
@"25
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc142_e_sample_2()
        {
            string input =
@"12 1
100000 1
2
";
            string output =
@"-1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc142_e_sample_3()
        {
            string input =
@"4 6
67786 3
1 3 4
3497 1
2
44908 3
2 3 4
2156 3
2 3 4
26230 1
2
86918 1
3
";
            string output =
@"69942
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc142_e.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
