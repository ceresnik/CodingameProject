using System;
using NUnit.Framework;
using Pluralsight.Source;

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
        public void Circle_HasCentreX()
        {
            var circle = new Circle();
            circle.X = 2;
            Assert.That(circle.X, Is.EqualTo(2), "X coordinate of Centre of the circle not as expected.");
        }

        [Test]
        public void Circle_HasCentreY()
        {
            var circle = new Circle();
            circle.Y = 5;
            Assert.That(circle.Y, Is.EqualTo(5), "Y coordinate of Centre of the circle not as expected.");
        }
    }
}