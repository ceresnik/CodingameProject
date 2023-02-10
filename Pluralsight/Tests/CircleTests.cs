using System;
using System.Drawing;
using NUnit.Framework;

namespace Pluralsight.Tests
{
    class CircleTests
    {
        [Test]
        public void Circle_NegativeRadius_ThrowsException()
        {
            var circle = new Circle();
            Assert.Throws<ArgumentException>(() => circle.Radius = -1.2);
        }

        [Test]
        public void Circle_ZeroRadius_ThrowsException()
        {
            var circle = new Circle();
            Assert.Throws<ArgumentException>(() => circle.Radius = 0);
        }

        [Test]
        public void Circle_HasCentre()
        {
            var circle = new Circle();
            var coordinatesOfCentre = new Point(2, 5);
            circle.Centre = coordinatesOfCentre;
            Assert.That(circle.Centre, Is.EqualTo(coordinatesOfCentre), "Coordinates of Centre of the circle not as expected.");
        }
    }
}