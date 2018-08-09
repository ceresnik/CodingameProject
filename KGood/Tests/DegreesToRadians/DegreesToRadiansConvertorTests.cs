using KGood.Source.DegreesToRadians;
using NUnit.Framework;

namespace KGood.Tests.DegreesToRadians
{
    [TestFixture]
    public class DegreesToRadiansConvertorTests
    {
        [TestCase(0, "0")]
        [TestCase(45, "P/4")]
        [TestCase(90, "P/2")]
        [TestCase(135, "3*P/4")]
        [TestCase(180, "P")]
        [TestCase(225, "5*P/4")]
        [TestCase(270, "3*P/2")]
        [TestCase(360, "2*P")]
        [TestCase(-90, "3*P/2")]
        [TestCase(-135, "5*P/4")]
        [TestCase(-405, "7*P/4")]
        [TestCase(405, "P/4")]
        [TestCase(765, "P/4")]
        [Test]
        public void Test_DegreesToRadiansConvertor(int angleInDegrees, string expected)
        {
            var sut = new DegreesToRadiansConvertor();
            string result = sut.Convert(angleInDegrees);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}