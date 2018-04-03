using System;
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

        [Test]
        public void WorkTogether_Returns()
        {
            
        }
    }
}