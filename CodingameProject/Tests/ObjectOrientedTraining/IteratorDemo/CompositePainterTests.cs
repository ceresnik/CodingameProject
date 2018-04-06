using System;
using System.Collections.Generic;
using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.IteratorDemo
{
    [TestFixture]
    public class CompositePainterTests
    {
        [Test]
        public void Constructor_CreatesInstance()
        {
            IEnumerable<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                             {
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 4, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(5), 3, false)
                                             };
            var sut = new CompositePainter<IPainter>(sequenceOfPainters, (p, s) => new TimeSpan());
            Assert.That(sut, Is.Not.Null);
        }

        [Test]
        public void EstimateDurationFunc_IsCalled()
        {
            IEnumerable<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                                  {
                                                                      new ProportionalPainter(TimeSpan.FromMinutes(10), 4, true),
                                                                      new ProportionalPainter(TimeSpan.FromMinutes(5), 3, false)
                                                                  };
            bool functionWasCalled = false;
            var sut = new CompositePainter<IPainter>(sequenceOfPainters, (p, s) =>
                                                                         {
                                                                             functionWasCalled = true;
                                                                             return new TimeSpan();
                                                                         });
            Assert.That(functionWasCalled, Is.False);
            sut.EstimateDuration(10);
            Assert.That(functionWasCalled, Is.True);
        }
    }
}