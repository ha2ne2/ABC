using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC168.Tests
{
    [TestClass]
    public class abc168_e_Test
    {
        [TestMethod]
        public void abc168_e_sample_1()
        {
            string input =
@"3
1 2
-1 1
2 -1
";
            string output =
@"5
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc168_e_sample_2()
        {
            string input =
@"10
3 2
3 2
-1 1
2 -1
-3 -9
-8 12
7 7
8 1
8 2
8 4
";
            string output =
@"479
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc168_e.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
