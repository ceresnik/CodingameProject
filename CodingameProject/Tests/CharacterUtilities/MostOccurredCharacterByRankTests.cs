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
        [TestCase("abacadaeafagahaibbb", 2, 4)]
        [TestCase("abacadaeafagahaibbb", 3, 1)]
        [TestCase("abacadaeafagahaibbb", 4, -1)]
        [Test]
        public void ResultIsDeterminedByRank(string input, int rank, int expected)
        {
            var result = new MostOccurredCharacterByRank(rank).Get(input);
            Assert.AreEqual(new DefinedCount(expected), result);
        }

        [TestCase("a", 2)]
        [TestCase("aabb", 3)]
        [TestCase("aaaaaaaaaaaabbbbbbbcccccccccddddddddd", 5)]
        [Test]
        public void WhenRankIsOutOfBoundsReturnsUndefinedCount(string input, int rank)
        {
            var result = new MostOccurredCharacterByRank(rank).Get(input);
            Assert.AreEqual(new UndefinedCount(), result);
        }
    }
}