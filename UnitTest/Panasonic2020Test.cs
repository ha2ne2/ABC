using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace Panasonic2020
{
    [TestClass]
    public class Panasonic2020_FTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            F.Main(null);

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"2
4 2 7 4
9 9 1 9";
            string output =
@"5
8";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Panasonic2020_ETest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            E.Main(null);

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"a?c
der
cod";
            string output =
@"7";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"atcoder
atcoder
???????";
            string output =
@"7";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Panasonic2020_DTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            D.Main(null);

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"1";
            string output =
@"a";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"2";
            string output =
@"aa
ab";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Panasonic2020_CTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            C.Main(null);

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"2 3 9";
            string output =
@"No";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_5()
        {
            string input =
@"1 1 1";
            string output =
@"No";

            AssertIO(input, output);
        }


        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"2 3 10";
            string output =
@"Yes";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Panasonic2020_BTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            B.Main(null);

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"1 3";
            string output =
@"1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"7 3";
            string output =
@"11";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"1000000000 1000000000";
            string output =
@"500000000000000000";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Panasonic2020_ATest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            A.Main(null);

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"6";
            string output =
@"2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"27";
            string output =
@"5";

            AssertIO(input, output);
        }

    }

}

