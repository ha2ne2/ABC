using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC151.Tests
{
    [TestClass]
    public class abc151_d_Test
    {
        [TestMethod]
        public void abc151_d_sample_1()
        {
            string input =
@"3 3
...
...
...
";
            string output =
@"4
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc151_d_sample_2()
        {
            string input =
@"3 5
...#.
.#.#.
.#...
";
            string output =
@"10
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc151_d.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
