using System;
using System.Collections.Generic;
using System.Linq;
using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.IteratorDemo
{
    public class PainterServiceTests
    {
        [Test]
        public void FindCheapestPainter()
        {
            IEnumerable<IPainter> painters = new List<IPainter>
                                             {
                                                 new ProportionalPainter(2, 3, true),
                                                 new ProportionalPainter(5, 2, true),
                                                 new ProportionalPainter(4, 7, false),
                                                 new ProportionalPainter(1, 5, true),
                                                 new ProportionalPainter(9, 3, false)
                                             };
            var sut = new PainterService();
            var cheapestPainter = sut.FindCheapestPainter(10, painters);
            Assert.That(cheapestPainter, Is.EqualTo(new ProportionalPainter(5, 2, true)));
        }

        [Ignore]
        [Test]
        public void FindCheapestPainter_NoPainter_Null()
        {
            var sut = new PainterService();
            var result = sut.FindCheapestPainter(10, new List<IPainter>());
            Assert.That(result, Is.EqualTo(null));
        }

        [Ignore]
        [Test]
        public void FindCheapestPainter_NoneIsAvailable_Null()
        {
            IEnumerable<IPainter> painters = new List<IPainter>
                                             {
                                                 new ProportionalPainter(2, 3, false),
                                                 new ProportionalPainter(5, 2, false),
                                                 new ProportionalPainter(4, 7, false),
                                                 new ProportionalPainter(1, 5, false),
                                                 new ProportionalPainter(9, 3, false)
                                             };
            var sut = new PainterService();
            var cheapestPainter = sut.FindCheapestPainter(10, painters);
            Assert.That(cheapestPainter, Is.EqualTo(null));
        }

        [Test]
        public void FindCheapest_TestTuple()
        {
            int squareMeters = 10;
            IList<IPainter> painters = new List<IPainter>
                                       {
                                           new ProportionalPainter(8, 3, true),
                                           new ProportionalPainter(4, 14, true),
                                           new ProportionalPainter(4, 5, true),
                                           new ProportionalPainter(4, 1, false),
                                           new ProportionalPainter(4, 2, true),
                                           new ProportionalPainter(4, 8, true)
                                       };
            var result = painters
                .Where(painter => painter.IsAvailable)
                .Select(painter => new Tuple<IPainter, int>(painter, painter.EstimateCosts(squareMeters)))
                .Aggregate((best, current) => best.Item2 > current.Item2 ? current : best).Item1;
            Assert.That(result, Is.EqualTo(new ProportionalPainter(8, 3, true)));
        }

        [Test]
        public void FindFastestPainter()
        {
            int squareMeters = 10;
            IList<IPainter> painters = new List<IPainter>
                                       {
                                           new ProportionalPainter(8, 3, false),
                                           new ProportionalPainter(7, 14, true),
                                           new ProportionalPainter(4, 5, true),
                                           new ProportionalPainter(4, 9, true),
                                           new ProportionalPainter(4, 2, true),
                                           new ProportionalPainter(4, 8, true)
                                       };
            PainterService sut = new PainterService();
            IPainter result = sut.FindFastestPainter(squareMeters, painters);
            Assert.That(result, Is.EqualTo(new ProportionalPainter(7, 14, true)));
        }

        [Test]
        public void WorkTogether_Duration()
        {
            int squareMeters = 72;
            IList<ProportionalPainter> painters = new List<ProportionalPainter>
                                       {
                                           new ProportionalPainter(8, 3, true),
                                           new ProportionalPainter(4, 8, true)
                                       };
            PainterService sut = new PainterService();
            TimeSpan result = sut.WorkTogether(squareMeters, painters).EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(new TimeSpan(0, 6, 0, 0)));
        }

        [Test]
        public void WorkTogether_Costs()
        {
            int squareMeters = 72;
            IList<ProportionalPainter> painters = new List<ProportionalPainter>
                                       {
                                           new ProportionalPainter(8, 3, true),
                                           new ProportionalPainter(4, 8, true)
                                       };
            PainterService sut = new PainterService();
            int result = sut.WorkTogether(squareMeters, painters).EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(66));
        }
    }
}