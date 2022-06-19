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
            Assert.AreEqual(new UndefinedCount(), SecondMostOccurredCharacter.Get(string.Empty));
        }

        [Test]
        public void WordWhichIsNullReturnsMinusOne()
        {
            Assert.AreEqual(new UndefinedCount(), SecondMostOccurredCharacter.Get(null));
        }

        [TestCase("a")]
        [TestCase("a")]
        [TestCase("1")]
        [Test]
        public void WordWithOneCharacterReturnsMinusOne(string input)
        {
            var result = SecondMostOccurredCharacter.Get(input);
            Assert.AreEqual(new UndefinedCount(), result);
        }

        [TestCase("aa")]
        [TestCase("aa")]
        [TestCase("11")]
        [Test]
        public void WordWithTwoSameCharactersReturnsMinusOne(string input)
        {
            var result = SecondMostOccurredCharacter.Get(input);
            Assert.AreEqual(new UndefinedCount(), result);
        }

        [TestCase("ab")]
        [TestCase("ddff")]
        [TestCase("1111122222")]
        [TestCase("aaaBBBccc")]
        [TestCase("ipOHLeTtdfDcJhAKgbaobeOHoJLKcApTidDgtfhadocJDtLHfbeaigpOhTAKdKhoDaiAbHegpJtOfLcTiTbpOacKtofdLDhHJgAe")]
        [Test]
        public void WordWithDifferentCharactersWithSameCountReturnsMinusOne(string input)
        {
            var result = SecondMostOccurredCharacter.Get(input);
            Assert.AreEqual(new UndefinedCount(), result);
        }

        [TestCase("aaabbc", 2)]
        [TestCase("abbccc", 2)]
        [Test]
        public void WordWithThreeCharactersEachDifferentCountReturnsSecondFrequentCount(string input, int expected)
        {
            var result = SecondMostOccurredCharacter.Get(input);
            Assert.AreEqual(new DefinedCount(expected), result);
        }

        [TestCase("ababac", 2)]
        [TestCase("abaacadefghab", 2)]
        [Test]
        public void OrderOfCharactersDoesNotMatter(string input, int expected)
        {
            var result = SecondMostOccurredCharacter.Get(input);
            Assert.AreEqual(new DefinedCount(expected), result);
        }

        [Test]
        public void InstanceOfICountInterface()
        {
            var result = SecondMostOccurredCharacter.Get("irrelevantInput");
            Assert.IsTrue(typeof(ICount).IsInstanceOfType(result));
        }
    }
}