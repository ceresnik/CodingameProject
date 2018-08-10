using System;
using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    public class StringDivider
    {
        private readonly IWordFactory wordFactory;
        private Word word;
        private int inputCountOfUniqueLetters;

        public StringDivider()
        : this(new WordFactory()){
            
        }
        public StringDivider(IWordFactory wordFactory)
        {
            this.wordFactory = wordFactory;
        }

        internal IList<MaybeString> Divide(string inputWord, int countOfUniqueLetters)
        {
            word = wordFactory.Create(inputWord);
            if (word.CountOfUniqueLetters < countOfUniqueLetters)
            {
                throw new ArgumentException("Requested count of unique letters can not be greater than " +
                                            "count of unique letters given word consists of!");
            }
            inputCountOfUniqueLetters = countOfUniqueLetters;
            var wordSplitter = new WordSplitter();
            return wordSplitter.SplitToParts(word, inputCountOfUniqueLetters);
        }
    }
}