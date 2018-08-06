using System.Collections.Generic;
using System.Linq;

namespace KGood.Source.Extensions
{
    internal static class StringExtensions
    {
        public static bool IsIndexWithin(this string input, int index)
        {
            return input.Length > index;
        }

        public static IEnumerable<string> SplitToChunksOf(this string input, int chunkSize)
        {
            var chunks = Enumerable.Range(0, input.Length / chunkSize)
                .Select(x => input.Substring(x * chunkSize,chunkSize));
            return chunks;
        }
    }
}