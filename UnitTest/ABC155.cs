using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

/// <summary>
/// Usage
/// 1.テスト対象プロジェクトを参照に追加
/// 2.namespaceをテスト対象と同じにする
/// 3.テストコード貼り付け
/// </summary>
namespace ABC155
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
@"5 7 5";
            string output =
@"Yes";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"4 4 4";
            string output =
@"No";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"4 9 6";
            string output =
@"No";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_4()
        {
            string input =
@"3 3 4";
            string output =
@"Yes";

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
6 7 9 10 31";
            string output =
@"APPROVED";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"3
28 27 24";
            string output =
@"DENIED";

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
@"7
beat
vet
beet
bed
vet
bet
beet";
            string output =
@"beet
vet";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"8
buffalo
buffalo
buffalo
buffalo
buffalo
buffalo
buffalo
buffalo";
            string output =
@"buffalo";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"7
bass
bass
kick
kick
bass
kick
kick";
            string output =
@"kick";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_4()
        {
            string input =
@"4
ushi
tapu
nichia
kun";
            string output =
@"kun
nichia
tapu
ushi";

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
@"4 3
3 3 -4 -2";
            string output =
@"-6";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"10 40
5 4 3 2 -1 0 0 0 0 0";
            string output =
@"6";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"30 413
-170202098 -268409015 537203564 983211703 21608710 -443999067 -937727165 -97596546 -372334013 398994917 -972141167 798607104 -949068442 -959948616 37909651 0 886627544 -20098238 0 -948955241 0 -214720580 277222296 -18897162 834475626 0 -425610555 110117526 663621752 0";
            string output =
@"448283280358331064";

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
@"36666";
            string output =
@"17";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_2()
        {
            string input =
@"91";
            string output =
@"3";

            AssertIO(input, output);
        }

        [TestMethod]
        public void 入力例_3()
        {
            string input =
@"314159265358979323846264338327950288419716939937551058209749445923078164062862089986280348253421170";
            string output =
@"243";

            AssertIO(input, output);
        }

    }

}
