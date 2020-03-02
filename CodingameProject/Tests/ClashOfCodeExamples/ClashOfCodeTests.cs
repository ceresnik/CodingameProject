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
    }
}
