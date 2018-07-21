using System;
using System.Collections.Generic;
using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.IteratorDemo
{
    [TestFixture]
    public class PaintersTests
    {
        [Test]
        public void FindCheapestAvailablePainter()
        {
            IEnumerable<IPainter> sequenceOfPainters = new List<IPainter>
                                             {
                                                 new ProportionalPainter(TimeSpan.FromMinutes(30), 3, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 2, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(15), 7, false),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(60), 5, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(6), 1, false)
                                             };
            var sut = new Painters(sequenceOfPainters);
            var cheapestPainter = sut.ThoseAvailable.GetCheapest(10);
            Assert.That(cheapestPainter, Is.EqualTo(new ProportionalPainter(TimeSpan.FromMinutes(10), 2, true)));
        }

        [Test]
        public void FindCheapestPainterAtAll()
        {
            IEnumerable<IPainter> sequenceOfPainters = new List<IPainter>
                                             {
                                                 new ProportionalPainter(TimeSpan.FromMinutes(30), 3, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 2, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(15), 7, false),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(60), 5, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(6), 1, false)
                                             };
            var sut = new Painters(sequenceOfPainters);
            var cheapestPainter = sut.GetCheapest(10);
            Assert.That(cheapestPainter, Is.EqualTo(new ProportionalPainter(TimeSpan.FromMinutes(6), 1, false)));
        }

        [Ignore("Not implemented")]
        [Test]
        public void FindCheapestPainter_NoPainter_Null()
        {
            var sut = new Painters(new List<IPainter>());
            var result = sut.GetCheapest(10);
            Assert.That(result, Is.EqualTo(null));
        }

        [Ignore("Not implemented")]
        [Test]
        public void FindCheapestPainter_NoneIsAvailable_Null()
        {
            IEnumerable<IPainter> sequenceOfPainters = new List<IPainter>
                                             {
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 3, false),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 2, false),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 7, false),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 5, false),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 3, false)
                                             };
            var sut = new Painters(sequenceOfPainters);
            var cheapestPainter = sut.GetCheapest(10);
            Assert.That(cheapestPainter, Is.EqualTo(null));
        }
        [Test]
        public void FindFastestAvailablePainter()
        {
            int squareMeters = 10;
            IList<IPainter> sequenceOfPainters = new List<IPainter>
                                       {
                                           new ProportionalPainter(TimeSpan.FromMinutes(11), 5, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(9), 3, false),
                                           new ProportionalPainter(TimeSpan.FromMinutes(19), 9, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(10), 14, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(12), 2, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(13), 8, true)
                                       };
            var sut = new Painters(sequenceOfPainters);
            IPainter result = sut.ThoseAvailable.GetCheapest(squareMeters);
            Assert.That(result, Is.EqualTo(new ProportionalPainter(TimeSpan.FromMinutes(10), 14, true)));
        }

        [Test]
        public void FindFastestPainterAtAll()
        {
            int squareMeters = 10;
            IList<IPainter> sequenceOfPainters = new List<IPainter>
                                       {
                                           new ProportionalPainter(TimeSpan.FromMinutes(11), 5, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(9), 3, false),
                                           new ProportionalPainter(TimeSpan.FromMinutes(19), 9, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(10), 14, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(12), 2, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(13), 8, true)
                                       };
            var sut = new Painters(sequenceOfPainters);
            IPainter result = sut.GetCheapest(squareMeters);
            Assert.That(result, Is.EqualTo(new ProportionalPainter(TimeSpan.FromMinutes(9), 3, false)));
        }
    }
}