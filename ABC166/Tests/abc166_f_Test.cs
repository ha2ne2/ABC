using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC166.Tests
{
    [TestClass]
    public class abc166_f_Test
    {
        [TestMethod]
        public void abc166_f_sample_1()
        {
            string input =
@"2 1 3 0
AB
AC
";
            string output =
@"Yes
A
C
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc166_f_sample_2()
        {
            string input =
@"3 1 0 0
AB
BC
AB
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc166_f_sample_3()
        {
            string input =
@"1 0 9 0
AC
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc166_f_sample_4()
        {
            string input =
@"8 6 9 1
AC
BC
AB
BC
AC
BC
AB
AB
";
            string output =
@"Yes
C
B
B
C
C
B
A
A
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc166_f.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
