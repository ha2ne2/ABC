using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace ABC105
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
@"7 3";
            string output =
@"1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"100 10";
            string output =
@"0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"1 1";
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
@"11";
            string output =
@"Yes";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"40";
            string output =
@"Yes";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"3";
            string output =
@"No";

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
@"-9";
            string output =
@"1011";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"123456789";
            string output =
@"11000101011001101110100010101";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"0";
            string output =
@"0";

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
@"3 2
4 1 5";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"13 17
29 7 5 7 9 51 7 13 8 55 42 9 81";
            string output =
@"6";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"10 400000000
1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000";
            string output =
@"25";

            AssertIO(input, output);
        }

    }

}
