using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.SumCounterDemo
{
    public class SumCounter
    {
        private readonly int[] numbers;

        public SumCounter(int[] input)
        {
            numbers = input;
        }

        public int Count(ISumSelector sumSelector)
        {
            return sumSelector.Pick(numbers).Sum();
        }

        public int Count()
        {
            return Count(new EachNumberSelector());
        }
    }
}