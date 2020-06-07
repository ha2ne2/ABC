using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC167.Tests
{
    [TestClass]
    public class abc167_a_Test
    {
        [TestMethod]
        public void abc167_a_sample_1()
        {
            string input =
@"chokudai
chokudaiz
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc167_a_sample_2()
        {
            string input =
@"snuke
snekee
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc167_a_sample_3()
        {
            string input =
@"a
aa
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
            abc167_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
