using System.Linq;
using KGood.Source.StringDividing;
using NUnit.Framework;

namespace KGood.Tests.StringDividing
{
    [TestFixture]
    public class WhenDividedAndOrdered
    {
        [Test]
        public void LongestItemIsFirst()
        {
            var sut = new LongestPartFinder();
            var result = sut.DivideAndOrder("aabbbccccdd", 2);
            Assert.That(result.First(), Is.EqualTo(new MaybeString("bbbcccc")));
        }
    }
}