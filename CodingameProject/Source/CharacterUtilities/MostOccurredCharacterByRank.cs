using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.CharacterUtilities
{
    /// <summary>
    /// Returns frequency (how many times occurs) of the character, which is second-most occurred in the given string.
    /// In case given string is not valid string or does not contain at least two different characters,
    /// returns <see cref="UndefinedCount"/>
    /// </summary>
    internal class MostOccurredCharacterByRank
    {
        private readonly int myRank;

        public MostOccurredCharacterByRank()
        : this(1)
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
            var onlyFrequencies = GetFrequencies(orderedFrequenciesByCharacter);
            ICount result = new UndefinedCount();
            if (onlyFrequencies.Count > myRank)
            {
                if (onlyFrequencies[0] != onlyFrequencies[myRank])
                {
                    result = new DefinedCount(onlyFrequencies[myRank]);
                }
            }
            return result;
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