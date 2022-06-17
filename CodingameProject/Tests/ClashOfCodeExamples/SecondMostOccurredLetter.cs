using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingameProject.Tests.ClashOfCodeExamples
{
    internal static class SecondMostOccurredLetter
    {
        public static int Get(string input)
        {
            var countOfOccurrencesByLetter = new Dictionary<char, int>();
            foreach (char c in input.Distinct())
            {
                countOfOccurrencesByLetter.Add(c, input.Count(x => x == c));
            }

            var sortedListOfOccurrences = countOfOccurrencesByLetter.OrderBy(x => x.Value).Select(y => y.Value).ToList();
            var result = sortedListOfOccurrences.Count > 1 ? sortedListOfOccurrences[1] : sortedListOfOccurrences[0];
            return result;
        }
    }

    class SecondMostOccurredLetterTests
    {
        //ipOHLeTtdfDcJhAKgbaobeOHoJLKcApTidDgtfhadocJDtLHfbeaigpOhTAKdKhoDaiAbHegpJtOfLcTiTbpOacKtofdLDhHJgAe
        //-1
        //mmmXXXXmmnYYY
        //4
        //aaaBBBccc 
        //-1
        [TestCase("a", 1)]
        [Test]
        public void WordWithOneCharacterReturnsOne(string input, int expected)
        {
            var result = SecondMostOccurredLetter.Get(input);
            Assert.AreEqual(expected, result);
        }

        [TestCase("aaabbc", 2)]
        [Test]
        public void Abc(string input, int expected)
        {
            var result = SecondMostOccurredLetter.Get(input);
            Assert.AreEqual(expected, result);
        }
    }
}