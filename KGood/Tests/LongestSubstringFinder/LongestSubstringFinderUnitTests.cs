using System;
using NUnit.Framework;

namespace KGood.Tests.LongestSubstringFinder
{
    [TestFixture]
    internal class LongestSubstringFinderTests
    {
        private Source.LongestSubstringFinder.LongestSubstringFinder sut;
        private const string string_abc = "abc";
        private const string string_aaab = "aaab";
        private const string StringAabbc = "aabbc";

        [Test]
        public void Constructor_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Source.LongestSubstringFinder.LongestSubstringFinder(null, 0));
        }

        [Test]
        public void Constructor_EmptyString_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Source.LongestSubstringFinder.LongestSubstringFinder(string.Empty, 00));
        }

        [Test]
        public void Constructor_LengthIsMoreThanWordLength_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Source.LongestSubstringFinder.LongestSubstringFinder(string_abc, 4));
        }

        [Test]
        public void FindString_AAAB2_ReturnsAAAB()
        {
            sut = new Source.LongestSubstringFinder.LongestSubstringFinder(string_aaab, 2);
            string result = sut.FindString();

            Assert.That(result, Is.EqualTo(string_aaab));
        }

        [Test]
        public void FindString_AAAB1_ReturnsAAA()
        {
            sut = new Source.LongestSubstringFinder.LongestSubstringFinder("aaab", 1);
            string result = sut.FindString();
            Assert.That(result, Is.EqualTo("aaa"));
        }

        [Test]
        public void FindString_AABBC2_ReturnsAABB()
        {
            sut = new Source.LongestSubstringFinder.LongestSubstringFinder(StringAabbc, 2);
            string result = sut.FindString();

            Assert.That(result, Is.EqualTo("aabb"));
        }

        [Test]
        public void FindString_AABBC3_ReturnsAABBC()
        {
            sut = new Source.LongestSubstringFinder.LongestSubstringFinder(StringAabbc, 3);
            string result = sut.FindString();

            Assert.That(result, Is.EqualTo("aabbc"));
        }

        [Ignore("Not implemented")]
        [Test]
        public void FindString_AABBCCC2_ReturnsBBCCC()
        {
            sut = new Source.LongestSubstringFinder.LongestSubstringFinder("aabbccc", 2);
            string result = sut.FindString();

            Assert.That(result, Is.EqualTo("bbccc"));
        }
    }
}