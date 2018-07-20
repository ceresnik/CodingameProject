using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    internal class WordParts
    {
        private readonly IList<MaybeString> wordParts;

        public WordParts()
        {
            wordParts = new List<MaybeString>();
        }

        public void Add(MaybeString word)
        {
            wordParts.Add(word);
        }

        public IList<MaybeString> ToListOfMaybeStrings()
        {
            return wordParts;
        }
    }
}