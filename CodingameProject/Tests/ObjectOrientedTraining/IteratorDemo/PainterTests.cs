using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.IteratorDemo
{
    [TestFixture]
    public class PainterTests
    {
        [TestCase(1, 12, "12:00")]
        [TestCase(3, 12, "4:00")]
        [Test]
        public void Test_EstimateDuration(int squareMetersPerHour, int squareMeters, string expected)
        {
            var sut = new Painter(squareMetersPerHour, 1, true);
            string result = sut.EstimateDuration(squareMeters).ToString("t");
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(5, 8, 40)]
        [Test]
        public void Test_EstimateCosts_1(int euroPerSquareMeter, int squareMeters, int expected)
        {
            var sut = new Painter(2, euroPerSquareMeter, true);
            int result = sut.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_IsAvailable_ReturnsTrue()
        {
            var sut = new Painter(10, 1, true);
            Assert.That(sut.IsAvailable, Is.EqualTo(true));
        }
    }
}