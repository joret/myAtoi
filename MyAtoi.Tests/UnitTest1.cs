using NUnit.Framework;
using MyAtoi;

namespace myAtoi.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var program = new Program();
            var output = program.MyAtoi("  0000000000012345678");
            Assert.AreEqual(12345678, output);
        }

        [Test]
        public void Test2()
        {
            var program = new Program();
            var output = program.MyAtoi("    0000000000000   ");
            Assert.AreEqual(0, output);
        }

        //"20000000000000000000"
        [Test]
        public void Test3()
        {
            var program = new Program();
            var output = program.MyAtoi("20000000000000000000");
            Assert.AreEqual(2147483647, output);
        }
    }
}