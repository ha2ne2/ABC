using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC167.Tests
{
    [TestClass]
    public class abc167_e_Test
    {
        [TestMethod]
        public void abc167_e_sample_1()
        {
            string input =
@"3 2 1
";
            string output =
@"6
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc167_e_sample_2()
        {
            string input =
@"100 100 0
";
            string output =
@"73074801
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc167_e_sample_3()
        {
            string input =
@"60522 114575 7559
";
            string output =
@"479519525
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc167_e.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
