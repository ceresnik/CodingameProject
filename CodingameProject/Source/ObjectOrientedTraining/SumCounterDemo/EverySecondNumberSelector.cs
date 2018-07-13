using System.Collections.Generic;

namespace CodingameProject.Source.ObjectOrientedTraining.SumCounterDemo
{
    public class EverySecondNumberSelector : ISumSelector
    {
        public int[] Pick(int[] numbers)
        {
            var result = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result.Add(numbers[i]);
                }
            }
            return result.ToArray();
        }
    }
}