using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200410.Tests
{
    [TestClass]
    public class nikkei2019_qual_c_Test
    {
        [TestMethod]
        public void nikkei2019_qual_c_sample_1()
        {
            string input =
@"3
10 10
20 20
30 30
";
            string output =
@"20
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void nikkei2019_qual_c_sample_2()
        {
            string input =
@"3
20 10
20 20
20 30
";
            string output =
@"20
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void nikkei2019_qual_c_sample_3()
        {
            string input =
@"6
1 1000000000
1 1000000000
1 1000000000
1 1000000000
1 1000000000
1 1000000000
";
            string output =
@"-2999999997
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            nikkei2019_qual_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
