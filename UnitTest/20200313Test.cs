using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace _20200313
{
    [TestClass]
    public class Agc035_ATest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Agc035_A.Main(null);

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"3
1 2 3";
            string output =
@"Yes";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"6
1 2 3 3 2 1";
            string output =
@"Yes";

            AssertIO(input, output);
        }


        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"4
1 2 4 8";
            string output =
@"No";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Sumitb2019_DTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Sumitb2019_D.Main(null);

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"4
0224";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"6
123123";
            string output =
@"17";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"19
3141592653589793238";
            string output =
@"329";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Keyence2020_BTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Keyence2020_B.Main(null);

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"4
2 4
4 3
9 3
100 5";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"2
8 20
1 10";
            string output =
@"1";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"5
10 1
2 1
4 1
6 1
8 1";
            string output =
@"5";

            AssertIO(input, output);
        }

    }

    [TestClass]
    public class Abc051_CTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Abc051_C.Main(null);

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"0 0 1 2";
            string output =
@"UURDDLLUUURRDRDDDLLU";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"-2 -2 1 1";
            string output =
@"UURRURRDDDLLDLLULUUURRURRDDDLLDL";

            AssertIO(input, output);
        }

    }


    [TestClass]
    public class Joi2008yo_FTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Joi2008yo_F.Main(null);

            Assert.AreEqual(output + Environment.NewLine, writer.ToString());
        }

        [TestMethod]
        public void 入力例_1()
        {
            string input =
@"3 8
1 3 1 10
0 2 3
1 2 3 20
1 1 2 5
0 3 2
1 1 3 7
1 2 1 9
0 2 3";
            string output =
@"-1
15
12";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"5 16
1 1 2 343750
1 1 3 3343
1 1 4 347392
1 1 5 5497
1 2 3 123394
1 2 4 545492
1 2 5 458
1 3 4 343983
1 3 5 843468
1 4 5 15934
0 2 1
0 4 1
0 3 2
0 4 2
0 4 3
0 5 3";
            string output =
@"5955
21431
9298
16392
24774
8840";

            AssertIO(input, output);
        }

    }
}
