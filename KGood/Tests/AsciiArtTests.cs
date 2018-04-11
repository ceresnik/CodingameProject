using System;
using System.Collections.Generic;
using System.Linq;
using KGood.Source;
using NUnit.Framework;

namespace KGood.Tests
{
    [TestFixture]
    public class AsciiArtTests
    {
        [Test]
        public void TestAsciiArt()
        {
            string[] inputRows = { ".---.", "|---|", ".---." };
            var result = new AsciiArt().InvertASCIIArt(inputRows);

            Assert.That(result, Is.EqualTo(".|.\r\n---\r\n---\r\n---\r\n.|.\r\n"));
        }

        [Test]
        public void Test_IndexOfLetterInAlphabet()
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string input = "DAbE";
            IList<int> indexes = input.Select(c => alphabet.IndexOf(Char.ToLower(c))).ToList();
            CollectionAssert.Contains(indexes, 3);
            CollectionAssert.Contains(indexes, 0);
            CollectionAssert.Contains(indexes, 1);
            CollectionAssert.Contains(indexes, 4);
            Assert.That(indexes.Count, Is.EqualTo(4));
        }
    }
}