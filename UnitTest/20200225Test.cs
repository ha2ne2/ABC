using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace _20200225
{
    [TestClass]
    public class Arc103_ATest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Arc103_A();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"4
3 1 3 2";
            string output =
@"1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"6
105 119 105 119 119 119";
            string output =
@"1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"4
1 1 1 1";
            string output =
@"2";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class Arc054_ATest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Arc054_A();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例1()
        {
            string input =
@"6 2 3 1 5";
            string output =
@"0.8000000000";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例2()
        {
            string input =
@"6 2 10 1 5";
            string output =
@"0.2500000000";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例3()
        {
            string input =
@"6 3 1 5 3";
            string output =
@"1.0000000000";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例4()
        {
            string input =
@"10 7 7 6 0";
            string output =
@"0.2857142857";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例5()
        {
            string input =
@"10 1 1 9 1";
            string output =
@"1";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Code_Festival_2017_Qualc_BTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Code_Festival_2017_Qualc_B();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"2
2 3";
            string output =
@"7";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"3
3 3 3";
            string output =
@"26";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"1
100";
            string output =
@"1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_4()
        {
            string input =
@"10
90 52 56 71 44 8 13 30 57 84";
            string output =
@"58921";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class Abc075_BTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Abc075_B();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"3 5
.....
.#.#.
.....";
            string output =
@"11211
1#2#1
11211";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"3 5
#####
#####
#####";
            string output =
@"#####
#####
#####";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"6 6
#####.
#.#.##
####.#
.#..#.
#.##..
#.#...";
            string output =
@"#####3
#8#7##
####5#
4#65#2
#5##21
#4#310";

            AssertIO(input, output);
        }

    }

}
