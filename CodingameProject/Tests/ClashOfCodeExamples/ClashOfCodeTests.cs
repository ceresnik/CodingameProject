using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using NUnit.Framework;


namespace CodingameProject.Tests.ClashOfCodeExamples
{
    [TestFixture]
    class ClashOfCodeTests
    {
        [Test]
        public void SortItemsInListAccordingToLength()
        {
            var inputs = new List<string> { "abc", "xs", "longWord", "z" };
            var sorted = inputs.OrderBy(x => x.Length).ToList();
            sorted.ForEach(Console.WriteLine);
        }

        [TestCase("1 309", "1309")]
        [TestCase("1,309", "1309")]
        [TestCase("1.309", "1309")]
        [Test]
        public void RemoveSpecialCharacters(string input, string expected)
        {
            string result = new string(input.Where(x => x >= '0' && x <= '9').ToArray());
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("1,399", 1399)]
        [Test]
        public void TestInvariantCulture(string input, int expected)
        {
            string convertedToInvariantCulture = input.ToString(CultureInfo.InvariantCulture);
            int result = Convert.ToInt32(convertedToInvariantCulture, CultureInfo.InvariantCulture);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void SplitTextToStanzas()
        {
            string input = @"*
                           &
                           Roses are red*Violets are blue&Here's a new stanza*Just for you";
            var linesSeparator = input[0];
            char stanzasSeparator = input[30];
            var lines = input.Substring(60).Split(linesSeparator).ToList();

            foreach (string line in lines)
            {
                string outputLine = line;
                if (line.Contains(stanzasSeparator))
                {
                    string newStanza = Environment.NewLine + Environment.NewLine;
                    outputLine = string.Join(newStanza, line.Split(stanzasSeparator));
                }
                Console.WriteLine(outputLine);
            }
        }

        [Test]
        public void SegregateLowersAndUppers_1()
        {
            string input = "AeBfCgDhZz";
            var upperList = input.Where(x => x >= 'A' && x <= 'Z');
            var lowerList = input.Where(x => x >= 'a' && x <= 'z');
            Console.WriteLine(upperList.ToArray());
            Console.WriteLine(lowerList.ToArray());
            Assert.That(upperList, Is.EqualTo("ABCDZ"));
            Assert.That(lowerList, Is.EqualTo("efghz"));
        }

        [Test]
        public void SegregateLowersAndUppers_2()
        {
            string input = "AeBfCgDhZz";
            var upperList = new List<char>();
            var lowerList = new List<char>();
            input.ToList().ForEach(x =>
            {
                if (char.IsLower(x))
                    lowerList.Add(x);
                else
                    upperList.Add(x);
            });
            Console.WriteLine(upperList.ToArray());
            Console.WriteLine(lowerList.ToArray());
            Assert.That(upperList, Is.EqualTo("ABCDZ"));
            Assert.That(lowerList, Is.EqualTo("efghz"));
        }

        [Test]
        public void SegregateLowersAndUppers_Dominik()
        {
            string input = "AeBfCgDhZz";
            string low = string.Empty;
            string hig = string.Empty;
            foreach (char item in input)
            {
                if (char.IsLower(item))
                {
                    low += item;
                }
                else
                {
                    hig += item;
                }
            }
            Console.WriteLine(low.ToArray());
            Console.WriteLine(hig.ToArray());
            Assert.That(hig, Is.EqualTo("ABCDZ"));
            Assert.That(low, Is.EqualTo("efghz"));
        }

        [TestCase("Hello", "Hll")]
        [TestCase("This Is a sentence", "Ths s  sntnc")]
        public void RemoveVowels(string input, string expected)
        {
            var forbiddenChars = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            var result = input.Where(x => forbiddenChars.Contains(char.ToLower(x)) == false);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(5, -14, "Lower")]
        [TestCase(5, -15, "Same")]
        [TestCase(5, -16, "Higher")]
        public void CelsiusToFahrenheit(int input1, int input2, string expected)
        {
            int b = input1;
            int celsius = input2;

            //var tf = (int)(t * (double)9 / 5 + 32);
            //var tf = (int)(t * ((double)9/5) + 32);
            //var tf = t * (9/5) + 32;
            //var tf = 9 / 5 * t + 32;
            var tf = celsius * (9f / 5) + 32;
            
            int celsiusConvertedToFahrenheit1 = celsius * 9 / 5 + 32;
            int celsiusConvertedToFahrenheit2 = celsius * (9 / 5) + 32;

            var result = "";
            if (Math.Abs(b - tf) < 0.0001) result = "Same";
            if (b < tf) result = "Lower";
            if (b > tf) result = "Higher";
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(2, 3, 16)]
        [TestCase(2, 4, 65536)]
        [TestCase(3, 3, 7625597484987)]
        [TestCase(9, 2, 387420489)]
        public void Tetration(long baseNum, int height, long expected)
        {
            long num = baseNum;
            for (int i = 1; i < height; i++)
            {
                num = (long)Math.Pow(baseNum, num);
            }
            Console.WriteLine(num);
            Assert.That(num, Is.EqualTo(expected));
        }

        [Test]
        public void EvenAndOdd()
        {
            int a = 2;
            int b = 3;
            int c = 4;
            var list = new List<int> { a, b, c };
            int result = 0;
            list.ForEach(x => result += x % 2 == 0 ? x : -x);
            Console.WriteLine(result);
            int expected = 3;
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(4, 9, 4, "4")]
        [TestCase(9, 9, 4, "9")]
        [TestCase(4, 9, 9, "9")]
        [TestCase(-657, -657, -657, "-657")]
        [TestCase(5, 7, 9, "no solution")]
        public void GroupingTest(int a, int b, int c, string expected)
        {
            var list = new List<int> { a, b, c };
            var occurrences = list.GroupBy(x => x).Where(x => x.Count() >= 2).Select(x => x).ToList();
            string result = occurrences.Count == 0 ? "no solution" : occurrences.First().Key.ToString();
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(15, "It is true that we do not know what we have got until we lose it, but it is also true that we do not know what we have been " +
                      "missing until it arrives.", "also")]
        [TestCase(8, "Everybody wants to go to heaven, but nobody wants to die.", "die")]
        public void ExtractTheNthWord(int positionOfTheWordToExtract, string inputSentence, string expected)
        {
            inputSentence = inputSentence.ToLower();
            char[] forbiddenChars = {',', '.', '\u0022' };// `\u0022` is a double quote
            foreach (char c in forbiddenChars)
            {
                if (inputSentence.Contains(c))
                {
                    inputSentence = inputSentence.Replace(c.ToString(), ""); // replace all forbidden characters by empty string
                }
            }
            var result = inputSentence.Split().Distinct().ToList();
            Assert.AreEqual(expected, result[positionOfTheWordToExtract - 1]);
        }

        /// <summary>
        /// I am playing a game that is a lot like 2048, but it doesn't tell me my score, so I don't know how well I am doing!
        /// All I have to do to calculate the score is add up the values of all of the squares. Empty squares, represented
        /// by periods, are worth 0 points. The rest are tricky, though, because each square is equal to two to the power to
        /// what is shown as a hexadecimal number.
        /// That means that 1 is represented as 0 (2^0 = 1) and the classic 2048 is represented as b (2^11 = 2048).
        /// </summary>
        [TestCase(". . . . \r\n . . 0 . \r\n . 0 . 1 \r\n . 1 . . \r\n", 6)]
        [TestCase("5 6 5 3 \r\n 0 1 . b \r\n 5 2 1 . \r\n . . 0 0", 2227)]
        [TestCase("e c a 8 2 3 4 . \r\n c 0 4 . 3 5 . 6 \r\n f 4 1 2 . . 3 7 \r\n . . 3 . a . . . \r\n . . 9 . . . 1 . \r\n 0 0 . 3 . . . 2 \r\n . 1 . 0 . 3 4 . \r\n . . . 5 . 3 2 . \r\n", 60562)]
        [TestCase("0 c 2 f \r\n 3 a 4 7 \r\n 0 9 1 b \r\n e d 4 a \r\n", 66224)]
        public void Test2048(string board, int expected)
        {
            // Define a regular expression for valid hexadecimal digits
            var hexPattern = new System.Text.RegularExpressions.Regex("^[0-9A-Fa-f]$");

            // Split the input string into individual 
            string[] input = board.Split(' ');

            // Initialize the score
            int score = 0;

            //Linq solution:
            //int score = (from thePowerOfTwo in input where hexPattern.IsMatch(thePowerOfTwo) select Convert.ToInt32(thePowerOfTwo, 16) into hexValue select (int) Math.Pow(2, hexValue)).Sum();

            // Iterate through each square
            foreach (string thePowerOfTwo in input)
            {
                // If the square is a valid hexadecimal digit
                if (hexPattern.IsMatch(thePowerOfTwo))
                {
                    // Convert the hexadecimal digit to an integer
                    int hexValue = Convert.ToInt32(thePowerOfTwo, 16);

                    // Calculate the value of the square (2^hexValue)
                    score += (int)Math.Pow(2, hexValue);
                }
            }

            Assert.That(score, Is.EqualTo(expected), $"{score} is not a good answer.");
        }
    }
}
