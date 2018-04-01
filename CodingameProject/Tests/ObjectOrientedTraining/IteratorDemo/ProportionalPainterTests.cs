using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.IteratorDemo
{
    [TestFixture]
    public class ProportionalPainterTests
    {
        [TestCase(1, 12, "12:00:00")]
        [TestCase(3, 12, "04:00:00")]
        [Test]
        public void EstimateDuration(int squareMetersPerHour, int squareMeters, string expected)
        {
            var sut = new ProportionalPainter(squareMetersPerHour, 1, true);
            string result = sut.EstimateDuration(squareMeters).ToString("t");
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(8, 5, 20)]
        [TestCase(9, 5, 20)]
        [TestCase(10, 5, 25)]
        [TestCase(11, 5, 25)]
        [TestCase(12, 5, 30)]
        [Test]
        public void EstimateCosts_TwoMetersPerHour(int squareMeters, int euroPerHour, int expectedCost)
        {
            var sut = new ProportionalPainter(2, euroPerHour, true);
            int result = sut.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(expectedCost));
        }

        [TestCase(1, 5, 0)]
        [TestCase(5, 5, 5)]
        [TestCase(9, 5, 5)]
        [TestCase(10, 5, 10)]
        [TestCase(16, 5, 15)]
        [TestCase(99, 5, 95)]
        [Test]
        public void EstimateCosts_FiveMetersPerHour(int squareMeters, int euroPerHour, int expectedCost)
        {
            var sut = new ProportionalPainter(5, euroPerHour, true);
            int result = sut.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(expectedCost));
        }

        [Test]
        public void IsAvailable_ReturnsTrue()
        {
            var sut = new ProportionalPainter(10, 1, true);
            Assert.That(sut.IsAvailable, Is.EqualTo(true));
        }
    }
}