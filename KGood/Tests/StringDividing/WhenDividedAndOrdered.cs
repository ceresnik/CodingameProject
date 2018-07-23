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
            var sut = new LongestPartFinder("aabbbccccdd", 2);
            var result = sut.DivideAndOrder();
            Assert.That(result.First(), Is.EqualTo(new MaybeString("bbbcccc")));
        }
        
    }
}