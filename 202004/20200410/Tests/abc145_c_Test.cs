using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200410.Tests
{
    [TestClass]
    public class abc145_c_Test
    {
        [TestMethod]
        public void abc145_c_sample_1()
        {
            string input =
@"3
0 0
1 0
0 1
";
            string output =
@"2.2761423749
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc145_c_sample_2()
        {
            string input =
@"2
-879 981
-866 890
";
            string output =
@"91.9238815543
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc145_c_sample_3()
        {
            string input =
@"8
-406 10
512 859
494 362
-955 -475
128 553
-986 -885
763 77
449 310
";
            string output =
@"7641.9817824387
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc145_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
