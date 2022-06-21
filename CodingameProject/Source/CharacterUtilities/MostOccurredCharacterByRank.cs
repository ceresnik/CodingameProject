using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.CharacterUtilities
{
    /// <summary>
    /// Returns frequency (how many times occurs) of the character, which is rank-most occurred (one based index) in the given
    /// string.
    /// In case given string is not valid string returns <see cref="UndefinedCount"/>.
    /// In case there is less unique characters than the rank, returns <see cref="UndefinedCount"/>.
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
            if (IsRankInBoundsOfUniqueFrequencies(onlyOrderedFrequencies))
            {
                result = new DefinedCount(onlyOrderedFrequencies[myRank - 1]);
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

        private static List<int> GetFrequencies(IEnumerable<KeyValuePair<char, int>> frequenciesByCharacter)
        {
            var frequencies = frequenciesByCharacter.Select(y => y.Value).ToList();
            return frequencies;
        }

        private bool IsRankInBoundsOfUniqueFrequencies(List<int> frequencies)
        {
            int countOfUniqueFrequencies = frequencies.Distinct().Count();
            return myRank <= countOfUniqueFrequencies;
        }
    }
}