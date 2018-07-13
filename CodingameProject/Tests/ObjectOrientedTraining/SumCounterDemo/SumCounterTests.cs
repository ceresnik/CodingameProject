using CodingameProject.Source.ObjectOrientedTraining.SumCounterDemo;
using NUnit.Framework;

namespace CodingameProject.Tests.ObjectOrientedTraining.SumCounterDemo
{
    [TestFixture]
    public class SumCounterTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 9)]
        [TestCase(new[] { 1, 3, 5, 7, 9 }, 25)]
        [TestCase(new[] { 2, 4, 6, 8, 10 }, 0)]
        [Test]
        public void Test_SumOddNumbers(int[] input, int expected)
        {
            var sumCounter = new SumCounter(input);
            int result = sumCounter.Count(new OddNumbersSelector());
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 6)]
        [TestCase(new[] { 1, 3, 5, 7, 9 }, 0)]
        [TestCase(new[] { 2, 4, 6, 8, 10 }, 30)]
        [Test]
        public void Test_SumEvenNumbers(int[] input, int expected)
        {
            var sumCounter = new SumCounter(input);
            int result = sumCounter.Count(new EvenNumbersSelector());
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 9)]
        [TestCase(new[] { 1, 3, 5, 7, 9 }, 15)]
        [TestCase(new[] { 2, 4, 6, 8, 10 }, 18)]
        [Test]
        public void Test_SumEverySecondNumber(int[] input, int expected)
        {
            var sumCounter = new SumCounter(input);
            int result = sumCounter.Count(new EverySecondNumberSelector());
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 15)]
        [TestCase(new[] { 1, 3, 5, 7, 9 }, 25)]
        [TestCase(new[] { 2, 4, 6, 8, 10 }, 30)]
        [Test]
        public void Test_SumEachNumber(int[] input, int expected)
        {
            var sumCounter = new SumCounter(input);
            int result = sumCounter.Count();
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}