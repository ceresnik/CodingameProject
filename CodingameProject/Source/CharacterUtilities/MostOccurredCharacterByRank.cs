using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.CharacterUtilities
{
    /// <summary>
    /// Returns frequency (how many times occurs) of the character, which is rank-most occurred (one based index) in the given
    /// string.
    /// In case given string is not valid string or does not contain at least two different characters,
    /// returns <see cref="UndefinedCount"/>.
    /// </summary>
    internal class MostOccurredCharacterByRank
    {
        private readonly int myRank;

        public MostOccurredCharacterByRank(): this(2)
        {
        }

        internal MostOccurredCharacterByRank(int rank)
        {
            myRank = rank;
        }

        public ICount Get(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new UndefinedCount();
            }
            var orderedFrequenciesByCharacter = OrderFrequenciesByCharacterDescending(input);
            var onlyOrderedFrequencies = GetFrequencies(orderedFrequenciesByCharacter);
            ICount result = new UndefinedCount();
            if (IsRankWithinRange(onlyOrderedFrequencies))
            {
                if (onlyOrderedFrequencies[0] != onlyOrderedFrequencies[myRank - 1])
                {
                    result = new DefinedCount(onlyOrderedFrequencies[myRank - 1]);
                }
            }
            return result;
        }

        private bool IsRankWithinRange(List<int> frequencies)
        {
            return frequencies.Count >= myRank;
        }

        private static IEnumerable<KeyValuePair<char, int>> OrderFrequenciesByCharacterDescending(string input)
        {
            var frequencyByCharacter = new Dictionary<char, int>();
            foreach (char c in input.Distinct())
            {
                frequencyByCharacter.Add(c, input.Count(x => x == c));
            }
            return frequencyByCharacter.OrderByDescending(x => x.Value);
        }

        private static List<int> GetFrequencies(IEnumerable<KeyValuePair<char, int>> frequenciesOrderedDescending)
        {
            var charactersArrangedByFrequency = frequenciesOrderedDescending.Select(y => y.Value).ToList();
            return charactersArrangedByFrequency;
        }
    }
}