using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC167.Tests
{
    [TestClass]
    public class abc167_d_Test
    {
        [TestMethod]
        public void abc167_d_sample_1()
        {
            string input =
@"4 5
3 2 4 1
";
            string output =
@"4
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc167_d_sample_2()
        {
            string input =
@"6 727202214173249351
6 5 2 5 3 2
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc167_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
