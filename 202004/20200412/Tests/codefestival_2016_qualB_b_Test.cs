using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200412.Tests
{
    [TestClass]
    public class codefestival_2016_qualB_b_Test
    {
        [TestMethod]
        public void codefestival_2016_qualB_b_sample_1()
        {
            string input =
@"10 2 3
abccabaabb
";
            string output =
@"Yes
Yes
No
No
Yes
Yes
Yes
No
No
No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void codefestival_2016_qualB_b_sample_2()
        {
            string input =
@"12 5 2
cabbabaacaba
";
            string output =
@"No
Yes
Yes
Yes
Yes
No
Yes
Yes
No
Yes
No
No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void codefestival_2016_qualB_b_sample_3()
        {
            string input =
@"5 2 2
ccccc
";
            string output =
@"No
No
No
No
No
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            codefestival_2016_qualB_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
