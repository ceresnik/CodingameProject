using CodingameProject.Source.CharacterUtilities;
using NUnit.Framework;

namespace CodingameProject.Tests.CharacterUtilities
{
    class SecondMostOccurredCharacterTests
    {
        [TestCase("a")]
        [TestCase("a")]
        [TestCase("1")]
        [Test]
        public void WordWithOneCharacterReturnsUndefinedCount(string input)
        {
            var result = new MostOccurredCharacterByRank().Get(input);
            Assert.AreEqual(new UndefinedCount(), result);
        }
        [TestCase("aa")]
        [TestCase("aa")]
        [TestCase("11")]
        [Test]
        public void WordWithTwoSameCharactersReturnsUndefinedCount(string input)
        {
            var result = new MostOccurredCharacterByRank().Get(input);
            Assert.AreEqual(new UndefinedCount(), result);
        }

        [TestCase("ab")]
        [TestCase("ddff")]
        [TestCase("1111122222")]
        [TestCase("aaaBBBccc")]
        [TestCase("ipOHLeTtdfDcJhAKgbaobeOHoJLKcApTidDgtfhadocJDtLHfbeaigpOhTAKdKhoDaiAbHegpJtOfLcTiTbpOacKtofdLDhHJgAe")]
        [Test]
        public void WordWithDifferentCharactersAllWithSameCountReturnsUndefinedCount(string input)
        {
            var result = new MostOccurredCharacterByRank().Get(input);
            Assert.AreEqual(new UndefinedCount(), result);
        }

        [TestCase("aaabbc", 2)]
        [TestCase("abbccc", 2)]
        [TestCase("abbbbbbbbbbbbbbbbbbbbbcccccc", 6)]
        [Test]
        public void WordWithThreeCharactersEachDifferentCountReturnsSecondFrequentCount(string input, int expected)
        {
            var result = new MostOccurredCharacterByRank().Get(input);
            Assert.AreEqual(new DefinedCount(expected), result);
        }

        [TestCase("aaabbcc", 2)]
        [TestCase("aabbccc", 2)]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbcccccc", 6)]
        [Test]
        public void WordWithMoreCharactersWithSecondFrequencyReturnsSecondFrequentCount(string input, int expected)
        {
            var result = new MostOccurredCharacterByRank().Get(input);
            Assert.AreEqual(new DefinedCount(expected), result);
        }
    }
}