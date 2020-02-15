using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace _20200215
{
    [TestClass]
    public class Diverta2019_2_BTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Diverta2019_2_B();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"2
1 1
2 2";
            string output =
@"1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"3
7 8
1 4
4 6";
            string output =
@"1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"4
1 1
1 2
2 1
2 2";
            string output =
@"2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_4()
        {
            string input =
@"50
0 14
1 11
1 12
1 13
2 6
3 6
4 6
5 6
6 6
7 6
8 6
9 6
10 6
11 7
11 8
11 9
12 7
12 8
12 9
13 7
13 8
13 9
14 7
14 8
14 9
15 7
15 8
15 9
16 7
16 8
16 9
17 7
17 8
17 9
18 0
18 1
18 2
18 3
18 4
18 5
19 0
19 1
19 2
19 3
19 4
19 5
20 10
21 10
22 10
23 10
";
            string output =
@"15";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class ARC067_DTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.ARC067_D();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"4 2 5
1 2 5 7";
            string output =
@"11";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"7 1 100
40 43 45 105 108 115 124";
            string output =
@"84";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"7 1 2
24 35 40 68 72 99 103";
            string output =
@"12";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Tenka1_2017_CTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Tenka1_2017_C();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"2";
            string output =
@"1 2 2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"3485";
            string output =
@"872 1012974 1539173474040";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"4664";
            string output =
@"3498 3498 3498";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class AGC038_ATest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.AGC038_A();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"3 3 1 1";
            string output =
@"100
010
001";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"1 5 2 0";
            string output =
@"01010";

            AssertIO(input, output);
        }

                [TestMethod]
        public void 入力例_3()
        {
            string input =
@"6 6 2 2";
            string output =
@"110000
001100
000011
110000
001100
000011";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class ABC036_CTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            Program.ABC036_C();
            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例1()
        {
            string input =
@"5
3
3
1
6
1";
            string output =
@"1
1
0
2
0";

            AssertIO(input, output);
        }

    }
}
