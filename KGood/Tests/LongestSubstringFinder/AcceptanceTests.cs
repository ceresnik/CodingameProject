using NUnit.Framework;

namespace KGood.Tests.LongestSubstringFinder
{
    [TestFixture]
    internal class AcceptanceTests
    {
        private string inputLine1;
        private int inputLine2;
        private int expected;

        [Test]
        public void Test_01()
        {
            inputLine1 = "abcdef";
            inputLine2 = 3;
            expected = 3;

            var sut = new Source.LongestSubstringFinder.LongestSubstringFinder(inputLine1, inputLine2);
            Assert.That(sut.FindString().Length, Is.EqualTo(expected));
        }

        [Test]
        public void Test_02()
        {
            inputLine1 = "aaaaaaaabc";
            inputLine2 = 3;
            expected = 10;

            var sut = new Source.LongestSubstringFinder.LongestSubstringFinder(inputLine1, inputLine2);
            Assert.That(sut.FindString().Length, Is.EqualTo(expected));
        }
    }
}