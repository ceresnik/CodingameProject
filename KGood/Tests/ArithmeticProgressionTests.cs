/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2017. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using KGood.Source;
using NUnit.Framework;

namespace KGood.Tests
{
    [TestFixture]
    public class ArithmeticProgressionTests
    {
        [TestCase(3, 3, 5, 45)]
        [TestCase(10, 5, 7, 175)]
        [TestCase(2, 3, 50, 3775)]
        [Test]
        public void Test(int startingNumber, int difference, int countOfNumbers, int expected)
        {
            var result = ArithmeticProgression.Calculate(startingNumber, difference, countOfNumbers);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}