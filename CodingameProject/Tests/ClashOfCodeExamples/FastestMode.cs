using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingameProject.Tests.ClashOfCodeExamples
{
    public class FastestMode
    {
        /// <summary>
        /// Given a number v and a set of digits d.
        /// In the range of numbers from 0 up to but not including v:
        /// 1) Count the numbers that have any of the digits d in their decimal representation.
        /// 2) Count the total number of occurrences of all the digits d in the decimal representations of the numbers.ex: 1999 contains three 9s.
        /// Example: with d = [1, 2]
        /// v=15 => [0 1 2 3 5 6 7 8 9 10 11 12 13 14]
        /// 1) The first number counts the numbers containing 1 or 2:
        /// numbers that contain 1 or 2 = [1, 2, 10, 11, 12, 13, 14] => 7
        /// 2) The second number is the total number of 1s and 2s:
        /// numbers that contain digit 1 or 2 = [1, 2, 10, 11, 12, 13, 14]
        /// => number of 1s and 2s in each = [1, 1, 1, 2, 2, 1, 1] => 9
        /// </summary>
        [TestCase(15, 1, 2, 7, 9)]
        [TestCase(15, 1, 5, 7, 8)]
        [TestCase(20, 1, 2, 12, 14)]
        [TestCase(100, 8, 9, 36, 40)]
        [Test]
        public void SampleContainedInInputNumbers_1(int boundary, int digit1, int digit2, int expectedCountOfNumbers, int expectedCountOfOccurences)
        {
            var inputNumbers = GetInputNumbers(boundary);
            var sampleNumbers = new List<int>{ digit1, digit2};
            int countOfNumbersWithSample = 0;
            int countOfOccurencesOfAllSamples = 0;
            foreach (var inputNumber in inputNumbers)
            {
                string numberAsString = inputNumber.ToString();
                if (numberAsString.Any(x => sampleNumbers.Contains(x - '0')))
                {
                    countOfNumbersWithSample++;
                }
                countOfOccurencesOfAllSamples += numberAsString.Count(x => sampleNumbers.Contains(x - '0'));
            }
            Assert.That(countOfNumbersWithSample, Is.EqualTo(expectedCountOfNumbers));
            Assert.That(countOfOccurencesOfAllSamples, Is.EqualTo(expectedCountOfOccurences));
        }

        [TestCase(100, 100, 190)]
        [Test]
        public void SampleContainedInInputNumbers_2(int boundary, int expectedCountOfNumbers, int expectedCountOfOccurences)
        {
            var inputNumbers = GetInputNumbers(boundary);
            var sampleNumbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            int countOfNumbersWithSample = 0;
            int countOfOccurencesOfAllSamples = 0;
            foreach (var inputNumber in inputNumbers)
            {
                string numberAsString = inputNumber.ToString();
                if (numberAsString.Any(x => sampleNumbers.Contains(x - '0')))
                {
                    countOfNumbersWithSample++;
                }
                countOfOccurencesOfAllSamples += numberAsString.Count(x => sampleNumbers.Contains(x - '0'));
            }
            Assert.That(countOfNumbersWithSample, Is.EqualTo(expectedCountOfNumbers));
            Assert.That(countOfOccurencesOfAllSamples, Is.EqualTo(expectedCountOfOccurences));
        }

        private static List<int> GetInputNumbers(int boundary)
        {
            var numbersFromZero = new List<int>();
            for (int i = 0; i < boundary; i++)
            {
                numbersFromZero.Add(i);
            }
            return numbersFromZero;
        }

        /// <summary>
        /// Number is Lucky in case it contains 6 or 8.
        /// Number is Not Lucky in case it contains both 6 and 8, or none of them.
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <param name="expectedResult"></param>
        [Test]
        [TestCase(1, false)]
        [TestCase(6, true)]
        [TestCase(8, true)]
        [TestCase(12345, false)]
        [TestCase(666, true)]
        [TestCase(888, true)]
        [TestCase(68, false)]
        [TestCase(678, false)]
        [TestCase(578, true)]
        [TestCase(123456789, false)]
        public void IsLucky(int inputNumber, bool expectedResult)
        {
            bool isLucky = DoesNotContainSixOrEight(inputNumber) && ContainsSixOrEight(inputNumber);
            Console.WriteLine(isLucky ? "Lucky" : "Not Lucky");
            Assert.That(isLucky, Is.EqualTo(expectedResult));
        }

        private static bool DoesNotContainSixOrEight(int inputNumber)
        {  
            return (inputNumber.ToString().Contains('6') == false || inputNumber.ToString().Contains('8') == false); 
        }

        private static bool ContainsSixOrEight(int inputNumber)
        {
            return inputNumber.ToString().Contains('6') || inputNumber.ToString().Contains('8');
        }
    }
}