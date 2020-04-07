using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC141
{
    [TestClass]
    public class ATest
    {
        [TestMethod]
        public void sample_1()
        {
            string input =
@"Sunny
";
            string output =
@"Cloudy
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_2()
        {
            string input =
@"Rainy
";
            string output =
@"Sunny
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            A.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }

    [TestClass]
    public class BTest
    {
        [TestMethod]
        public void sample_1()
        {
            string input =
@"RUDLUDR
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_2()
        {
            string input =
@"DULL
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_3()
        {
            string input =
@"UUUUUUUUUUUUUUU
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_4()
        {
            string input =
@"ULURU
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_5()
        {
            string input =
@"RDULULDURURLRDULRLR
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            B.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }

    [TestClass]
    public class CTest
    {
        [TestMethod]
        public void sample_1()
        {
            string input =
@"6 3 4
3
1
3
2
";
            string output =
@"No
No
Yes
No
No
No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_2()
        {
            string input =
@"6 5 4
3
1
3
2
";
            string output =
@"Yes
Yes
Yes
Yes
Yes
Yes
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_3()
        {
            string input =
@"10 13 15
3
1
4
1
5
9
2
6
5
3
5
8
9
7
9
";
            string output =
@"No
No
No
No
Yes
No
No
No
Yes
No
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            C.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }

    [TestClass]
    public class DTest
    {
        [TestMethod]
        public void sample_1()
        {
            string input =
@"3 3
2 13 8
";
            string output =
@"9
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_2()
        {
            string input =
@"4 4
1 9 3 5
";
            string output =
@"6
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_3()
        {
            string input =
@"1 100000
1000000000
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_4()
        {
            string input =
@"10 1
1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000
";
            string output =
@"9500000000
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            D.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }

    [TestClass]
    public class ETest
    {
        [TestMethod]
        public void sample_1()
        {
            string input =
@"5
ababa
";
            string output =
@"2
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_2()
        {
            string input =
@"2
xy
";
            string output =
@"0
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_3()
        {
            string input =
@"13
strangeorange
";
            string output =
@"5
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            E.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }

    [TestClass]
    public class FTest
    {
        [TestMethod]
        public void sample_1()
        {
            string input =
@"3
3 6 5
";
            string output =
@"12
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_2()
        {
            string input =
@"4
23 36 66 65
";
            string output =
@"188
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void sample_3()
        {
            string input =
@"20
1008288677408720767 539403903321871999 1044301017184589821 215886900497862655 504277496111605629 972104334925272829 792625803473366909 972333547668684797 467386965442856573 755861732751878143 1151846447448561405 467257771752201853 683930041385277311 432010719984459389 319104378117934975 611451291444233983 647509226592964607 251832107792119421 827811265410084479 864032478037725181
";
            string output =
@"2012721721873704572
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            F.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }

}
