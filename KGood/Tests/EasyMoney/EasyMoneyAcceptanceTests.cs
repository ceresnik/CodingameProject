using KGood.Source.EasyMoney;
using NUnit.Framework;

namespace KGood.Tests.EasyMoney
{
    [TestFixture]
    public class EasyMoneyAcceptanceTests
    {
        private EasyMoneyCounter sut;

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
        public void Impossible()
        {
            Assert.That(sut.Calculate(511.15), Is.EqualTo("IMPOSSIBLE"));
        }

        [Test]
        public void Example()
        {
            Assert.That(sut.Calculate(1234), Is.EqualTo("2 x 500, 1 x 200, 1 x 20, 1 x 10, 2 x 2€"));
        }

        [Test]
        public void Medium_Difficulty()
        {
            Assert.That(sut.Calculate(100000), Is.EqualTo("200 x 500€"));
        }

        [Test]
        public void Hard_Difficulty()
        {
            Assert.That(sut.Calculate(5127000.5), Is.EqualTo("10254 x 500, 1 x 0.5€"));
        }
    }
}