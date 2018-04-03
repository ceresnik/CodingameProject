using System;
using System.Collections.Generic;
using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.IteratorDemo
{
    public class PainterServiceTests
    {

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
            Assert.That(result, Is.EqualTo(57));
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