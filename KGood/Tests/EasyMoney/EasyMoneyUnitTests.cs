using KGood.Source;
using KGood.Source.EasyMoney;
using NUnit.Framework;

namespace KGood.Tests.EasyMoney
{
    [TestFixture]
    public class EasyMoneyUnitTests
    {
        private EasyMoneyCounter sut;
        private readonly AsciiArt asciiArt = new AsciiArt();

        [SetUp]
        public void SetUp()
        {
            sut = new EasyMoneyCounter();
        }

        [TearDown]
        public void TearDown()
        {
            sut = null;
        }

        [Test]
        public void FourEuro_ResultIsEndedByEuroSign()
        {
            var result = sut.Calculate(4);
            Assert.That(result[result.Length - 1], Is.EqualTo('€'));
            Assert.IsTrue(result.EndsWith("€"));
        }

        [Test]
        public void OneEuro_ResultContainsSixCharacters()
        {
            var result = sut.Calculate(1);
            Assert.That(result.Length, Is.EqualTo(6), "Actual result: {0}", result);
        }

        [Test]
        public void OneEuro_ResultIs1x1Euro()
        {
            var result = sut.Calculate(1);
            Assert.That(result, Is.EqualTo("1 x 1€"));
        }

        [Test]
        public void TwoEuro_ResultIs1x2Euro()
        {
            var result = sut.Calculate(2);
            Assert.That(result, Is.EqualTo("1 x 2€"));
        }

        [Test]
        public void ThreeEuro_ResultContains13Characters()
        {
            var result = sut.Calculate(3);
            Assert.That(result.Length, Is.EqualTo(13), "Actual result: {0}", result);
        }

        [Test]
        public void ThreeEuro_ResultIs1x2And1x1Euro()
        {
            var result = sut.Calculate(3);
            Assert.That(result, Is.EqualTo("1 x 2, 1 x 1€"));
        }

        [Test]
        public void FourEuro_ResultIs2x2Euro()
        {
            var result = sut.Calculate(4);
            Assert.That(result, Is.EqualTo("2 x 2€"));
        }

        [Test]
        public void FiveEuro_ResultIsEndedByEuroSign()
        {
            var result = sut.Calculate(5);
            Assert.That(result[result.Length - 1], Is.EqualTo('€'));
            Assert.IsTrue(result.EndsWith("€"));
        }

        [Test]
        public void FiveEuro_ResultIs1x5Euro()
        {
            var result = sut.Calculate(5);
            Assert.That(result, Is.EqualTo("1 x 5€"));
        }

        [Test]
        public void FiftyCent_ResultIs1x0_5Euro()
        {
            var result = sut.Calculate(0.5);
            Assert.That(result, Is.EqualTo("1 x 0.5€"));
        }

        [Test]
        public void SeventyCent_ResultIs1x0_5And1x0_20Euro()
        {
            var result = sut.Calculate(0.7);
            Assert.That(result, Is.EqualTo("1 x 0.5, 1 x 0.2€"));
        }

        [Test]
        public void TenCent_ResultIs1x0_1Euro()
        {
            var result = sut.Calculate(0.1);
            Assert.That(result, Is.EqualTo("1 x 0.1€"));
        }

        [Test]
        public void NinetyCents_ResultIs1x0_5And2x0_2Euro()
        {
            var result = sut.Calculate(0.9);
            Assert.That(result, Is.EqualTo("1 x 0.5, 2 x 0.2€"));
        }

        [Test]
        public void EightyCents_ResultIs1x0_5And1x0_2And1x0_1Euro()
        {
            var result = sut.Calculate(0.9);
            Assert.That(result, Is.EqualTo("1 x 0.5, 2 x 0.2€"));
        }

        [Test]
        public void OneEuroAndTenCents_ResultIs1x1And1x0_1Euro()
        {
            var result = sut.Calculate(1.1);
            Assert.That(result, Is.EqualTo("1 x 1, 1 x 0.1€"));
        }

        [Test]
        public void GivenAmountLessThanMinimalCoin_ImpossibleIsReturned()
        {
            var result = sut.Calculate(0.09);
            Assert.That(result, Is.EqualTo("IMPOSSIBLE"));
        }

        [Test]
        public void GivenAmountEndsWithFiveCents_ImpossibleIsReturned()
        {
            var result = sut.Calculate(1.05);
            Assert.That(result, Is.EqualTo("IMPOSSIBLE"));
        }
    }
}