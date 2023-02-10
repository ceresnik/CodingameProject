using System;
using NUnit.Framework;
using Pluralsight.Source;

namespace Pluralsight.Tests
{
    [TestFixture]
    class FrameTests
    {
        [Test]
        public void Test_PositiveLength()
        {
            var frame = new Frame
            {
                Length = 10
            };
            Assert.That(frame.Length, Is.EqualTo(10), "Lenght of frame not as expected.");
        }

        [Test]
        public void Test_PositiveWidth()
        {
            var frame = new Frame
            {
                Width = 20
            };
            Assert.That(frame.Width, Is.EqualTo(20), "Width of frame not as expected.");
        }

        [Test]
        public void Test_NegativeLength_ThrowsException()
        {
            var frame = new Frame();
            Assert.Throws<ArgumentException>(() => frame.Length = -1);
        }

        [Test]
        public void Test_NegativeWidth_ThrowsException()
        {
            var frame = new Frame();
            Assert.Throws<ArgumentException>(() => frame.Width = -1);
        }

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
    }
}
