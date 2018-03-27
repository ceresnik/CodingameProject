using System;
using System.Collections.Generic;
using System.Linq;
using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.IteratorDemo
{
    public class PainterClientTests
    {
        [Test]
        public void Test_FindCheapestPainter()
        {
            IEnumerable<IPainter> painters = new List<IPainter>
                                             {
                                                 new Painter(2, 3, true),
                                                 new Painter(5, 2, true),
                                                 new Painter(4, 7, false),
                                                 new Painter(1, 5, true),
                                                 new Painter(9, 3, false)
                                             };
            var sut = new PainterClient();
            var cheapestPainter = sut.FindCheapestPainter(10, painters);
            Assert.That(cheapestPainter, Is.EqualTo(new Painter(5, 2, true)));
        }

        [Ignore]
        [Test]
        public void Test_FindCheapestPainter_NoPainter_Null()
        {
            var sut = new PainterClient();
            var result = sut.FindCheapestPainter(10, new List<IPainter>());
            Assert.That(result, Is.EqualTo(null));
        }

        [Ignore]
        [Test]
        public void Test_FindCheapestPainter_NoneIsAvailable_Null()
        {
            IEnumerable<IPainter> painters = new List<IPainter>
                                             {
                                                 new Painter(2, 3, false),
                                                 new Painter(5, 2, false),
                                                 new Painter(4, 7, false),
                                                 new Painter(1, 5, false),
                                                 new Painter(9, 3, false)
                                             };
            var sut = new PainterClient();
            var cheapestPainter = sut.FindCheapestPainter(10, painters);
            Assert.That(cheapestPainter, Is.EqualTo(null));
        }

        [Test]
        public void Test_FindCheapest_TestTuple()
        {
            int squareMeters = 10;
            IList<IPainter> painters = new List<IPainter>
                                       {
                                           new Painter(8, 3, true),
                                           new Painter(4, 14, true),
                                           new Painter(4, 5, true),
                                           new Painter(4, 1, false),
                                           new Painter(4, 2, true),
                                           new Painter(4, 8, true)
                                       };
            var result = painters
                .Where(painter => painter.IsAvailable)
                .Select(painter => new Tuple<IPainter, int>(painter, painter.EstimateCosts(squareMeters)))
                .Aggregate((best, current) => best.Item2 > current.Item2 ? current : best).Item1;
            Assert.That(result, Is.EqualTo(new Painter(8, 3, true)));
        }

        [Test]
        public void Test_FindFastestPainter()
        {
            int squareMeters = 10;
            IList<IPainter> painters = new List<IPainter>
                                       {
                                           new Painter(8, 3, false),
                                           new Painter(7, 14, true),
                                           new Painter(4, 5, true),
                                           new Painter(4, 9, true),
                                           new Painter(4, 2, true),
                                           new Painter(4, 8, true)
                                       };
            PainterClient sut = new PainterClient();
            IPainter result = sut.FindFastestPainter(squareMeters, painters);
            Assert.That(result, Is.EqualTo(new Painter(7, 14, true)));
        }

        [Test]
        public void Test_WorkTogether_Duration()
        {
            int squareMeters = 72;
            IList<IPainter> painters = new List<IPainter>
                                       {
                                           new Painter(8, 3, true),
                                           new Painter(4, 8, true)
                                       };
            PainterClient sut = new PainterClient();
            TimeSpan result = sut.WorkTogether(squareMeters, painters).EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(new TimeSpan(0, 6, 0, 0)));
        }

        [Test]
        public void Test_WorkTogether_Costs()
        {
            int squareMeters = 72;
            IList<IPainter> painters = new List<IPainter>
                                       {
                                           new Painter(8, 3, true),
                                           new Painter(4, 8, true)
                                       };
            PainterClient sut = new PainterClient();
            int result = sut.WorkTogether(squareMeters, painters).EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(66));
        }
    }
}