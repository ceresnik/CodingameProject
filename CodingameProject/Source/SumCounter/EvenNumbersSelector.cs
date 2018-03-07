using System.Collections.Generic;

namespace CodingameProject.Source.SumCounter
{
    public class EvenNumbersSelector : ISumSelector
    {
        private readonly bool evenNumbersOnly;

        public EvenNumbersSelector(bool evenNumbersOnly)
        {
            this.evenNumbersOnly = evenNumbersOnly;
        }

        public int[] Pick(int[] numbers)
        {
            var result = new List<int>();
            foreach (int number in numbers)
            {
                if (evenNumbersOnly == false || number % 2 == 0)
                {
                    result.Add(number);
                }
            }
            return result.ToArray();
        }
    }
}