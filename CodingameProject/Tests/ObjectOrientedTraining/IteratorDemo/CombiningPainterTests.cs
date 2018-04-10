using System;
using System.Collections.Generic;
using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.IteratorDemo
{
    [TestFixture]
    public class CombiningPainterTests
    {
        [Test]
        public void Constructor()
        {
            IEnumerable<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                                  {
                                                                      new ProportionalPainter(TimeSpan.FromMinutes(10), 4, true),
                                                                      new ProportionalPainter(TimeSpan.FromMinutes(5), 8, true)
                                                                  };
            CompositePainter<IPainter> sut = new CombiningPainter(sequenceOfPainters);
            Assert.That(sut, Is.Not.Null);
        }

        [TestCase(9, 30)]
        [TestCase(18, 60)]
        [TestCase(36, 120)]
        [Test]
        public void EstimateDuration(int squareMeters, int expected)
        {
            IEnumerable<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                                  {
                                                                      new ProportionalPainter(TimeSpan.FromMinutes(10), 4, true),
                                                                      new ProportionalPainter(TimeSpan.FromMinutes(5), 8, true)
                                                                  };
            var combiningPainter = new CombiningPainter(sequenceOfPainters);
            TimeSpan result = combiningPainter.EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(expected)));
        }

        [TestCase(9, 6)]
        [TestCase(18, 12)]
        [TestCase(36, 24)]
        [Test]
        public void EstimateCosts(int squareMeters, int expected)
        {
            IEnumerable<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                                  {
                                                                      new ProportionalPainter(TimeSpan.FromMinutes(10), 4, true),
                                                                      new ProportionalPainter(TimeSpan.FromMinutes(5), 8, true)
                                                                  };
            var combiningPainter = new CombiningPainter(sequenceOfPainters);
            int result = combiningPainter.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void NoOnePainterIsAvailable_NotAvailable()
        {
            IList<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                            {
                                                                new ProportionalPainter(TimeSpan.FromMinutes(6), 30, false),
                                                                new ProportionalPainter(TimeSpan.FromMinutes(12), 15, false)
                                                            };
            var sut = new CombiningPainter(sequenceOfPainters);
            bool result = sut.IsAvailable;
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void OnePainterIsAvailable_Available()
        {
            IList<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                            {
                                                                new ProportionalPainter(TimeSpan.FromMinutes(6), 30, false),
                                                                new ProportionalPainter(TimeSpan.FromMinutes(12), 15, true)
                                                            };
            var sut = new CombiningPainter(sequenceOfPainters);
            bool result = sut.IsAvailable;
            Assert.That(result, Is.EqualTo(true));
        }
    }
}