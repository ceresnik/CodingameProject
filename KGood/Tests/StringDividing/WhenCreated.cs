using System;
using KGood.Source.StringDividing;
using NUnit.Framework;

namespace KGood.Tests.StringDividing
{
    [TestFixture]
    internal class WhenCreated
    {
        [Test]
        public void StringToDivideIsNull_NoException()
        {
            new StringDivider(null, 0);
        }

        [Test]
        public void AndCardinalityIsGreaterThanCountOfDistinctLetters_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new StringDivider("aaaaabb", 3));
        }
    }
}