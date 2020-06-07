using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ABC168.Tests
{
    [TestClass]
    public class abc168_b_Test
    {
        [TestMethod]
        public void abc168_b_sample_1()
        {
            string input =
@"7
nikoandsolstice
";
            string output =
@"nikoand...
";
            AssertIO(input, output);
        }

        [TestMethod]
        public void abc168_b_sample_2()
        {
            string input =
@"40
ferelibenterhominesidquodvoluntcredunt
";
            string output =
@"ferelibenterhominesidquodvoluntcredunt
";
            AssertIO(input, output);
        }

        private void AssertIO(string input, string output)
        {
            Console.SetIn(new StringReader(input));
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            abc168_b.Program.Main(null);
            Assert.AreEqual(output, writer.ToString());
        }
    }
}
