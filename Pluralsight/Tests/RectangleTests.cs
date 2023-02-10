using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pluralsight.Source;

namespace Pluralsight.Tests
{
    [TestFixture]
    class RectangleTests
    {
        [Test]
        public void Test_PositiveLength()
        {
            var rectangle = new Rectangle();
            rectangle.Length = 10;
            Assert.That(rectangle.Length, Is.EqualTo(10), "Lenght of rectangle not as expected.");
        }

        [Test]
        public void Test_NegativeLength_ThrowsException()
        {
            IList<int> a = new List<int>();
            a.Add(2);
            var b = a.Distinct();
            var rectangle = new Rectangle();
            Assert.Throws<ArgumentException>(() => rectangle.Length = -1);
        }

        [Test]
        public void Test_ZeroLength_ThrowsException()
        {
            var rectangle = new Rectangle();
            Assert.Throws<ArgumentException>(() => rectangle.Length = 0);
        }
    }
}
