using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace _20200312
{
    [TestClass]
    public class Abc076_CTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Abc076_C();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"?tc????
coder";
            string output =
@"atcoder";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"??p??d??
abc";
            string output =
@"UNRESTORABLE";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Abc027_BTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Abc027_B();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例1()
        {
            string input =
@"3
1 2 3";
            string output =
@"2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例2()
        {
            string input =
@"5
2 0 0 0 3";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例3()
        {
            string input =
@"2
0 99";
            string output =
@"-1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例4()
        {
            string input =
@"4
0 0 0 0";
            string output =
@"0";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Abc099_CTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Abc099_C();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"127";
            string output =
@"4";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"3";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"44852";
            string output =
@"16";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class Joi2009ho_BTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Joi2009ho_B();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }
    }

        [TestClass]
    public class Arc084_ATest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Arc084_A();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"2
1 5
2 4
3 6";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"3
1 1 1
2 2 2
3 3 3";
            string output =
@"27";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"6
3 14 159 2 6 53
58 9 79 323 84 6
2643 383 2 79 50 288";
            string output =
@"87";

            AssertIO(input, output);
        }

    }
}
