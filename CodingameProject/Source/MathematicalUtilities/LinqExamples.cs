using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingameProject.Source.MathematicalUtilities
{
    public class LinqExamples
    {
        private IList<int> intList;
        private readonly Func<int, int> evenNumbersSelector = x => x % 2 == 0 ? x : 0;
        private readonly Func<int, bool> evenNumbersPredicate = x => x % 2 == 0;

        [SetUp]
        public void Setup()
        {
            intList = new List<int> { 10, 21, 30, 45, 50, 87 };
        }

        [Test]
        public void Test_Sum()
        {
            var total = intList.Sum();
            Assert.That(total, Is.EqualTo(243));

            var sumOfEvenElements = intList.Sum(evenNumbersSelector);
            Assert.That(sumOfEvenElements, Is.EqualTo(90));
        }

        [Test]
        public void Test_Count()
        {
            var countOfEvenElements = intList.Count(evenNumbersPredicate);
            Assert.That(countOfEvenElements, Is.EqualTo(3));
        }
    }
}