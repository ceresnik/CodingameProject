namespace KGood.Source.Extensions
{
    internal static class StringExtensions
    {
        public static bool IsIndexWithin(this string input, int index)
        {
            return input.Length > index;
        }
    }
}