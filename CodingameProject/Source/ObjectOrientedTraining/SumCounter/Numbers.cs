namespace CodingameProject.Source.SumCounter
{
    public class Numbers
    {
        private readonly int[] input;

        public Numbers(int[] input)
        {
            this.input = input;
        }

        public int Sum(ISumSelector sumSelector)
        {
            int result = 0;
            foreach (int number in sumSelector.Pick(input))
            {
                result += number;
            }
            return result;
        }
    }
}