using System;
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
    }
}
