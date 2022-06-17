using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingameProject.Tests.ClashOfCodeExamples
{
    internal static class SecondMostOccurredCharacter
    {
        public static int Get(string input)
        {
            if (string.Empty == input)
            {
                return -1;
            }
            var countOfOccurrencesByLetter = new Dictionary<char, int>();
            foreach (char c in input.Distinct())
            {
                countOfOccurrencesByLetter.Add(c, input.Count(x => x == c));
            }

            var sortedListOfOccurrences = countOfOccurrencesByLetter.OrderByDescending(x => x.Value).Select(y => y.Value).ToList();
            int result;
            if (sortedListOfOccurrences.Count > 1)
            {
                if (sortedListOfOccurrences[0] > sortedListOfOccurrences[1])
                {
                    result = sortedListOfOccurrences[1];
                }
                else
                {
                    result = -1;
                }
            }
            else
            {
                result = sortedListOfOccurrences[0];
            }
            return result;
        }
    }

    class SecondMostOccurredLetterTests
    {
        [Test]
        public void EmptyWordReturnsMinusOne()
        {
            Assert.AreEqual(SecondMostOccurredCharacter.Get(string.Empty), -1);
        }

        [TestCase("a", 1)]
        [TestCase("a", 1)]
        [TestCase("1", 1)]
        [Test]
        public void WordWithOneCharacterReturnsOne(string input, int expected)
        {
            var result = SecondMostOccurredCharacter.Get(input);
            Assert.AreEqual(expected, result);
        }

        [TestCase("aa", 2)]
        [TestCase("aa", 2)]
        [TestCase("11", 2)]
        [Test]
        public void WordWithTwoSameCharactersReturnsTwo(string input, int expected)
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