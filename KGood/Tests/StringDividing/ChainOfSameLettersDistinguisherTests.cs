﻿using System;
using KGood.Source.StringDividing;
using NUnit.Framework;

namespace KGood.Tests.StringDividing
{
    internal class ChainOfSameLettersDistinguisherTests
    {
        [Test]
        public void Constructor_WordIsNull_NoExceptionIsThrown()
        {
            new ChainOfSameLettersDistinguisher((string)null);
        }

        [Test]
        public void Constructor_WordIsEmpty_NoExceptionIsThrown()
        {
            new ChainOfSameLettersDistinguisher("");
        }

        [Test]
        public void LetterChanged_FirstLetterOfWord_True()
        {
            string word = "aax";
            var sut = new ChainOfSameLettersDistinguisher(word);
            bool result = sut.LetterChanged(0);
            Assert.That(result, Is.True);
        }

        [Test]
        public void LetterChanged_IndexIsEqualAsLength_ExceptionIsThrown()
        {
            string word = "aax";
            var sut = new ChainOfSameLettersDistinguisher(word);
            Assert.Throws<ArgumentException>(() => sut.LetterChanged(3));
        }

        [Test]
        public void LetterChanged_IndexIsGreaterThanLength_ExceptionIsThrown()
        {
            string word = "aax";
            var sut = new ChainOfSameLettersDistinguisher(word);
            Assert.Throws<ArgumentException>(() => sut.LetterChanged(4));
        }

        [Test]
        public void LetterChanged_LastLetterOfGroup_False()
        {
            string word = "aax";
            var sut = new ChainOfSameLettersDistinguisher(word);
            bool result = sut.LetterChanged(1);
            Assert.That(result, Is.False);
        }

        [Test]
        public void LetterChanged_FirstLetterOfGroup_True()
        {
            string word = "aabx";
            var sut = new ChainOfSameLettersDistinguisher(word);
            bool result = sut.LetterChanged(2);
            Assert.That(result, Is.True);
        }
    }
}