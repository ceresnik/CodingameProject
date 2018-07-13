using System.Collections.Generic;

namespace CodingameProject.Source.ObjectOrientedTraining.SumCounterDemo
{
    public class OddNumbersSelector : ISumSelector
    {
        public int[] Pick(int[] numbers)
        {
            var result = new List<int>();
            foreach (int number in numbers)
            {
                if (number % 2 == 1)
                {
                    result.Add(number);
                }
            }
            return result.ToArray();
        }
    }
}