using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace _20200214
{
        [TestClass]
    public class ABC002_DTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.ABC002_D();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"5 3
1 2
2 3
1 3";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"5 3
1 2
2 3
3 4";
            string output =
@"2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"9 10
7 9
1 2
1 3
2 3
4 5
4 6
4 7
5 6
5 7
6 7";
            string output =
@"4";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_4()
        {
            string input =
@"12 0";
            string output =
@"1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_ex()
        {
            string input =
@"10 9
1 5
1 6
1 7
2 5
2 6
2 7
3 5
3 6
3 7";
            string output =
@"2";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class ABC124_DTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.ABC124_D();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"5 1
00010";
            string output =
@"4";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"14 2
11101010110011";
            string output =
@"8";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"1 1
1";
            string output =
@"1";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class ABC028_DTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.ABC028_D();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例1()
        {
            string input =
@"3 2";
            string output =
@"0.48148148148148145";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例2()
        {
            string input =
@"3 1";
            string output =
@"0.25925925925925924";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例3()
        {
            string input =
@"765 573";
            string output =
@"0.0014769739698462438";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class ABC075_CTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.ABC075_C();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"7 7
1 3
2 7
3 4
4 5
4 6
5 6
6 7";
            string output =
@"4";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"3 3
1 2
1 3
2 3";
            string output =
@"0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"6 5
1 2
2 3
3 4
4 5
5 6";
            string output =
@"5";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class ABC006_BTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.ABC006_B();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"7";
            string output =
@"7";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"1";
            string output =
@"0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"100000";
            string output =
@"7927";

            AssertIO(input, output);
        }

    }

}
