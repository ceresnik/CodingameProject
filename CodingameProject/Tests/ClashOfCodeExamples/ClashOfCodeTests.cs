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
    }
}
