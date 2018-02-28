using KGood.Source;
using NUnit.Framework;

namespace KGood.Tests
{
    public class ChocolateBarSplitterTests
    {
        [TestCase(2, 2, 3)]
        [TestCase(1, 3, 2)]
        [TestCase(5, 1, 4)]
        [TestCase(20, 30, 599)]
        [TestCase(78, 12, 935)]
        [Test]
        public void Test(int rows, int columns, int result)
        {
            ChocolateBarSplitter sut = new ChocolateBarSplitter();
            Assert.That(sut.CountSplits(rows, columns), Is.EqualTo(result));
        }
    }
}