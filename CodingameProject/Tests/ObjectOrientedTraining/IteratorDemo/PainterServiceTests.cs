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
        public void FindCheapestAvailablePainter()
        {
            IEnumerable<IPainter> painters = new List<IPainter>
                                             {
                                                 new ProportionalPainter(TimeSpan.FromMinutes(30), 3, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 2, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(15), 7, false),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(60), 5, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(6), 1, false)
                                             };
            var sut = new PainterService();
            var cheapestPainter = sut.FindCheapestAvailablePainter(10, new Painters(painters));
            //var cheapestPainter = sut.FindCheapestPainter(10, new AvailablePainters(painters));
            Assert.That(cheapestPainter, Is.EqualTo(new ProportionalPainter(TimeSpan.FromMinutes(10), 2, true)));
        }

        [Test]
        public void FindCheapestPainterAtAll()
        {
            IEnumerable<IPainter> painters = new List<IPainter>
                                             {
                                                 new ProportionalPainter(TimeSpan.FromMinutes(30), 3, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 2, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(15), 7, false),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(60), 5, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(6), 1, false)
                                             };
            var sut = new PainterService();
            var cheapestPainter = sut.FindCheapestPainter(10, new Painters(painters));
            Assert.That(cheapestPainter, Is.EqualTo(new ProportionalPainter(TimeSpan.FromMinutes(6), 1, false)));
        }

        [Ignore]
        [Test]
        public void FindCheapestPainter_NoPainter_Null()
        {
            var sut = new PainterService();
            var result = sut.FindCheapestAvailablePainter(10, new Painters(new List<IPainter>()));
            Assert.That(result, Is.EqualTo(null));
        }

        [Ignore]
        [Test]
        public void FindCheapestPainter_NoneIsAvailable_Null()
        {
            IEnumerable<IPainter> painters = new List<IPainter>
                                             {
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 3, false),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 2, false),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 7, false),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 5, false),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 3, false)
                                             };
            var sut = new PainterService();
            var cheapestPainter = sut.FindCheapestAvailablePainter(10, new Painters(painters));
            Assert.That(cheapestPainter, Is.EqualTo(null));
        }

        [Test]
        public void FindCheapestAvailablePainter_TestTuple()
        {
            int squareMeters = 10;
            IList<IPainter> painters = new List<IPainter>
                                       {
                                           new ProportionalPainter(TimeSpan.FromMinutes(6), 3, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(15), 14, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(18), 5, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(7), 1, false),
                                           new ProportionalPainter(TimeSpan.FromMinutes(9), 2, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(8), 8, true)
                                       };
            var result = painters
                .Where(painter => painter.IsAvailable)
                .Select(painter => new Tuple<IPainter, int>(painter, painter.EstimateCosts(squareMeters)))
                .Aggregate((best, current) => best.Item2 > current.Item2 ? current : best).Item1;
            Assert.That(result, Is.EqualTo(new ProportionalPainter(TimeSpan.FromMinutes(6), 3, true)));
        }

        [Test]
        public void FindFastestAvailablePainter()
        {
            int squareMeters = 10;
            IList<IPainter> painters = new List<IPainter>
                                       {
                                           new ProportionalPainter(TimeSpan.FromMinutes(11), 5, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(9), 3, false),
                                           new ProportionalPainter(TimeSpan.FromMinutes(19), 9, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(10), 14, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(12), 2, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(13), 8, true)
                                       };
            PainterService sut = new PainterService();
            IPainter result = sut.FindFastestAvailablePainter(squareMeters, new Painters(painters));
            Assert.That(result, Is.EqualTo(new ProportionalPainter(TimeSpan.FromMinutes(10), 14, true)));
        }

        [Test]
        public void FindFastestPainterAtAll()
        {
            int squareMeters = 10;
            IList<IPainter> painters = new List<IPainter>
                                       {
                                           new ProportionalPainter(TimeSpan.FromMinutes(11), 5, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(9), 3, false),
                                           new ProportionalPainter(TimeSpan.FromMinutes(19), 9, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(10), 14, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(12), 2, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(13), 8, true)
                                       };
            PainterService sut = new PainterService();
            IPainter result = sut.FindFastestPainter(squareMeters, new Painters(painters));
            Assert.That(result, Is.EqualTo(new ProportionalPainter(TimeSpan.FromMinutes(9), 3, false)));
        }

        [Test]
        public void WorkTogether_Duration()
        {
            int squareMeters = 72;
            IList<ProportionalPainter> painters = new List<ProportionalPainter>
                                       {
                                           new ProportionalPainter(TimeSpan.FromMinutes(6), 3, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(15), 8, true)
                                       };
            PainterService sut = new PainterService();
            TimeSpan result = sut.WorkTogether(squareMeters, painters).EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(310)));
        }

        [Test]
        public void WorkTogether_DurationEasy()
        {
            int squareMeters = 10;
            IList<ProportionalPainter> painters = new List<ProportionalPainter>
                                       {
                                           new ProportionalPainter(TimeSpan.FromMinutes(6), 3, true),
                                           new ProportionalPainter(TimeSpan.FromMinutes(12), 8, true)
                                       };
            PainterService sut = new PainterService();
            TimeSpan result = sut.WorkTogether(squareMeters, painters).EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(40)));
        }

        [Test]
        public void WorkTogether_Costs()
        {
            int squareMeters = 72;
            IList<ProportionalPainter> painters = new List<ProportionalPainter>
                                                  {
                                                      new ProportionalPainter(TimeSpan.FromMinutes(6), 8, true),
                                                      new ProportionalPainter(TimeSpan.FromMinutes(15), 3, true)
                                                  };
            PainterService sut = new PainterService();
            int result = sut.WorkTogether(squareMeters, painters).EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(51));
        }

        [Test]
        public void WorkTogether_CostsEasy()
        {
            int squareMeters = 10;
            IList<ProportionalPainter> painters = new List<ProportionalPainter>
                                                  {
                                                      new ProportionalPainter(TimeSpan.FromMinutes(6), 30, true),
                                                      new ProportionalPainter(TimeSpan.FromMinutes(12), 15, true)
                                                  };
            PainterService sut = new PainterService();
            int result = sut.WorkTogether(squareMeters, painters).EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(30));
        }
    }
}