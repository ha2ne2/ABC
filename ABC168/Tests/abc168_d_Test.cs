using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC168.Tests
{
    [TestClass]
    public class abc168_d_Test
    {
        [TestMethod]
        public void abc168_d_sample_1()
        {
            string input =
@"4 4
1 2
2 3
3 4
4 2
";
            string output =
@"Yes
1
2
2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc168_d_sample_2()
        {
            string input =
@"6 9
3 4
6 1
2 4
5 3
4 6
1 5
6 2
4 5
5 6
";
            string output =
@"Yes
6
5
5
1
1
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc168_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
