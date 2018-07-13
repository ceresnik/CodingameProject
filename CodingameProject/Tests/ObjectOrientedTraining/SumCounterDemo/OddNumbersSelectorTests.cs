using System.Linq;
using CodingameProject.Source.ObjectOrientedTraining.SumCounterDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.SumCounterDemo
{
    [TestFixture]
    public class OddNumbersSelectorTests
    {
        [Test]
        public void EvenAndOddNumbers_PickOnlyOddNumbers()
        {
            var sut = new OddNumbersSelector();
            int[] numbers = {3, 4, 5, 9, 7};
            var result = sut.Pick(numbers).Sum();
            Assert.That(result, Is.EqualTo(24));
        }        
    }
}