/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using CodingameProject.Source.SumCounter;
using NUnit.Framework;

namespace CodingameProject.Tests.SumCounter
{
    [TestFixture]
    public class SumCounterTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5 }, true, 9)]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, false, 15)]
        [TestCase(new[] { 1, 3, 5, 7, 9 }, true, 25)]
        [TestCase(new[] { 1, 3, 5, 7, 9 }, false, 25)]
        [TestCase(new[] { 2, 4, 6, 8, 10 }, true, 0)]
        [TestCase(new[] { 2, 4, 6, 8, 10 }, false, 30)]
        [Test]
        public void Test_SumOddNumbers(int[] input, bool oddNumbersOnly, int expected)
        {
            Numbers values = new Numbers(input);
            int result = values.Sum(new OddNumbersSelector(oddNumbersOnly));
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, true, 6)]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, false, 15)]
        [TestCase(new[] { 1, 3, 5, 7, 9 }, true, 0)]
        [TestCase(new[] { 1, 3, 5, 7, 9 }, false, 25)]
        [TestCase(new[] { 2, 4, 6, 8, 10 }, true, 30)]
        [TestCase(new[] { 2, 4, 6, 8, 10 }, false, 30)]
        [Test]
        public void Test_SumEvenNumbers(int[] input, bool evenNumbersOnly, int expected)
        {
            Numbers values = new Numbers(input);
            int result = values.Sum(new EvenNumbersSelector(evenNumbersOnly));
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 9)]
        [TestCase(new[] { 1, 3, 5, 7, 9 }, 15)]
        [TestCase(new[] { 2, 4, 6, 8, 10 }, 18)]
        [Test]
        public void Test_SumEverySecondNumber(int[] input, int expected)
        {
            int result = new Numbers(input).Sum(new EverySecondNumberSelector());
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}