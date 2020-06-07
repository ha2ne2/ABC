using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC167.Tests
{
    [TestClass]
    public class abc167_f_Test
    {
        [TestMethod]
        public void abc167_f_sample_1()
        {
            string input =
@"2
)
(()
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc167_f_sample_2()
        {
            string input =
@"2
)(
()
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc167_f_sample_3()
        {
            string input =
@"4
((()))
((((((
))))))
()()()
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc167_f_sample_4()
        {
            string input =
@"3
(((
)
)
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc167_f.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
