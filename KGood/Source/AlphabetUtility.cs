﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KGood.Source.Extensions;

namespace KGood.Source
{
    public class AlphabetUtility
    {
        private readonly string word;

        public AlphabetUtility(string word)
        {
            this.word = word;
        }

        public string FindFirstNotCorrectlyPlacedLetter()
        {
            char biggestLetter = word[0];
            string result = word[0].ToString();
            foreach (char currentLetter in word)
            {
                if (biggestLetter > currentLetter)
                {
                    result = currentLetter.ToString();
                    break;
                }
                biggestLetter = currentLetter;
            }
            return result;
        }

        /// <summary>
        /// Given is decoded message via ASCII characters. "32" means space. Letters of each word 
        /// are given reverse.
        /// </summary>
        /// <returns>Decoded message</returns>
        public String DecodeMessage()
        {
            IList<int> asciiNumbers = word.Split(' ')
                .Select(asciiString => Convert.ToInt16(asciiString))
                .Select(asciiNumber => (int)asciiNumber)
                .ToList();
            StringBuilder result = new StringBuilder();
            int endIndex = 0;
            for (int i = 0; i < asciiNumbers.Count; i++)
            {
                if (asciiNumbers[i] == 32)
                {
                    for (int j = i - 1; j >= endIndex; j--)
                    {
                        result.Append(Convert.ToChar(asciiNumbers[j]));
                    }
                    endIndex = i + 1;
                    result.Append(" ");
                }
                if (i == asciiNumbers.Count - 1)
                {
                    for (int j = i; j >= endIndex; j--)
                    {
                        result.Append(Convert.ToChar(asciiNumbers[j]));
                    }
                }
            }
            return result.ToString();
        }

        public string RunLengthEncoding()
        {
            var result = new StringBuilder();
            int index = 0;
            do
            {
                var counter = 0;
                char previousLetter = word[index];
                do
                {
                    counter++;
                    index++;
                } while (index < word.Length && word[index] == previousLetter);
                result.Append($"{counter}{previousLetter}");
            } while (index < word.Length);
            return result.ToString();
        }

        public string RunLengthEncoding2()
        {
            StringBuilder result = new StringBuilder();
            char p = word[0];
            int count = 0;
            foreach (char c in word)
            {
                if (c == p)
                {
                    count++;
                }
                else
                {
                    result.Append($"{count}{p}");
                    p = c;
                    count = 1;
                }
            }
            result.Append($"{count}{p}");
            return result.ToString();
        }

