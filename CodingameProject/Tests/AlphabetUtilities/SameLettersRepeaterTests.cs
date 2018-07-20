using CodingameProject.Source.AlphabetUtilities;
using NUnit.Framework;

namespace CodingameProject.Tests.AlphabetUtilities
{
    [TestFixture]
    public class SameLettersRepeaterTests
    {
        [Test]
        public void Constructor()
        {
            string input = "Bla";
            var sut = new SameLettersRepeater(input);
            Assert.That(sut, Is.Not.Null);
        }

        [Test]
        public void NoLetterRepeated()
        {
            string input = "Bla";
            var sut = new SameLettersRepeater(input);
            string result = sut.Convert();
            Assert.That(result, Is.EqualTo("Bla"));
        }

        [Test]
        public void OneLetterRepeated()
        {
            string input = "Lama";
            var sut = new SameLettersRepeater(input);
            string result = sut.Convert();
            Assert.That(result, Is.EqualTo("Lamaa"));
        }

        [Test]
        public void TwoLettersRepeated()
        {
            string input = "bonobo";
            var sut = new SameLettersRepeater(input);
            string result = sut.Convert();
            Assert.That(result, Is.EqualTo("bonoobbooo"));
        }

        [Test]
        public void UpperCaseAndLowerCase()
        {
            string input = "Bonobo";
            var sut = new SameLettersRepeater(input);
            string result = sut.Convert();
            Assert.That(result, Is.EqualTo("Bonoobbooo"));
        }

        [Test]
        public void LowerCaseAndUpperCase()
        {
            string input = "bonoBo";
            var sut = new SameLettersRepeater(input);
            string result = sut.Convert();
            Assert.That(result, Is.EqualTo("bonooBBooo"));
        }
    }
}