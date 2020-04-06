using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Judge_Update_202004
{
    [TestClass]
    public class ATest
    {
        [TestMethod]
        public void sample_1()
        {
            string input =
@"5 1 5
";
            string output =
@"5
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_2()
        {
            string input =
@"2 7 10
";
            string output =
@"7
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_3()
        {
            string input =
@"20 3 5
";
            string output =
@"5
";
            AssertIO(input, output);
        }


        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            A.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }

    [TestClass]
    public class BTest
    {
        [TestMethod]
        public void sample_1()
        {
            string input =
@"4
10 B
6 R
2 R
4 B
";
            string output =
@"2
6
4
10
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_2()
        {
            string input =
@"2
5 B
7 B
";
            string output =
@"5
7
";
            AssertIO(input, output);
        }


        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            B.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }

    [TestClass]
    public class CTest
    {
        [TestMethod]
        public void sample_1()
        {
            string input =
@"1 1 1
";
            string output =
@"1
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_2()
        {
            string input =
@"2 1 1
";
            string output =
@"3
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_3()
        {
            string input =
@"2 2 1
";
            string output =
@"5
";
            AssertIO(input, output);
        }


        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            C.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }

    [TestClass]
    public class DTest
    {
        [TestMethod]
        public void sample_1()
        {
            string input =
@"4 3
6 12 6 9
4 6 3
";
            string output =
@"4
3
3
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_2()
        {
            string input =
@"4 3
4 6 2 1
3 2 1000000000
";
            string output =
@"1
4
4
";
            AssertIO(input, output);
        }


        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            D.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }

}
