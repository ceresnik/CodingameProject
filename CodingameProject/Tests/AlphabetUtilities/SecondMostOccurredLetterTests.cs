/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, 2022. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using CodingameProject.Source.AlphabetUtilities;
using NUnit.Framework;

namespace CodingameProject.Tests.AlphabetUtilities
{
    class SecondMostOccurredLetterTests
    {
        [Test]
        public void EmptyWordReturnsMinusOne()
        {
            Assert.AreEqual(SecondMostOccurredCharacter.Get(string.Empty), -1);
        }

        [Test]
        public void WordWhichIsNullReturnsMinusOne()
        {
            Assert.AreEqual(SecondMostOccurredCharacter.Get(null), -1);
        }

        [TestCase("a", -1)]
        [TestCase("a", -1)]
        [TestCase("1", -1)]
        [Test]
        public void WordWithOneCharacterReturnsMinusOne(string input, int expected)
        {
            var result = SecondMostOccurredCharacter.Get(input);
            Assert.AreEqual(expected, result);
        }

        [TestCase("aa", -1)]
        [TestCase("aa", -1)]
        [TestCase("11", -1)]
        [Test]
        public void WordWithTwoSameCharactersReturnsMinusOne(string input, int expected)
        {
            var result = SecondMostOccurredCharacter.Get(input);
            Assert.AreEqual(expected, result);
        }

        [TestCase("ab", -1)]
        [TestCase("ddff", -1)]
        [TestCase("1111122222", -1)]
        [TestCase("aaaBBBccc", -1)]
        [TestCase("ipOHLeTtdfDcJhAKgbaobeOHoJLKcApTidDgtfhadocJDtLHfbeaigpOhTAKdKhoDaiAbHegpJtOfLcTiTbpOacKtofdLDhHJgAe", -1)]
        [Test]
        public void WordWithDifferentCharactersWithSameCountReturnsMinusOne(string input, int expected)
        {
            var result = SecondMostOccurredCharacter.Get(input);
            Assert.AreEqual(expected, result);
        }

        [TestCase("aaabbc", 2)]
        [TestCase("abbccc", 2)]
        [Test]
        public void WordWithThreeCharactersEachDifferentCountReturnsSecondFrequentCount(string input, int expected)
        {
            var result = SecondMostOccurredCharacter.Get(input);
            Assert.AreEqual(expected, result);
        }

        [TestCase("ababac", 2)]
        [TestCase("abaacadefghab", 2)]
        [Test]
        public void OrderOfCharactersDoesNotMatter(string input, int expected)
        {
            var result = SecondMostOccurredCharacter.Get(input);
            Assert.AreEqual(expected, result);
        }
    }
}