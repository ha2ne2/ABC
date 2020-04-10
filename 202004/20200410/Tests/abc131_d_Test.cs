using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200410.Tests
{
    [TestClass]
    public class abc131_d_Test
    {
        [TestMethod]
        public void abc131_d_sample_1()
        {
            string input =
@"5
2 4
1 9
1 8
4 9
3 12
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc131_d_sample_2()
        {
            string input =
@"3
334 1000
334 1000
334 1000
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc131_d_sample_3()
        {
            string input =
@"30
384 8895
1725 9791
170 1024
4 11105
2 6
578 1815
702 3352
143 5141
1420 6980
24 1602
849 999
76 7586
85 5570
444 4991
719 11090
470 10708
1137 4547
455 9003
110 9901
15 8578
368 3692
104 1286
3 4
366 12143
7 6649
610 2374
152 7324
4 7042
292 11386
334 5720
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc131_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
