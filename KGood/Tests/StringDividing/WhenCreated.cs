using System;
using KGood.Source.StringDividing;
using NUnit.Framework;

namespace KGood.Tests.StringDividing
{
    [TestFixture]
    internal class WhenCreated
    {
        private string inputString;
        private StringDivider stringDivider;
        private int countOfDifferentLetters;

        [SetUp]
        public void SetUp()
        {
            inputString = "aabbcdd";
            countOfDifferentLetters = 2;
            stringDivider = new StringDivider(inputString, countOfDifferentLetters);
        }

        [Test]
        public void StringToDivide_IsNotNull()
        {
            Assert.That(stringDivider.Word, Is.Not.Null);
        }

        [Test]
        public void Cardinality_EqualsGivenCardinality()
        {
            Assert.That(stringDivider.Cardinality, Is.EqualTo(countOfDifferentLetters));
        }

        [Test]
        public void StringToDivide_IsRequired()
        {
            Assert.Throws<ArgumentException>(() => new StringDivider(null, 3));
        }

        [Test]
        public void AndCardinalityIsGreaterThanCountOfDistinctLetters_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new StringDivider("aaaaabb", 3));
        }
    }
}