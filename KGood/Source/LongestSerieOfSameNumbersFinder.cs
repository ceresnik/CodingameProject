namespace KGood.Source
{
    internal static class LongestSerieOfSameNumbersFinder
    {
        public static string Find(string input)
        {
            char previousChar = input[0];
            string currentResult = input[0].ToString();
            string bestResult = currentResult;
            for (int i = 1; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (previousChar == currentChar)
                {
                    currentResult += currentChar;
                    if (bestResult.Length < currentResult.Length)
                    {
                        bestResult = currentResult;
                    }
                }
                else
                {
                    previousChar = currentChar;
                    currentResult = currentChar.ToString();
                }
            }
            return bestResult;
        }
    }
}