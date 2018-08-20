using System;
using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    public class StringDivider
    {
        private readonly IWordFactory wordFactory;
        private readonly WordSplitter wordSplitter;

        public StringDivider()
        : this(new WordFactory(), new WordSplitter()){
            
        }
        public StringDivider(IWordFactory wordFactory, WordSplitter wordSplitter)
        {
            this.wordFactory = wordFactory;
            this.wordSplitter = wordSplitter;
        }

        internal IList<MaybeString> Divide(string inputWord, int countOfUniqueLetters)
        {
            var word = wordFactory.Create(inputWord);
            if (word.HasEnoughUniqueLetters(countOfUniqueLetters) == false)
            {
                throw new ArgumentException("Requested count of unique letters can not be greater than " +
                                            "count of unique letters given word consists of!");
            }
            return wordSplitter.SplitToParts(word, countOfUniqueLetters);
        }
    }
}