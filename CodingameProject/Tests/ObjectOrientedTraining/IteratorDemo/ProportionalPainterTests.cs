using System;
using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.IteratorDemo
{
    [TestFixture]
    public class ProportionalPainterTests
    {
        [TestCase(5, 36, 180)]
        [TestCase(10, 36, 360)]
        [TestCase(5, 48, 240)]
        [TestCase(10, 48, 480)]
        [TestCase(7, 6, 42)]
        [TestCase(7, 7, 50)]
        [TestCase(7, 8, 56)]
        [TestCase(7, 9, 64)]
        [Test]
        public void EstimateDuration(int minutesPerOneSquareMeter, int squareMeters, int expected)
        {
            var sut = new ProportionalPainter(TimeSpan.FromMinutes(minutesPerOneSquareMeter), 4, true);
            var result = sut.EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(expected)));
        }


        [TestCase(8, 5, 20)]
        [TestCase(9, 1, 4)]
        [TestCase(10, 54, 270)]
        [TestCase(11, 35, 192)]
        [TestCase(12, 7, 42)]
        [Test]
        public void EstimateCosts_ThirtyMinutesForOneMeter(int squareMeters, int euroPerHour, int expectedCost)
        {
            var sut = new ProportionalPainter(TimeSpan.FromMinutes(30), euroPerHour, true);
            int result = sut.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(expectedCost));
        }

        [TestCase(1, 4, 0)]
        [TestCase(6, 7, 7)]
        [TestCase(90, 9, 135)]
        [TestCase(12, 2, 4)]
        [TestCase(18, 50, 150)]
        [TestCase(102, 29, 493)]
        [Test]
        public void EstimateCosts_TenMinutesPerOneMeter(int squareMeters, int euroPerHour, int expectedCost)
        {
            var sut = new ProportionalPainter(TimeSpan.FromMinutes(10), euroPerHour, true);
            int result = sut.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(expectedCost));
        }

        [Test]
        public void IsAvailable_ReturnsTrue()
        {
            var sut = new ProportionalPainter(TimeSpan.FromMinutes(10), 1, true);
            Assert.That(sut.IsAvailable, Is.True);
        }

        [Test]
        public void IsNotAvailable_ReturnsFalse()
        {
            var sut = new ProportionalPainter(TimeSpan.FromMinutes(10), 1, false);
            Assert.That(sut.IsAvailable, Is.False);
        }
    }
}