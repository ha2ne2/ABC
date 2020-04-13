using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC162.Tests
{
    [TestClass]
    public class abc162_f_Test
    {
        [TestMethod]
        public void abc162_f_sample_1()
        {
            string input =
@"3
1 1 1
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc162_f_sample_2()
        {
            string input =
@"5
-1000 -100 -10 0 10
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc162_f_sample_3()
        {
            string input =
@"10
1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000
";
            string output =
@"5000000000
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc162_f_sample_4()
        {
            string input =
@"27
18 -28 18 28 -45 90 -45 23 -53 60 28 -74 -71 35 -26 -62 49 -77 57 24 -70 -93 69 -99 59 57 -49
";
            string output =
@"295
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc162_f.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
