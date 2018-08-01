namespace KGood.Source.Extensions
{
    internal static class IntegerExtensions
    {
        public static bool IsWithin(this int input, string word)
        {
            return word.Length > input;
        }
    }
}