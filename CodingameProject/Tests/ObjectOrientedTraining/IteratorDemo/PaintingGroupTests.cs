﻿using System;
using System.Collections.Generic;
using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.IteratorDemo
{
    [TestFixture]
    public class PaintingGroupTests
    {
        [Test]
        public void Constructor_CreatesInstance()
        {
            IEnumerable<IPainter> painters = new List<IPainter>
                                             {
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 4, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(5), 3, false)
                                             };
            PaintingGroup sut = new PaintingGroup(painters);
            Assert.That(sut, Is.Not.Null);
        }

        [TestCase(9, 30)]
        [TestCase(18, 60)]
        [TestCase(36, 120)]
        [Test]
        public void EstimateDuration_Easy(int squareMeters, int expected)
        {
            IEnumerable<IPainter> painters = new List<IPainter>
                                             {
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 4, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(5), 8, true)
                                             };
            PaintingGroup sut = new PaintingGroup(painters);
            TimeSpan result = sut.EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(expected)));
        }

        [TestCase(9, 6)]
        [TestCase(18, 12)]
        [TestCase(36, 24)]
        [Test]
        public void EstimateCosts_Easy(int squareMeters, int expected)
        {
            IEnumerable<IPainter> painters = new List<IPainter>
                                             {
                                                 new ProportionalPainter(TimeSpan.FromMinutes(10), 4, true),
                                                 new ProportionalPainter(TimeSpan.FromMinutes(5), 8, true)
                                             };
            PaintingGroup sut = new PaintingGroup(painters);
            int result = sut.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void EstimateDuration_Medium()
        {
            int squareMeters = 72;
            IList<IPainter> sequenceOfPainters = new List<IPainter>
                                                  {
                                                      new ProportionalPainter(TimeSpan.FromMinutes(6), 3, true),
                                                      new ProportionalPainter(TimeSpan.FromMinutes(15), 8, true)
                                                  };
            var sut = new PaintingGroup(sequenceOfPainters);
            TimeSpan result = sut.EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(309)));
        }

        [Test]
        public void EstimateDuration_Simple()
        {
            int squareMeters = 10;
            IList<IPainter> sequenceOfPainters = new List<IPainter>
                                                  {
                                                      new ProportionalPainter(TimeSpan.FromMinutes(6), 3, true),
                                                      new ProportionalPainter(TimeSpan.FromMinutes(12), 8, true)
                                                  };
            var sut = new PaintingGroup(sequenceOfPainters);
            TimeSpan result = sut.EstimateDuration(squareMeters);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(40)));
        }

        [Test]
        public void EstimateCosts_Medium()
        {
            int squareMeters = 72;
            IList<IPainter> sequenceOfPainters = new List<IPainter>
                                                  {
                                                      new ProportionalPainter(TimeSpan.FromMinutes(6), 8, true),
                                                      new ProportionalPainter(TimeSpan.FromMinutes(15), 3, true)
                                                  };
            var sut = new PaintingGroup(sequenceOfPainters);
            int result = sut.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(56));
        }

        [Test]
        public void EstimateCosts_Easy()
        {
            int squareMeters = 10;
            IList<IPainter> sequenceOfPainters = new List<IPainter>
                                                  {
                                                      new ProportionalPainter(TimeSpan.FromMinutes(6), 30, true),
                                                      new ProportionalPainter(TimeSpan.FromMinutes(12), 15, true)
                                                  };
            var sut = new PaintingGroup(sequenceOfPainters);
            int result = sut.EstimateCosts(squareMeters);
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void NotAvailable_WhenNoOnePainterIsAvailable()
        {
            IList<IPainter> sequenceOfPainters = new List<IPainter>
                                                            {
                                                                new ProportionalPainter(TimeSpan.FromMinutes(6), 30, false),
                                                                new ProportionalPainter(TimeSpan.FromMinutes(12), 15, false)
                                                            };
            var sut = new PaintingGroup(sequenceOfPainters);
            bool result = sut.IsAvailable;
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void Available_WhenOnePainterIsAvailable()
        {
            IList<IPainter> sequenceOfPainters = new List<IPainter>
                                                            {
                                                                new ProportionalPainter(TimeSpan.FromMinutes(6), 30, false),
                                                                new ProportionalPainter(TimeSpan.FromMinutes(12), 15, true)
                                                            };
            var sut = new PaintingGroup(sequenceOfPainters);
            bool result = sut.IsAvailable;
            Assert.That(result, Is.EqualTo(true));
        }
    }
}