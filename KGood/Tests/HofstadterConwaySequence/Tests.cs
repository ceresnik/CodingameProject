using KGood.Source.HofstadterConwaySequence;
using NUnit.Framework;

namespace KGood.Tests.HofstadterConwaySequence
{
    [TestFixture]
    public class Tests
    {
        [TestCase(1, "1")]
        [TestCase(2, "1 1")]
        [TestCase(3, "1 1 2")]
        [TestCase(4, "1 1 2 2")]
        [TestCase(5, "1 1 2 2 3")]
        [TestCase(11, "1 1 2 2 3 4 4 4 5 6 7")]
        [TestCase(20, "1 1 2 2 3 4 4 4 5 6 7 7 8 8 8 8 9 10 11 12")]
        [Test]
        public void TestGenerate(int input, string expected)
        {
            string result = string.Join(" ", HofstadterConwaySequenceGenerator.Generate(input));
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}