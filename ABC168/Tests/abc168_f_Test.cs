using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC168.Tests
{
    [TestClass]
    public class abc168_f_Test
    {
        [TestMethod]
        public void abc168_f_sample_1()
        {
            string input =
@"5 6
1 2 0
0 1 1
0 2 2
-3 4 -1
-2 6 3
1 0 1
0 1 2
2 0 2
-1 -4 5
3 -2 4
1 2 4
";
            string output =
@"13
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc168_f_sample_2()
        {
            string input =
@"6 1
-3 -1 -2
-3 -1 1
-2 -1 2
1 4 -2
1 4 -1
1 4 1
3 1 4
";
            string output =
@"INF
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc168_f.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
