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
            var sut = new WordSplitter();
            var result = sut.SplitToParts(new Word("abcdefaabbccddeedff"), 4).Count;
            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void CountOfUniqueLettersIsZero_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentException> (() =>
            {
                var sut = new WordSplitter();
                sut.SplitToParts(new Word("abc"), 0);
            });
        }
    }
}