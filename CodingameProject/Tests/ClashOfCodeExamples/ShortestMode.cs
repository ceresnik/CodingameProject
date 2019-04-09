using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingameProject.Tests.ClashOfCodeExamples
{
    public class ShortestMode
    {
        [TestCase(2, 2016, 29)]
        [TestCase(2, 2017, 28)]
        [TestCase(2, 2018, 28)]
        [TestCase(2, 2019, 28)]
        [TestCase(2, 2020, 29)]
        [TestCase(1, 2019, 31)]
        [TestCase(3, 2019, 31)]
        [TestCase(4, 2019, 30)]
        [TestCase(5, 2019, 31)]
        [TestCase(6, 2019, 30)]
        [TestCase(7, 2019, 31)]
        [TestCase(8, 2019, 31)]
        [Test]
        public void CountOfDaysInMonth(int month, int year, int expected)
        {
            int m = month;
            int y = year;
            int r = DateTime.DaysInMonth(y, m);
            Assert.That(r, Is.EqualTo(expected));
        }

        [Test]
        public void OrderAndFormatNumbersToString()
        {
            var inputList1 = new List<int> { 1, 9, 5 }.OrderBy(x => x).ToList();
            var inputList2 = new List<int> { 2, 1, 6 }.OrderBy(x => x).ToList();

            var pairs = inputList1.Select((x, y) => "(" + x + ", " + inputList2[y] + ")").ToList();
            var result = string.Join(", ", pairs);
            Console.WriteLine(result);
            Assert.That(result, Is.EqualTo("(1, 1), (5, 2), (9, 6)"));
        }

        [TestCase("Coding game", 1)]
        [TestCase("Codingame", 0)]
        [TestCase("This is the test", 1)]
        [TestCase("This is the basic test", 2)]
        [TestCase("Game is over", 3)]
        [TestCase("Not enough time to finish this clash at all", 4)]
        [TestCase("Katarina Lukas Peter Tomas Lubo Laco Milan Marek Erik Simon", 10)]
        [TestCase("Michal Ladislav Brigita Jasmin Lucia Hanna Kristina", 0)]
        [Test]
        public void CountWordsHavingNeitherTwoSuccessiveVowelsNorConsonants(string input, int expected)
        {
            var inputWords = input.Split(' ').ToList();
            int result = inputWords.Count(myCountingFunc);
            Assert.That(result, Is.EqualTo(expected));
        }

        private readonly Func<string, bool> myCountingFunc = word =>
        {
            var vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            bool currentWordIsOk = true;
            for (var i = 0; i < word.Length - 1; i++)
            {
                char currentLowerCaseLetter = char.ToLower(word[i]);
                bool isVowel = vowels.Contains(currentLowerCaseLetter);
                char nextLetter = char.ToLower(word[i + 1]);
                bool nextLetterIsVowel = vowels.Contains(nextLetter);
                if (isVowel)
                {
                    if (nextLetterIsVowel)
                    {
                        currentWordIsOk = false;
                        break;
                    }
                }
                else
                {
                    if (nextLetterIsVowel == false)
                    {
                        currentWordIsOk = false;
                        break;
                    }
                }
            }
            return currentWordIsOk;
        };

        /// <summary>
        /// Return the output of the Ackermann function.
        /// If at least one of the numbers given is impossible to compute (M=3 is possible to compute, but won't be computed), return -1.
        /// Ackermann function:
        /// if M = 0: return n + 1 
        /// if N = 0: return Ackermann function of M - 1, 1
        /// Default: return Ackermann function of (M - 1, Ackermann function of(M, N - 1))
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="expected"></param>
        [TestCase(0, 99, 100)]
        [TestCase(1, 0, 2)]
        [TestCase(5, -1, -1)]
        [TestCase(2, 55, 113)]
        [TestCase(2, 97, 197)]
        [Test]
        public void AckermannFunctionTest(int m, int n, int expected)
        {
            int result = -1;
            if (m >= 0 & m < 3 && n >= 0 && n <= 100)
                result = CountAckermannFunction(m, n);
            Assert.That(result, Is.EqualTo(expected));
        }

        private int CountAckermannFunction(int m, int n)
        {
            if (m == 0)
            {
                return n + 1;
            }
            if (n == 0)
            {
                return CountAckermannFunction(m - 1, 1);
            }
            return CountAckermannFunction(m - 1, CountAckermannFunction(m, n - 1));
        }

        [Test]
        public void CountPeopleInCityWhatMatchesCityPattern()
        {
            var input = new Dictionary<string, int> {{"London", 8}, {"Maribor", 5}, {"Marseille", 12}};
            string searchPattern = "Mar";
            var query = (from item in input
                where item.Key.Contains(searchPattern)
                select item.Value).Sum();
            Assert.That(query, Is.EqualTo(17));

            var result = input.Where(x => x.Key.Contains(searchPattern)).Sum(x => x.Value);
            Assert.That(result, Is.EqualTo(17));
        }
    }
}