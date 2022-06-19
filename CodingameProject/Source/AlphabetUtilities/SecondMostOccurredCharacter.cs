using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.AlphabetUtilities
{
    /// <summary>
    /// Returns frequency (how many times occurs) of the character, which is second-most occurred in the given string.
    /// In case given string is not valid string or does not contain at least two different characters,
    /// returns <see cref="UndefinedCount"/>
    /// </summary>
    internal static class SecondMostOccurredCharacter
    {
        public static ICount Get(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new UndefinedCount();
            }
            var countOfOccurrencesByLetter = new Dictionary<char, int>();
            foreach (char c in input.Distinct())
            {
                countOfOccurrencesByLetter.Add(c, input.Count(x => x == c));
            }

            var sortedListOfOccurrences = countOfOccurrencesByLetter.OrderByDescending(x => x.Value).Select(y => y.Value).ToList();
            ICount result = new UndefinedCount();
            if (sortedListOfOccurrences.Count > 1)
            {
                if (sortedListOfOccurrences[0] != sortedListOfOccurrences[1])
                {
                    result = new DefinedCount(sortedListOfOccurrences[1]);
                }
            }
            return result;
        }
    }

    interface ICount
    {
        int Count { get; }
    }

    class UndefinedCount : ICount
    {
        public int Count => -1;

        public override bool Equals(object obj)
        {
            var item = obj as UndefinedCount;
            if (item == null)
            {
                return false;
            }

            return this.Count == item.Count;
        }

        public override int GetHashCode()
        {
            return this.Count.GetHashCode();
        }
    }

    class DefinedCount : ICount
    {
        public DefinedCount(int count)
        {
            Count = count;
        }
        public int Count { get; }

        public override bool Equals(object obj)
        {
            var item = obj as DefinedCount;
            if (item == null)
            {
                return false;
            }

            return this.Count == item.Count;
        }

        public override int GetHashCode()
        {
            return this.Count.GetHashCode();
        }
    }
}