using CodingameProject.Source.MathematicalUtilities;
using NUnit.Framework;

namespace CodingameProject.Tests.MathematicalUtilities
{
    [TestFixture]
    public class ArithmeticSeriesCounterTests
    {
        [TestCase(3, 3, 5, 45)]
        [TestCase(10, 5, 7, 175)]
        [TestCase(2, 3, 50, 3775)]
        [Test]
        public void Test_PositiveDifference(int initialItem, int commonDifference, int countOfItems, int expectedResult)
        {
            var sut = new ArithmeticSeriesCounter(commonDifference);
            int result = sut.CountSum(initialItem, countOfItems);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(10, -3, 3, 21)]
        [TestCase(10, -3, 6, 15)]
        [TestCase(-10, -3, 6, -105)]
        [Test]
        public void Test_NegativeDifference(int initialItem, int commonDifference, int countOfItems, int expectedResult)
        {
            var sut = new ArithmeticSeriesCounter(commonDifference);
            int result = sut.CountSum(initialItem, countOfItems);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}