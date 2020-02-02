using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace ABC104
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
@"1199";
            string output =
@"ABC";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"1200";
            string output =
@"ARC";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"4208";
            string output =
@"AGC";

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
@"AtCoder";
            string output =
@"AC";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"ACoder";
            string output =
@"WA";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"AcycliC";
            string output =
@"WA";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_4()
        {
            string input =
@"AtCoCo";
            string output =
@"WA";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_5()
        {
            string input =
@"Atcoder";
            string output =
@"WA";

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
@"2 700
3 500
5 800";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"2 2000
3 500
5 800";
            string output =
@"7";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"2 400
3 500
5 800";
            string output =
@"2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_4()
        {
            string input =
@"5 25000
20 1000
40 1000
50 1000
30 1000
1 1000";
            string output =
@"66";

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
@"A??C";
            string output =
@"8";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"ABCBC";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"????C?????B??????A???????";
            string output =
@"979596887";

            AssertIO(input, output);
        }

    }


}
