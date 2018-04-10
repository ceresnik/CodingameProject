using System;
using System.Collections.Generic;
using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.IteratorDemo
{
    [TestFixture]
    public class CompositePainterFactoryTests
    {
        [Test]
        public void CreateCheapestSelector_EstimateDuration()
        {
            IEnumerable<IPainter> sequenceOfPainters = new List<IPainter>
                                                       {
                                                           new ProportionalPainter(TimeSpan.FromMinutes(30), 3, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(10), 2, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(15), 7, false),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(60), 5, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(6), 1, false)
                                                       };
            var cheapestPainter = CompositePainterFactory.CreateCheapestSelector(sequenceOfPainters, 10);
            var result = cheapestPainter.EstimateDuration(10);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(100)));
        }

        [Test]
        public void CreateCheapestSelector_EstimateCosts()
        {
            IEnumerable<IPainter> sequenceOfPainters = new List<IPainter>
                                                       {
                                                           new ProportionalPainter(TimeSpan.FromMinutes(30), 3, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(10), 2, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(15), 7, false),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(60), 5, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(6), 1, false)
                                                       };
            var cheapestPainter = CompositePainterFactory.CreateCheapestSelector(sequenceOfPainters, 10);
            var result = cheapestPainter.EstimateCosts(10);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void CreateFastestSelector_EstimateDuration()
        {
            IEnumerable<IPainter> sequenceOfPainters = new List<IPainter>
                                                       {
                                                           new ProportionalPainter(TimeSpan.FromMinutes(30), 3, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(10), 8, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(15), 7, false),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(60), 5, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(6), 1, false)
                                                       };
            var fastestPainter = CompositePainterFactory.CreateFastestSelector(sequenceOfPainters, 10);
            var result = fastestPainter.EstimateDuration(10);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(100)));
        }

        [Test]
        public void CreateFastestSelector_EstimateCosts()
        {
            IEnumerable<IPainter> sequenceOfPainters = new List<IPainter>
                                                       {
                                                           new ProportionalPainter(TimeSpan.FromMinutes(30), 3, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(10), 8, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(15), 7, false),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(60), 5, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(6), 1, false)
                                                       };
            var fastestPainter = CompositePainterFactory.CreateFastestSelector(sequenceOfPainters, 10);
            var result = fastestPainter.EstimateCosts(10);
            Assert.That(result, Is.EqualTo(13));
        }

        [TestCase(9, 30)]
        [TestCase(18, 60)]
        [TestCase(36, 120)]
        [Test]
        public void CreateGroup_EstimateDuration(int squareMeters, int expected)
        {
            IEnumerable<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                       {
                                                           new ProportionalPainter(TimeSpan.FromMinutes(10), 4, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(5), 8, true)
                                                       };
            var compositePainter = CompositePainterFactory.CreateGroup(sequenceOfPainters);
            TimeSpan result = compositePainter.EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(expected)));
        }

        [TestCase(9, 6)]
        [TestCase(18, 12)]
        [TestCase(36, 24)]
        [Test]
        public void CreateGroup_EstimateCosts(int squareMeters, int expected)
        {
            IEnumerable<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                       {
                                                           new ProportionalPainter(TimeSpan.FromMinutes(10), 4, true),
                                                           new ProportionalPainter(TimeSpan.FromMinutes(5), 8, true)
                                                       };
            var paintingGroup = CompositePainterFactory.CreateGroup(sequenceOfPainters);
            int result = paintingGroup.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CreateGroup_EstimateDuration_Medium()
        {
            int squareMeters = 72;
            IList<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                  {
                                                      new ProportionalPainter(TimeSpan.FromMinutes(6), 3, true),
                                                      new ProportionalPainter(TimeSpan.FromMinutes(15), 8, true)
                                                  };
            var sut = CompositePainterFactory.CreateGroup(sequenceOfPainters);
            TimeSpan result = sut.EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(309)));
        }

        [Test]
        public void CreateGroup_EstimateDuration_Easy()
        {
            int squareMeters = 10;
            IList<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                  {
                                                      new ProportionalPainter(TimeSpan.FromMinutes(6), 3, true),
                                                      new ProportionalPainter(TimeSpan.FromMinutes(12), 8, true)
                                                  };
            var sut = CompositePainterFactory.CreateGroup(sequenceOfPainters);
            TimeSpan result = sut.EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(40)));
        }

        [Test]
        public void CreateGroup_EstimateCosts_Medium()
        {
            int squareMeters = 72;
            IList<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                  {
                                                      new ProportionalPainter(TimeSpan.FromMinutes(6), 8, true),
                                                      new ProportionalPainter(TimeSpan.FromMinutes(15), 3, true)
                                                  };
            var sut = CompositePainterFactory.CreateGroup(sequenceOfPainters);
            int result = sut.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(56));
        }

        [Test]
        public void CreateGroup_EstimateCosts_Easy()
        {
            int squareMeters = 10;
            IList<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                  {
                                                      new ProportionalPainter(TimeSpan.FromMinutes(6), 30, true),
                                                      new ProportionalPainter(TimeSpan.FromMinutes(12), 15, true)
                                                  };
            var sut = CompositePainterFactory.CreateGroup(sequenceOfPainters);
            int result = sut.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void CreateGroup_NoOnePainterIsAvailable_NotAvailable()
        {
            IList<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                            {
                                                                new ProportionalPainter(TimeSpan.FromMinutes(6), 30, false),
                                                                new ProportionalPainter(TimeSpan.FromMinutes(12), 15, false)
                                                            };
            var sut = CompositePainterFactory.CreateGroup(sequenceOfPainters);
            bool result = sut.IsAvailable;
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CreateGroup_OnePainterIsAvailable_Available()
        {
            IList<ProportionalPainter> sequenceOfPainters = new List<ProportionalPainter>
                                                            {
                                                                new ProportionalPainter(TimeSpan.FromMinutes(6), 30, false),
                                                                new ProportionalPainter(TimeSpan.FromMinutes(12), 15, true)
                                                            };
            var sut = CompositePainterFactory.CreateGroup(sequenceOfPainters);
            bool result = sut.IsAvailable;
            Assert.That(result, Is.EqualTo(true));
        }
    }
}