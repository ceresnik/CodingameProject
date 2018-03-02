using CodingameProject.Source.SumOfDigitsCounter;
using NUnit.Framework;

namespace CodingameProject.Tests.SumOfDigitsCounter
{
    [TestFixture]
    public class NumberRepresentationTests
    {
        [TestCase(12, 3)]
        [TestCase(23891, 23)]
        [TestCase(1, 1)]
        [TestCase(987987, 48)]
        [Test]
        public void Test_GetSumOfDigits(int input, int expected)
        {
            int result = new NumberRepresentation(input).GetSumOfDigits();
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(12, 3)]
        [TestCase(23891, 5)]
        [TestCase(1, 1)]
        [TestCase(987987, 3)]
        [TestCase(99, 9)]
        [Test]
        public void Test_GetSumOfDigitsUntilNine(int input, int expected)
        {
            int result = new NumberRepresentation(input, new LessThanNineCondition()).GetSumOfDigits();
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}