using System;
using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.IteratorDemo
{
    [TestFixture]
    public class ProportionalPainterTests
    {
        [TestCase(5, 36, 3)]
        [TestCase(10, 36, 6)]
        [TestCase(5, 48, 4)]
        [TestCase(10, 48, 8)]
        [Test]
        public void TimeForOneSquareMeter_EstimateDuration(int minutesPerOneSquareMeter, int squareMeters, int expected)
        {
            var sut = new ProportionalPainter(TimeSpan.FromMinutes(minutesPerOneSquareMeter), 4, true);
            var result = sut.EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(TimeSpan.FromHours(expected)));
        }


        [TestCase(8, 5, 20)]
        [TestCase(9, 5, 22)]
        [TestCase(10, 5, 25)]
        [TestCase(11, 5, 27)]
        [TestCase(12, 5, 30)]
        [Test]
        public void EstimateCosts_ThirtyMinutesForOneMeter(int squareMeters, int euroPerHour, int expectedCost)
        {
            var sut = new ProportionalPainter(TimeSpan.FromMinutes(30), euroPerHour, true);
            int result = sut.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(expectedCost));
        }

        [TestCase(1, 5, 0)]
        [TestCase(6, 5, 5)]
        [TestCase(90, 5, 75)]
        [TestCase(12, 5, 10)]
        [TestCase(18, 5, 15)]
        [TestCase(102, 5, 85)]
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