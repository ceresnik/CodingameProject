using KGood.Source;
using NUnit.Framework;

namespace KGood.Tests
{
    [TestFixture]
    public class AsciiCodeToLetterConverterTests
    {
        [TestCase("111", "o")]
        [TestCase("101", "e")]
        [TestCase("111101", "oe")]
        [TestCase("067111100105110103097109101", "Codingame")]
        [Test]
        public void Test_ConvertAsciiCodesToLetters(string input, string expected)
        {
            var sut = new AsciiCodeToLetterConverter();
            var result = sut.ConvertAsciiCodesToLetters(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}