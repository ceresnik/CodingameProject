using System.Collections.Generic;
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

        [Test]
        public void Test_FindCheapestPainter_NoPainter_Null()
        {
            IEnumerable<IPainter> painters = new List<IPainter>();
            var sut = new PainterClient();
            var result = sut.FindCheapestPainter(10, painters);
            Assert.That(result, Is.EqualTo(null));
        }
    }
}