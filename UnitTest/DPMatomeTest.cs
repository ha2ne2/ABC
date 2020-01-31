using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace DPMatome
{
    [TestClass]
    public class QTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Q();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void “ü—Í—á_1()
        {
            string input =
@"4
3 1 4 2
10 20 30 40";
            string output =
@"60";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_2()
        {
            string input =
@"1
1
10";
            string output =
@"10";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_3()
        {
            string input =
@"5
1 2 3 4 5
1000000000 1000000000 1000000000 1000000000 1000000000";
            string output =
@"5000000000";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_4()
        {
            string input =
@"9
4 2 5 8 3 6 1 7 9
6 8 8 4 6 3 5 7 5";
            string output =
@"31";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class PTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.P();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void “ü—Í—á_1()
        {
            string input =
@"3
1 2
2 3";
            string output =
@"5";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_2()
        {
            string input =
@"4
1 2
1 3
1 4";
            string output =
@"9";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_3()
        {
            string input =
@"1";
            string output =
@"2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_4()
        {
            string input =
@"10
8 5
10 8
6 5
1 5
4 8
2 10
3 6
9 2
1 7";
            string output =
@"157";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class OTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.O();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void “ü—Í—á_1()
        {
            string input =
@"3
0 1 1
1 0 1
1 1 1";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_2()
        {
            string input =
@"4
0 1 0 0
0 0 0 1
1 0 0 0
0 0 1 0";
            string output =
@"1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_3()
        {
            string input =
@"1
0";
            string output =
@"0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_4()
        {
            string input =
@"21
0 0 0 0 0 0 0 1 1 0 1 1 1 1 0 0 0 1 0 0 1
1 1 1 0 0 1 0 0 0 1 0 0 0 0 1 1 1 0 1 1 0
0 0 1 1 1 1 0 1 1 0 0 1 0 0 1 1 0 0 0 1 1
0 1 1 0 1 1 0 1 0 1 0 0 1 0 0 0 0 0 1 1 0
1 1 0 0 1 0 1 0 0 1 1 1 1 0 0 0 0 0 0 0 0
0 1 1 0 1 1 1 0 1 1 1 0 0 0 1 1 1 1 0 0 1
0 1 0 0 0 1 0 1 0 0 0 1 1 1 0 0 1 1 0 1 0
0 0 0 0 1 1 0 0 1 1 0 0 0 0 0 1 1 1 1 1 1
0 0 1 0 0 1 0 0 1 0 1 1 0 0 1 0 1 0 1 1 1
0 0 0 0 1 1 0 0 1 1 1 0 0 0 0 1 1 0 0 0 1
0 1 1 0 1 1 0 0 1 1 0 0 0 1 1 1 1 0 1 1 0
0 0 1 0 0 1 1 1 1 0 1 1 0 1 1 1 0 0 0 0 1
0 1 1 0 0 1 1 1 1 0 0 0 1 0 1 1 0 1 0 1 1
1 1 1 1 1 0 0 0 0 1 0 0 1 1 0 1 1 1 0 0 1
0 0 0 1 1 0 1 1 1 1 0 0 0 0 0 0 1 1 1 1 1
1 0 1 1 0 1 0 1 0 0 1 0 0 1 1 0 1 0 1 1 0
0 0 1 1 0 0 1 1 0 0 1 1 0 0 1 1 1 1 0 0 1
0 0 0 1 0 0 1 1 0 1 0 1 0 1 1 0 0 1 1 0 1
0 0 0 0 1 1 1 0 1 0 1 1 1 0 1 1 0 0 1 1 0
1 1 0 1 1 0 0 1 1 0 1 1 0 1 1 1 1 1 0 1 0
1 0 0 1 1 0 1 1 1 1 1 0 1 0 1 1 0 0 0 0 0";
            string output =
@"102515160";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class NTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.N();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void “ü—Í—á_1()
        {
            string input =
@"4
10 20 30 40";
            string output =
@"190";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_2()
        {
            string input =
@"5
10 10 10 10 10";
            string output =
@"120";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_3()
        {
            string input =
@"3
1000000000 1000000000 1000000000";
            string output =
@"5000000000";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_4()
        {
            string input =
@"6
7 6 8 6 1 1";
            string output =
@"68";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class MTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.M();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void “ü—Í—á_1()
        {
            string input =
@"3 4
1 2 3";
            string output =
@"5";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_2()
        {
            string input =
@"1 10
9";
            string output =
@"0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_3()
        {
            string input =
@"2 0
0 0";
            string output =
@"1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_4()
        {
            string input =
@"4 100000
100000 100000 100000 100000";
            string output =
@"665683269";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class LTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.L();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void “ü—Í—á_1()
        {
            string input =
@"4
10 80 90 30";
            string output =
@"10";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_2()
        {
            string input =
@"3
10 100 10";
            string output =
@"-80";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_3()
        {
            string input =
@"1
10";
            string output =
@"10";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_4()
        {
            string input =
@"10
1000000000 1 1000000000 1 1000000000 1 1000000000 1 1000000000 1";
            string output =
@"4999999995";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_5()
        {
            string input =
@"6
4 2 9 7 1 5";
            string output =
@"2";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class KTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.K();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void “ü—Í—á_1()
        {
            string input =
@"2 4
2 3";
            string output =
@"First";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_2()
        {
            string input =
@"2 5
2 3";
            string output =
@"Second";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_3()
        {
            string input =
@"2 7
2 3";
            string output =
@"First";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_4()
        {
            string input =
@"3 20
1 2 3";
            string output =
@"Second";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_5()
        {
            string input =
@"3 21
1 2 3";
            string output =
@"First";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_6()
        {
            string input =
@"1 100000
1";
            string output =
@"Second";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class JTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.J();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void “ü—Í—á_1()
        {
            string input =
@"3
1 1 1";
            string output =
@"5.5";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_2()
        {
            string input =
@"1
3";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_3()
        {
            string input =
@"2
1 2";
            string output =
@"4.5";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_4()
        {
            string input =
@"10
1 3 2 3 3 2 3 2 1 3";
            string output =
@"54.48064457488221";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class ITest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.I();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void “ü—Í—á_1()
        {
            string input =
@"3
0.30 0.60 0.80";
            string output =
@"0.612";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_2()
        {
            string input =
@"1
0.50";
            string output =
@"0.5";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_3()
        {
            string input =
@"5
0.42 0.01 0.42 0.99 0.42";
            string output =
@"0.3821815872";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class HTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.H();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void “ü—Í—á_1()
        {
            string input =
@"3 4
...#
.#..
....";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_2()
        {
            string input =
@"5 2
..
#.
..
.#
..";
            string output =
@"0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_3()
        {
            string input =
@"5 5
..#..
.....
#...#
.....
..#..";
            string output =
@"24";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_4()
        {
            string input =
@"20 20
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................";
            string output =
@"345263555";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class GTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.G();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void “ü—Í—á_1()
        {
            string input =
@"4 5
1 2
1 3
3 2
2 4
3 4";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_2()
        {
            string input =
@"6 3
2 3
4 5
5 6";
            string output =
@"2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void “ü—Í—á_3()
        {
            string input =
@"5 8
5 3
2 3
2 4
5 2
5 1
1 4
4 3
1 3";
            string output =
@"3";

            AssertIO(input, output);
        }

    }

}
