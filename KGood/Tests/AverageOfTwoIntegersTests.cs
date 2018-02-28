using KGood.Source;
using NUnit.Framework;

namespace KGood.Tests
{
    [TestFixture]
    class AverageOfTwoIntegersTests
    {
        private AverageOfTwoIntegers sut;

        [SetUp]
        public void SetUp()
        {
            sut = new AverageOfTwoIntegers();
        }

        [Test]
        public void FirstAverageIsDouble()
        {
            var result = $"{sut.CountAverage(2, 3)} {sut.CountAverage(4, 2)}";
            Assert.That(result, Is.EqualTo("2.5 3"));
        }

        [Test]
        public void SecondAverageIsDouble()
        {
            var result = $"{sut.CountAverage(1, 3)} {sut.CountAverage(5, 2)}";
            Assert.That(result, Is.EqualTo("2 3.5"));
        }

        [Test]
        public void BothAveragesAreDouble()
        {
            var result = $"{sut.CountAverage(2, 3)} {sut.CountAverage(1, 2)}";
            Assert.That(result, Is.EqualTo("2.5 1.5"));
        }
    }
}
