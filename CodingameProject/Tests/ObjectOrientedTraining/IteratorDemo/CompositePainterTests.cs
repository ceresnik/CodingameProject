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
            var sut = new CompositePainter<IPainter>(sequenceOfPainters, (p, s) => new TimeSpan(), (p, i) => 0);
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
            bool estimateDurationFunctionWasCalled = false;
            var sut = new CompositePainter<IPainter>(sequenceOfPainters, (p, s) =>
                                                                         {
                                                                             estimateDurationFunctionWasCalled = true;
                                                                             return new TimeSpan();
                                                                         }, 
                                                                         (p, i) => 0);
            Assert.That(estimateDurationFunctionWasCalled, Is.False);
            sut.EstimateDuration(10);
            Assert.That(estimateDurationFunctionWasCalled, Is.True);
        }

        [Test]
        public void EstimateCostsFunc_IsCalled()
        {
            IEnumerable<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                                  {
                                                                      new ProportionalPainter(TimeSpan.FromMinutes(10), 4, true),
                                                                      new ProportionalPainter(TimeSpan.FromMinutes(5), 3, false)
                                                                  };
            bool estimateCostsFunctionWasCalled = false;
            var sut = new CompositePainter<IPainter>(sequenceOfPainters, 
                (p, s) => new TimeSpan(),
                (p, i) =>
                {
                    estimateCostsFunctionWasCalled = true;
                    return 0;
                });
            Assert.That(estimateCostsFunctionWasCalled, Is.False);
            sut.EstimateCosts(10);
            Assert.That(estimateCostsFunctionWasCalled, Is.True);
        }
    }
}