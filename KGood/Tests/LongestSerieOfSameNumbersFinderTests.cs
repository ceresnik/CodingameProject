using KGood.Source;
using NUnit.Framework;

namespace KGood.Tests
{
    [TestFixture]
    public class LongestSerieOfSameNumbersFinderTests
    {
        [TestCase(1, 1)]
        [TestCase(9, 1)]
        [TestCase(12, 1)]
        [TestCase(988, 2)]
        [TestCase(111, 3)]
        [TestCase(1111, 4)]
        [TestCase(1112, 3)]
        [TestCase(2111, 3)]
        [TestCase(123456789, 1)]
        [TestCase(1234566789, 2)]
        [TestCase(1234566999, 3)]
        [TestCase(1233334569, 4)]
        [TestCase(1233344569, 3)]
        [TestCase(555555555, 9)]
        [Test]
        public void Test(int inputNumber, int expected)
        {
            var result = LongestSerieOfSameNumbersFinder.Find(inputNumber.ToString());
            Assert.That(result.Length, Is.EqualTo(expected));
        }
    }
}