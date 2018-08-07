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
        [TestCase(180, "P")]
        [Test]
        public void Test_DegreesToRadiansConvertor(int angleInDegrees, string expected)
        {
            var sut = new DegreesToRadiansConvertor();
            string result = sut.Convert(angleInDegrees);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}