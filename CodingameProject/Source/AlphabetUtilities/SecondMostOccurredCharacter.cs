using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.AlphabetUtilities
{
    /// <summary>
    /// Returns frequency (how many times occurs) of the character, which is second-most occurred in the given string.
    /// </summary>
    internal static class SecondMostOccurredCharacter
    {
        public static int Get(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return -1;
            }
            var countOfOccurrencesByLetter = new Dictionary<char, int>();
            foreach (char c in input.Distinct())
            {
                countOfOccurrencesByLetter.Add(c, input.Count(x => x == c));
            }

            var sortedListOfOccurrences = countOfOccurrencesByLetter.OrderByDescending(x => x.Value).Select(y => y.Value).ToList();
            int result = - 1;
            if (sortedListOfOccurrences.Count > 1)
            {
                if (sortedListOfOccurrences[0] != sortedListOfOccurrences[1])
                {
                    result = sortedListOfOccurrences[1];
                }
            }
            return result;
        }
    }
}