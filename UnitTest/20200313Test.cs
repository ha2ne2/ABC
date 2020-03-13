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
    public class Joi2008yo_FTest
    {
        private void AssertIO(string input, string output)
        {
            StringReader reader = new StringReader(input);
            Console.SetIn(reader);

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            Program.Joi2008yo_F();

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
