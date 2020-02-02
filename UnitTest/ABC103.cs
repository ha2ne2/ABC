using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace ABC103
{
    [TestClass]
    public class ATest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.A();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"1 6 3";
            string output =
@"5";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"11 5 5";
            string output =
@"6";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"100 100 100";
            string output =
@"0";

            AssertIO(input, output);
        }

    }
    [TestClass]
    public class BTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.B();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"kyoto
tokyo";
            string output =
@"Yes";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"abc
arc";
            string output =
@"No";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"aaaaaaaaaaaaaaab
aaaaaaaaaaaaaaab";
            string output =
@"Yes";

            AssertIO(input, output);
        }

    }
    [TestClass]
    public class CTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.C();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"3
3 4 6";
            string output =
@"10";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"5
7 46 11 20 11";
            string output =
@"90";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"7
994 518 941 851 647 2 581";
            string output =
@"4527";

            AssertIO(input, output);
        }

    }
    [TestClass]
    public class DTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.D();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"5 2
1 4
2 5";
            string output =
@"1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"9 5
1 8
2 7
3 5
4 6
7 9";
            string output =
@"2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"5 10
1 2
1 3
1 4
1 5
2 3
2 4
2 5
3 4
3 5
4 5";
            string output =
@"4";

            AssertIO(input, output);
        }

    }

}
