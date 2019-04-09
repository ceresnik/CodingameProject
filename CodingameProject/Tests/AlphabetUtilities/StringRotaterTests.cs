using NUnit.Framework;
using CodingameProject.Source.AlphabetUtilities;

namespace CodingameProject.Tests.AlphabetUtilities
{
    [TestFixture]
    public class StringRotaterTests
    {
        [TestCase("abcd", "dabc")]
        [TestCase("cdab", "bcda")]
        [TestCase("bcda", "abcd")]
        [Test]
        public void TestOneRightRotation(string input, string expected)
        {
            string result = StringRotater.DoRightRotation(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("abcd", "cdab")]
        [TestCase("abcd", "bcda")]
        [TestCase("abcd", "abcd")]
        [TestCase("bcda", "dabc")]
        [TestCase("cdab", "dabc")]
        [Test]
        public void TestRightRotation_True(string input, string expected)
        {
            var result = StringRotater.IsRightRotated(input, expected);
            Assert.That(result, Is.True);
        }

        [TestCase("abcd", "abdc")]
        [TestCase("abcd", "bacd")]
        [TestCase("abcd", "acbd")]
        [TestCase("bcda", "dbac")]
        [TestCase("cdab", "dbca")]
        [Test]
        public void TestRightRotation_False(string input, string expected)
        {
            var result = StringRotater.IsRightRotated(input, expected);
            Assert.That(result, Is.False);
        }

        [TestCase("abcd", "bcda")]
        [TestCase("cdab", "dabc")]
        [TestCase("bcda", "cdab")]
        [Test]
        public void TestOneLeftRotation(string input, string expected)
        {
            string result = StringRotater.DoLeftRotation(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}