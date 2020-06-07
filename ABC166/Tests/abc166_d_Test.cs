using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC166.Tests
{
    [TestClass]
    public class abc166_d_Test
    {
        [TestMethod]
        public void abc166_d_sample_1()
        {
            string input =
@"33
";
            string output =
@"2 -1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc166_d_sample_2()
        {
            string input =
@"1
";
            string output =
@"0 -1
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc166_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