        public string DecodeCaesarBoxCipher()
        {
            int numberOfRows = (int)Math.Sqrt(word.Length);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfRows; j++)
                {
                    result.Append(word[i+j*numberOfRows]);
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Cycles letters in given string
        /// </summary>
        /// <example>Input: "ABC"</example>
        /// <example>Output:</example>
        /// <example>"ABC"</example>
        /// <example>"BCA"</example>
        /// <example>"CAB"</example>
        /// <example>"ABC"</example>
        /// <returns></returns>
        public string CycleLetters()
        {
            StringBuilder resultLine = new StringBuilder();
            IList<string> resultLines = new List<string>();
            int i = 0;
            do
            {
                resultLine.Clear();
                for (int j = word.Length - i; j < 2 * word.Length - i; j++)
                {
                    resultLine.Append(j >= word.Length ? word[j - word.Length] : word[j]);
                }
                resultLines.Add(resultLine.ToString());
                i++;
            } while (word.Equals(resultLine.ToString()) == false || i == 1);
            return String.Join(Environment.NewLine, resultLines);
        }

        /// <summary>
        /// Encodes given message in a way that it divides it at half and puts letters alternately 
        /// from each half.
        /// </summary>
        /// <param name="input"></param>
        /// <example>"Hello!" encodes to "Hleol!"</example>
        /// <returns></returns>
        public static string EncodeMessage(string input)
        {
            int midPoint = (input.Length + 1) / 2;
            StringBuilder output = new StringBuilder();;
            for (int i = 0; i < midPoint; i++)
            {
                output.Append(input[i]);
                int secondIndex = i + midPoint;
                if (secondIndex.IsWithin(input))
                {
                    output.Append(input[secondIndex]);
                }
            }
            return output.ToString();
        }

        /// <summary>
        /// Encodes particular words of the sentence in a way, that words beginning with vowels
        /// encodes as "eek", others as "ook" (keeps uppercase/lowercase).
        /// Punctuation marks keeps as it is.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string EncodeOrang_utan(string input)
        {
            IList<string> inputList = input.Split(' ');
            IList<string> results = new List<string>();
            foreach (string word in inputList)
            {
                string orangutanWord = "ook";
                if (StartsWithVowel(word))
                {
                    orangutanWord = "eek";
                }
                if (StartsWithUpperCase(word))
                {
                    char upperLetter = Char.ToUpper(orangutanWord[0]);
                    orangutanWord = orangutanWord.Remove(0, 1);
                    orangutanWord = orangutanWord.Insert(0, upperLetter.ToString());
                }
                if (EndsWithPunctuation(word))
                {
                    orangutanWord += word[word.Length - 1];
                }
                results.Add(orangutanWord);
            }
            return String.Join(" ", results);
        }

        private static bool EndsWithPunctuation(string word)
        {
            return word[word.Length - 1] < 65;
        }

        private static bool StartsWithUpperCase(string word)
        {
            return word[0] > 65 && word[0] < 90;
        }

        private static bool StartsWithVowel(string word)
        {
            IList<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u', 'y' };
            char firstLetter = word[0];
            firstLetter = Char.ToLower(firstLetter);
            return vowels.Contains(firstLetter);
        }

        public static string CalculateBankThief(RobberyData robberyData)
        {
            string[] sentences = robberyData.InputSentence.Split('.', '!', '?');
            int resultTime = 0;
            foreach (string sentence in sentences)
            {
                string[] words = sentence.Split(' ');
                resultTime += words.Length * 60 / robberyData.WordsPerMinute;
                resultTime += robberyData.TimeAfterSentence;
            }
            resultTime += robberyData.TimeAfterAllSentences;
            string result = "";
            if (resultTime >= robberyData.TimeNeededByPolice)
            {
                result = "BUSTED";
            }
            else
            {
                if (resultTime * 2 <= robberyData.TimeNeededByPolice)
                {
                    result = "SPECTACULAR";
                }
                else
                {
                    result = "SUCCESS";
                }
            }
            return result;
        }

        public static int FindMostQuantityLetter(string input)
        {
            return input
                .Replace(" ", String.Empty)
                .GroupBy(c => c)
                .OrderByDescending(c => c.Count())
                .First()
                .Count();
        }

        public static string ValidateUpperCaseLowerCaseAndNumberInput(string input)
        {
            string result;
            if (input.Length <= 3 || input.Length > 30)
            {
                result = "INVALID";
            }
            else
            {
                bool valid = true;
                foreach (char c in input)
                {
                    if (c < 48 || c > 57 && c < 65 || c > 90 && c < 97 || c > 122)
                    {
                        Console.WriteLine($"{c}");
                        valid = false;
                    }
                }
                result = valid ? "VALID" : "INVALID";
            }
            return result;
        }

        public static string DoLogicalOr(string input1, string input2)
        {
            string result = "";
            for (var i = 0; i < input1.Length; i++)
            {
                if (input1[i] == '1' || input2[i] == '1')
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }
            return result;
        }

        public static string DoLogicalOrWithCharSubtraction(string input1, string input2)
        {
            string result = "";
            for (var i = 0; i < input1.Length; i++)
            {
                if (input1[i] - '0' + (input2[i] - '0') > 0)
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }
            return result;
        }

        public static IList<int> GetIndexOfLettersInAlphabet(string alphabet, string word)
        {
            return word.Select(c => alphabet.IndexOf(Char.ToLower(c))).ToList();
        }

        /// <summary>
        /// Gets count of distinct letters in string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetCountOfLetters(string input)
        {
            return input.Select(Char.ToLower).Distinct().Count();
        }

        public static IEnumerable<char> Encode_Rot13Cipher(string input)
        {
            return input.Select(x => (char)(x >= 65 && x <= 90 ? (x + 13 > 90 ? x - 13 : x + 13) : x));
        }

        public static string DecodeMessageAlternatelyFromLeftRight(string input)
        {
            StringBuilder result = new StringBuilder();
            string currentWord = input;
            bool fromLeft = true;
            while (currentWord.Any())
            {
                if (fromLeft)
                {
                    result.Append(currentWord.First());
                    currentWord = currentWord.Substring(1, currentWord.Length - 1);
                }
                else
                {
                    result.Append(currentWord.Last());
                    currentWord = currentWord.Substring(0, currentWord.Length - 1);
                }
                fromLeft = !fromLeft;
            }
            return result.ToString();
        }
    }
}