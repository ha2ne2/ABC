using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace ABC160
{
    [TestClass]
    public class Abc160_FTest
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
@"3
1 2
1 3";
            string output =
@"2
1
1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"2
1 2";
            string output =
@"1
1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"5
1 2
2 3
3 4
3 5";
            string output =
@"2
8
12
3
3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_4()
        {
            string input =
@"8
1 2
2 3
3 4
3 5
3 6
6 7
6 8";
            string output =
@"40
280
840
120
120
504
72
72";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Abc160_ETest
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
@"1 2 2 2 1
2 4
5 1
3";
            string output =
@"12";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"2 2 2 2 2
8 6
9 1
2 1";
            string output =
@"25";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"2 2 4 4 4
11 12 13 14
21 22 23 24
1 2 3 4";
            string output =
@"74";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Abc160_DTest
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
@"5 2 4";
            string output =
@"5
4
1
0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"3 1 3";
            string output =
@"3
0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"7 3 7";
            string output =
@"7
8
4
2
0
0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_4()
        {
            string input =
@"10 4 8";
            string output =
@"10
12
10
8
4
1
0
0
0";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Abc160_CTest
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
@"20 3
5 10 15";
            string output =
@"10";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"20 3
0 5 15";
            string output =
@"10";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class Abc160_BTest
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
@"1024";
            string output =
@"2020";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"0";
            string output =
@"0";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"1000000000";
            string output =
@"2000000000";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class Abc160_ATest
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
@"sippuu";
            string output =
@"Yes";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"iphone";
            string output =
@"No";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"coffee";
            string output =
@"Yes";

            AssertIO(input, output);
        }

    }

}

