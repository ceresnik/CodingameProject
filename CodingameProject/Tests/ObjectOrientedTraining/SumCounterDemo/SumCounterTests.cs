using System;
using System.Collections.Generic;
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

        [Test]
        public void Test()
        {
            var input = new List<Tuple<int, int>>();

            int x = -2;
            int y = 0;
            input.Add(new Tuple<int, int>(x, y));
            x = -2;
            y = 4;
            input.Add(new Tuple<int, int>(x, y));
            x = 3;
            y = 4;
            input.Add(new Tuple<int, int>(x, y));
            x = 3;
            y = 0;
            input.Add(new Tuple<int, int>(x, y));

            int xShift = 0 - input[0].Item1;
            int yShift = 0 - input[0].Item2;

            var inputAdjusted = new List<Tuple<int, int>>();
            foreach (var tuple in input)
            {
                int xx = tuple.Item1 + xShift;
                int yy = tuple.Item2 + yShift;
                var adjustedTuple = new Tuple<int, int>(xx, yy);
                inputAdjusted.Add(adjustedTuple);
            }

            int w = inputAdjusted[3].Item1 - inputAdjusted[0].Item1;
            int l = inputAdjusted[1].Item2 - inputAdjusted[0].Item2;

            double result = w * l;
            Console.WriteLine("{0:N1}", result);
        }
    }
}