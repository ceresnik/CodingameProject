using System;
using KGood.Source.StringDividing;
using NUnit.Framework;

namespace KGood.Tests.StringDividing
{
    internal class BeginningOfGroupOfSameLettersSignalizerTests
    {
        [Test]
        public void Constructor_WordIsNull_NoExceptionIsThrown()
        {
            new BeginningOfGroupOfSameLettersSignalizer((string)null);
        }

        [Test]
        public void Constructor_WordIsEmpty_NoExceptionIsThrown()
        {
            new BeginningOfGroupOfSameLettersSignalizer("");
        }

        [Test]
        public void Signalize_FirstLetterOfWord_True()
        {
            string word = "aax";
            var sut = new BeginningOfGroupOfSameLettersSignalizer(word);
            bool result = sut.Signalize(0);
            Assert.That(result, Is.True);
        }

        [Test]
        public void Signalize_IndexIsEqualAsLength_ExceptionIsThrown()
        {
            string word = "aax";
            var sut = new BeginningOfGroupOfSameLettersSignalizer(word);
            Assert.Throws<ArgumentException>(() => sut.Signalize(3));
        }

        [Test]
        public void Signalize_IndexIsGreaterThanLength_ExceptionIsThrown()
        {
            string word = "aax";
            var sut = new BeginningOfGroupOfSameLettersSignalizer(word);
            Assert.Throws<ArgumentException>(() => sut.Signalize(4));
        }

        [Test]
        public void Signalize_LastLetterOfGroup_False()
        {
            string word = "aax";
            var sut = new BeginningOfGroupOfSameLettersSignalizer(word);
            bool result = sut.Signalize(1);
            Assert.That(result, Is.False);
        }

        [Test]
        public void Signalize_FirstLetterOfGroup_True()
        {
            string word = "aabx";
            var sut = new BeginningOfGroupOfSameLettersSignalizer(word);
            bool result = sut.Signalize(2);
            Assert.That(result, Is.True);
        }
    }
}