using KGood.Source;
using NUnit.Framework;

namespace KGood.Tests
{
    [TestFixture]
    public class BonoboTests
    {
        [Test]
        public void RepeatedLetters_ResultIsCorrect()
        {
            var result = Bonobo.Convert("bonobo");
            Assert.That(result, Is.EqualTo("bonoobbooo"));
        }

        [Test]
        public void NotRepeatedLetters_ResultIsTheSame()
        {
            var inputString = "Cougar";
            var result = Bonobo.Convert(inputString);
            Assert.That(result, Is.EqualTo(inputString));
        }
    }
}