using System.Linq;

namespace KGood.Source.StringDividing
{
    public class LongestPartFinder
    {
        private readonly StringDivider stringDivider;

        public LongestPartFinder(string word, int countOfUniqueLetters)
        {
            stringDivider = new StringDivider(word, countOfUniqueLetters);
        }

        public long GetLengthOfLongestSubstring()
        {
            return DivideAndOrder().First().Length;
        }

        public IOrderedEnumerable<MaybeString> DivideAndOrder()
        {
            return stringDivider.Divide().OrderByDescending(x => x.Length);
        }
    }
}