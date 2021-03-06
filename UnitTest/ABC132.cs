﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace ABC132
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
@"ASSA";
            string output =
@"Yes";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"STOP";
            string output =
@"No";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"FFEE";
            string output =
@"Yes";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_4()
        {
            string input =
@"FREE";
            string output =
@"No";

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
@"5
1 3 5 4 2";
            string output =
@"2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"9
9 6 3 2 5 8 7 4 1";
            string output =
@"5";

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
@"6
9 1 4 4 6 7";
            string output =
@"2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"8
9 1 14 5 5 4 4 14";
            string output =
@"0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"14
99592 10342 29105 78532 83018 11639 92015 77204 30914 21912 34519 80835 100000 1";
            string output =
@"42685";

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
@"5 3";
            string output =
@"3
6
1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"2000 3";
            string output =
@"1998
3990006
327341989";

            AssertIO(input, output);
        }

    }
    [TestClass]
    public class ETest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.E();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"4 4
1 2
2 3
3 4
4 1
1 3";
            string output =
@"2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"3 3
1 2
2 3
3 1
1 2";
            string output =
@"-1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"2 0
1 2";
            string output =
@"-1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_4()
        {
            string input =
@"6 8
1 2
2 3
3 4
4 5
5 1
1 4
1 5
4 6
1 6";
            string output =
@"2";

            AssertIO(input, output);
        }

    }
    [TestClass]
    public class FTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.F();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"3 2";
            string output =
@"5";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"10 3";
            string output =
@"147";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"314159265 35";
            string output =
@"457397712";

            AssertIO(input, output);
        }

    }

}
