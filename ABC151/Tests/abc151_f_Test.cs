using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC151.Tests
{
    [TestClass]
    public class abc151_f_Test
    {
        [TestMethod]
        public void abc151_f_sample_1()
        {
            string input =
@"2
0 0
1 0
";
            string output =
@"0.500000000000000000
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc151_f_sample_2()
        {
            string input =
@"3
0 0
0 1
1 0
";
            string output =
@"0.707106781186497524
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc151_f_sample_3()
        {
            string input =
@"10
10 9
5 9
2 0
0 0
2 7
3 3
2 5
10 0
3 7
1 9
";
            string output =
@"6.726812023536805158
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc151_f.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
