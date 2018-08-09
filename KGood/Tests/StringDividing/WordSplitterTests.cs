using System;
using KGood.Source.StringDividing;
using NUnit.Framework;

namespace KGood.Tests.StringDividing
{
    [TestFixture]
    public class WordSplitterTests
    {
        [Test]
        public void NoEmptyWordPartsInResult()
        {
            var sut = new WordSplitter(new WordRepresentation("abcdefaabbccddeedff"), 4);
            var result = sut.SplitToParts().Count;
            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void CountOfUniqueLettersIsZero_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentException> (() => new WordSplitter(new WordRepresentation("abc"), 0));
        }
    }
}