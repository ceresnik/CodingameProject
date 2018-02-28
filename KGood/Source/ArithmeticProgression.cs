namespace KGood.Source
{
    internal static class ArithmeticProgression
    {
        public static int Calculate(int startingNumber, int difference, int countOfNumbers)
        {
            int multiplicator = startingNumber;
            int result = startingNumber;
            for (int i = 1; i < countOfNumbers; i++)
            {
                multiplicator += difference;
                result += multiplicator;
            }
            return result;
        }
    }
}