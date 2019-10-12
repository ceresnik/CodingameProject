using CodingameProject.Source.MathematicalUtilities;
using NUnit.Framework;

namespace CodingameProject.Tests.MathematicalUtilities
{
    [TestFixture]
    public class UnaryEncoderTests
    {
        [Test]
        public void Test_Encode_LetterC()
        {
            var sut = new UnaryEncoder();
            string input = "C";
            var result = sut.Encrypt(input);
            var expected = "0 0 00 0000 0 00";
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}