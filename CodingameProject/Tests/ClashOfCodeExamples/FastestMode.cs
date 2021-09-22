using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingameProject.Tests.ClashOfCodeExamples
{
    public class FastestMode
    {
        [Test]
        public void SampleContainedInInputNumbers()
        {
            var inputNumbers = new List<int>{ 0, 1, 2, 3, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            var sampleNumbers = new List<int>{ 1, 2};
            int countOfNumbersWithSample = 0;
            foreach (var inputNumber in inputNumbers)
            {
                string numberAsString = inputNumber.ToString();
                //if (numberAsString.Any(x => sampleNumbers.Contains((int)x)))
                //{
                //    countOfNumbersWithSample++;
                //}

                foreach (int sampleNumber in sampleNumbers)
                {
                    if (numberAsString.Contains(sampleNumber.ToString()))
                    {
                        countOfNumbersWithSample++;
                        break;
                    }
                }
            }
            Assert.That(countOfNumbersWithSample, Is.EqualTo(7));
        }


    }
}