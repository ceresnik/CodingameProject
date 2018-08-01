using System;
using System.Linq;
using KGood.Source.PrimesGeneration;
using NUnit.Framework;

namespace KGood.Tests.PrimesGeneration
{
    [TestFixture]
    public class PrimesGenerationTests
    {

        [Test]
        [TestCase(10, new[] { 2, 3, 5, 7 })]
        [TestCase(20, new[] { 2, 3, 5, 7, 11, 13, 17, 19 })]
        [TestCase(100, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
        public void Test_GeneratePrimesOld(int limitNumber, int[] expected)
        {
            var result = GeneratePrimesOld.generatePrimes(limitNumber);
            Assert.That(result.Except(expected).Any(), Is.False, 
                "There is more numbers in the result than expected.");
            Assert.That(expected.Except(result).Any(), Is.False, 
                "There is less numbers in the result than expected.");
        }

        [Test]
        [TestCase(0, new int[0])]
        [TestCase(1, new int[0])]
        [TestCase(2, new[] { 2 })]
        [TestCase(10, new[] { 2, 3, 5, 7 })]
        [TestCase(20, new[] { 2, 3, 5, 7, 11, 13, 17, 19 })]
        [TestCase(100, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
        public void Test_GeneratePrimesRefactoredByMe(int limitNumber, int[] expected)
        {
            var result = PrimesGenerator.generate(limitNumber);
            Assert.That(result.Except(expected).Any(), Is.False, 
                $"There is more numbers in the result ({result.Length}) than expected ({expected.Length}).");
            Assert.That(expected.Except(result).Any(), Is.False, 
                $"There is less numbers in the result ({result.Length}) than expected  ({expected.Length}).");
        }

        [Test]
        [TestCase(0, new int[0])]
        [TestCase(1, new int[0])]
        [TestCase(2, new[] { 2 })]
        [TestCase(10, new[] { 2, 3, 5, 7 })]
        [TestCase(20, new[] { 2, 3, 5, 7, 11, 13, 17, 19 })]
        [TestCase(100, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
        public void Test_GeneratePrimesRefactoredByCleanCode(int limitNumber, int[] expected)
        {
            var result = PrimesGeneratorRefactored.GeneratePrimes(limitNumber);
            Assert.That(result.Except(expected).Any(), Is.False, 
                $"There is more numbers in the result ({result.Length}) than expected ({expected.Length}). {Environment.NewLine}" +
                $"Result: {string.Join(", ", result)}. {Environment.NewLine} " +
                $"Expected: {string.Join(", ", expected)}.");
            Assert.That(expected.Except(result).Any(), Is.False, 
                $"There is less numbers in the result ({result.Length}) than expected  ({expected.Length}).{Environment.NewLine}" +
                $"Result: {string.Join(", ", result)}. {Environment.NewLine} " +
                $"Expected: {string.Join(", ", expected)}.");
        }
    }
}