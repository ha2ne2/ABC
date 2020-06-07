using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC166.Tests
{
    [TestClass]
    public class abc166_b_Test
    {
        [TestMethod]
        public void abc166_b_sample_1()
        {
            string input =
@"3 2
2
1 3
1
3
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc166_b_sample_2()
        {
            string input =
@"3 3
1
3
1
3
1
3
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
            abc166_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
