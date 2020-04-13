using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _20200413.Tests
{
    [TestClass]
    public class abc096_c_Test
    {
        [TestMethod]
        public void abc096_c_sample_1()
        {
            string input =
@"3 3
.#.
###
.#.
";
            string output =
@"Yes
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc096_c_sample_2()
        {
            string input =
@"5 5
#.#.#
.#.#.
#.#.#
.#.#.
#.#.#
";
            string output =
@"No
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc096_c_sample_3()
        {
            string input =
@"11 11
...#####...
.##.....##.
#..##.##..#
#..##.##..#
#.........#
#...###...#
.#########.
.#.#.#.#.#.
##.#.#.#.##
..##.#.##..
.##..#..##.
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
            abc096_c.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
