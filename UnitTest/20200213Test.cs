using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace _20200213
{
    [TestClass]
    public class AGC034_BTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.AGC034_B();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"ABCABC";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"C";
            string output =
@"0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"ABCACCBABCBCAABCB";
            string output =
@"6";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class ABC016_CTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.ABC016_C();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例1()
        {
            string input =
@"3 2
1 2
2 3";
            string output =
@"1
0
1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例2()
        {
            string input =
@"3 3
1 2
1 3
2 3";
            string output =
@"0
0
0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例3()
        {
            string input =
@"8 12
1 6
1 7
1 8
2 5
2 6
3 5
3 6
4 5
4 8
5 6
5 7
7 8";
            string output =
@"4
4
4
5
2
3
4
2";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class ABC003_CTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.ABC003_C();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"2 2
1000 1500";
            string output =
@"1000";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"2 1
1000 1500";
            string output =
@"750";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"10 5
2604 2281 3204 2264 2200 2650 2229 2461 2439 2211";
            string output =
@"2820.03125";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class ARC066_CTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.ARC066_C();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"5
2 4 4 0 2";
            string output =
@"4";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"7
6 4 0 2 4 0 2";
            string output =
@"0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"8
7 5 1 1 7 3 5 3";
            string output =
@"16";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class ABC085_DTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.ABC085_D();

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"1 10
3 5";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"2 10
3 5
2 6";
            string output =
@"2";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"4 1000000000
1 1
1 10000000
1 30000000
1 99999999";
            string output =
@"860000004";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_4()
        {
            string input =
@"5 500
28 83
31 79
35 44
40 43
46 62";
            string output =
@"9";

            AssertIO(input, output);
        }

    }

}
