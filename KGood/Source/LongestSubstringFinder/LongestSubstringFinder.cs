namespace KGood.Source.LongestSubstringFinder
{
    internal class LongestSubstringFinder
    {
        public WordRepresentation WordRepresentation { get; }

        public LongestSubstringFinder(string word, int countOfCharacters)
            :this(new WordRepresentation(word, countOfCharacters))
        {
        }

        public LongestSubstringFinder(WordRepresentation wordRepresentation)
        {
            WordRepresentation = wordRepresentation;
        }

        public string FindString()
        {
            var sameLetterGroups = WordRepresentation.GroupToSameLetterGroups();
            return WordRepresentation.JoinGroupsAndReturnLongestOne(sameLetterGroups);
        }
    }
}