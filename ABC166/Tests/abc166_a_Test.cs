using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC166.Tests
{
    [TestClass]
    public class abc166_a_Test
    {
        [TestMethod]
        public void abc166_a_sample_1()
        {
            string input =
@"ABC
";
            string output =
@"ARC
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc166_a.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
