using KGood.Source;
using NUnit.Framework;
using Test.Library;

namespace KGood.Tests
{
    public class ConvertTimeToMinutesTests : GWT
    {
        [Test]
        public void ThenResultIs785Minutes()
        {
            string input = null;
            string expected = "785";
            string result = null;
            Given(() => input = "13:05");
            When(() => result = NumberUtilities.ConvertTimeToMinutes(input));
            Then(() => Assert.That(result, Is.EqualTo(expected)));
        }

        [TestCase("13:05", "785")]
        [Test]
        public void Test_ConvertTimeToMinutes(string input, string expected)
        {
            var result = NumberUtilities.ConvertTimeToMinutes(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}