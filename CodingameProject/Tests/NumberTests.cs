using CodingameProject.Source;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace CodingameProject.Tests
{
    [TestFixture]
    public class NumberTests
    {
        [TestCase(12, 3)]
        [TestCase(23891, 23)]
        [TestCase(1, 1)]
        [TestCase(987987, 48)]
        [Test]
        public void Test_GetSumOfDigits(int input, int expected)
        {
            Assert.That((object)new NumberRepresentation(input).GetSumOfDigits(), (IResolveConstraint)Is.EqualTo((object)expected));
        }

        [TestCase(12, 3)]
        [TestCase(23891, 5)]
        [TestCase(1, 1)]
        [TestCase(987987, 3)]
        [TestCase(99, 9)]
        [Test]
        public void Test_GetSumOfDigitsUntilNine(int input, int expected)
        {
            Assert.That((object)new NumberRepresentation(input).GetSumOfDigitsUntilNine(), (IResolveConstraint)Is.EqualTo((object)expected));
        }
    }
}