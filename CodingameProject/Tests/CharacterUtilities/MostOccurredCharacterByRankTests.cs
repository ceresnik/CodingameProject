using CodingameProject.Source.CharacterUtilities;
using NUnit.Framework;

namespace CodingameProject.Tests.CharacterUtilities
{
    class MostOccurredCharacterByRankTests
    {
        [Test]
        public void EmptyWordReturnsUndefinedCount()
        {
            Assert.AreEqual(new UndefinedCount(), new MostOccurredCharacterByRank().Get(string.Empty));
        }

        [Test]
        public void WordWhichIsNullReturnsUndefinedCount()
        {
            Assert.AreEqual(new UndefinedCount(), new MostOccurredCharacterByRank().Get(null));
        }

        [TestCase("ababac", 2)]
        [TestCase("abaacadefghab", 2)]
        [TestCase("abacadaeafagahaibbb", 4)]
        [Test]
        public void OrderOfCharactersDoesNotMatter(string input, int expected)
        {
            var result = new MostOccurredCharacterByRank().Get(input);
            Assert.AreEqual(new DefinedCount(expected), result);
        }

        [Test]
        public void InstanceOfICountInterface()
        {
            var result = new MostOccurredCharacterByRank().Get("irrelevantInput");
            Assert.IsTrue(typeof(ICount).IsInstanceOfType(result));
        }

        [TestCase("abbccc", 3, 1)]
        [TestCase("aabcd", 4, -1)]
        [TestCase("abacadaeafagahaibbb", 1, 8)]
        [Test]
        public void ResultIsDeterminedByRank(string input, int rank, int expected)
        {
            var result = new MostOccurredCharacterByRank(rank).Get(input);
            Assert.AreEqual(new DefinedCount(expected), result);
        }
    }
}