using System;
using System.Drawing;
using NUnit.Framework;
using Pluralsight.Source;

namespace Pluralsight.Tests
{
    [TestFixture]
    class FrameTests
    {
        [Test]
        public void Test_ZeroLength_ThrowsException()
        {
            var frame = new Frame();
            Assert.Throws<ArgumentException>(() => frame.Length = 0);
        }

        [Test]
        public void Test_ZeroWidth_ThrowsException()
        {
            var frame = new Frame();
            Assert.Throws<ArgumentException>(() => frame.Width = 0);
        }

        [Test]
        public void Test_NegativeLength_ThrowsException()
        {
            var frame = new Frame();
            Assert.Throws<ArgumentException>(() => frame.Length = -11.9);
        }

        [Test]
        public void Test_NegativeWidth_ThrowsException()
        {
            var frame = new Frame();
            Assert.Throws<ArgumentException>(() => frame.Width = -1.1);
        }

        [Test]
        public void Test_SmallestPositiveLength()
        {
            var frame = CreateSutWithLength(double.Epsilon);
            Assert.That(frame.Length, Is.EqualTo(double.Epsilon), "Length of frame not as expected.");
        }

        [Test]
        public void Test_SmallestPositiveWidth()
        {
            var frame = CreateSutWithWidth(double.Epsilon);
            Assert.That(frame.Width, Is.EqualTo(double.Epsilon), "Width of frame not as expected.");
        }

        [Test]
        public void Test_PositiveLength()
        {
            var frame = CreateSutWithLength(10.4);
            Assert.That(frame.Length, Is.EqualTo(10.4), "Length of frame not as expected.");
        }

        [Test]
        public void Test_PositiveWidth()
        {
            var frame = CreateSutWithWidth(20.7);
            Assert.That(frame.Width, Is.EqualTo(20.7), "Width of frame not as expected.");
        }

        [Test]
        public void TryAddCircle_CircleCentreIsInsideRadiusIsSmall_True()
        {
            var circle = CreateCircle(2, 2, 1);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.True);
        }

        [TestCase(2, 2, 10)]
        [TestCase(1, 3, 2)]
        [TestCase(3, 4, 2)]
        [TestCase(3, 1, 2)]
        public void TryAddCircle_CircleCentreIsInsideRadiusIsLarge_False(int circleXCoordinate, int circleYCoordinate, int radius)
        {
            var circle = CreateCircle(circleXCoordinate, circleYCoordinate, radius);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.False);
        }

        [TestCase(-2)]
        [TestCase(6)]
        public void TryAddCircle_CircleCentreXIsOutside_False(int circleXCoordinate)
        {
            var circle = CreateCircle(circleXCoordinate, 2, 1);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.False);
        }

        [TestCase(-2)]
        [TestCase(6)]
        public void TryAddCircle_CircleCentreYIsOutside_False(int circleYCoordinate)
        {
            var circle = CreateCircle(2, circleYCoordinate, 1);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.False);
        }

        [TestCase(-2, -2)]
        [TestCase(-2, 6)]
        [TestCase(6, 6)]
        [TestCase(6, -2)]
        public void TryAddCircle_CircleCentreXAndYIsOutside_False(int circleXCoordinate, int circleYCoordinate)
        {
            var circle = CreateCircle(circleXCoordinate, circleYCoordinate, 1);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TryAddCircle_CircleTouchesUpperEdge_True()
        {
            var circle = CreateCircle(2, 4, 1);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.True);
        }

        [Test]
        public void TryAddCircle_CircleCrossesUpperEdge_False()
        {
            var circle = CreateCircle(2, 4.1, 1);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TryAddCircle_CircleTouchesRightEdge_True()
        {
            var circle = CreateCircle(4, 2, 1);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.True);
        }

        [Test]
        public void TryAddCircle_CircleCrossesRightEdge_False()
        {
            var circle = CreateCircle(4.1, 2, 1);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TryAddCircle_CircleTouchesLowerEdge_True()
        {
            var circle = CreateCircle(2, 1, 1);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.True);
        }

        [Test]
        public void TryAddCircle_CircleCrossesLowerEdge_False()
        {
            var circle = CreateCircle(2, 0.9, 1);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TryAddCircle_CircleTouchesLeftEdge_True()
        {
            var circle = CreateCircle(1, 2, 1);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.True);
        }

        [Test]
        public void TryAddCircle_CircleCrossesLeftEdge_False()
        {
            var circle = CreateCircle(0.9, 2, 1);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TryAddCircle_CircleCompletelyOutsideTheFrame_False()
        {
            var circle = CreateCircle(10, 10, 2);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TryAddCircle_CircleOutsideTheFrameButCrossesTheFrame_False()
        {
            var circle = CreateCircle(6, 6, 2);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TryAddCircle_CircleInsideTheFrameButCrossesAllEdges_False()
        {
            var circle = CreateCircle(2, 2, 10);
            var frame = CreateFrame(5, 5);
            bool result = frame.TryAddCircle(circle);
            Assert.That(result, Is.False);
        }

        private static Frame CreateSutWithWidth(double width)
        {
            var frame = new Frame
            {
                Width = width
            };
            return frame;
        }

        private static Frame CreateSutWithLength(double length)
        {
            var frame = new Frame
            {
                Length = length
            };
            return frame;
        }

        private static Frame CreateFrame(int length, int width)
        {
            return new Frame
            {
                Length = length,
                Width = width
            };
        }

        private static Circle CreateCircle(double x, double y, int radius)
        {
            return new Circle
            {
                X = x,
                Y = y,
                Radius = radius
            };
        }
    }
}
