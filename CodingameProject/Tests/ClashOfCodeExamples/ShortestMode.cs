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
        public void OrderAndFormatNumbers()
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
            string[] inputWords = input.Split(' ');
            var vowels = new List<char> { 'a', 'e', 'i', 'o', 'u'};
            int result = 0;
            foreach (string word in inputWords)
            {
                bool currentWordIsOk = true;
                for (var index = 0; index < word.Length - 1; index++)
                {
                    char c = word[index];
                    char currentLowerCaseLetter = char.ToLower(c);
                    bool isVowel = vowels.Contains(currentLowerCaseLetter);
                    char nextLetter = char.ToLower(word[index + 1]);
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
                if (currentWordIsOk)
                {
                    result++;
                }
            }
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}