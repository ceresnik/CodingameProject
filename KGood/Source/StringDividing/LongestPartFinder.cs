using System.Linq;

namespace KGood.Source.StringDividing
{
    public class LongestPartFinder
    {
        private readonly StringDivider stringDivider;

        public LongestPartFinder()
        {
            stringDivider = new StringDivider();
        }

        internal long GetLengthOfLongestSubstring(string word, int countOfUniqueLetters)
        {
            return DivideAndOrder(word, countOfUniqueLetters).First().Length;
        }

        public IOrderedEnumerable<MaybeString> DivideAndOrder(string word, int countOfUniqueLetters)
        {
            return stringDivider.Divide(word, countOfUniqueLetters).OrderByDescending(x => x.Length);
        }
    }
}