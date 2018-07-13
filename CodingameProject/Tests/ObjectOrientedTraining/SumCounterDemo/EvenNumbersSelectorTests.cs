using System.Linq;
using CodingameProject.Source.ObjectOrientedTraining.SumCounterDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.SumCounterDemo
{
    [TestFixture]
    public class EvenNumbersSelectorTests
    {
        [Test]
        public void EvenAndOddNumbers_PickOnlyOddNumbers()
        {
            var sut = new EvenNumbersSelector();
            int[] numbers = { 3, 4, 5, 6, 8 };
            var result = sut.Pick(numbers).Sum();
            Assert.That(result, Is.EqualTo(18));
        }
    }
}