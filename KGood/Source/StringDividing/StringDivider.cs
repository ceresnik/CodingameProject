using System;
using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    public class StringDivider
    {
        private readonly WordRepresentation wordRepresentation;
        private readonly int inputCountOfUniqueLetters;

        public StringDivider(string inputWord, int inputCountOfUniqueLetters)
        :this(new WordRepresentation(new MaybeString(inputWord)), inputCountOfUniqueLetters)
        {
        }

        private StringDivider(WordRepresentation inputWord, int inputCountOfUniqueLetters)
        {
            wordRepresentation = inputWord;
            if (wordRepresentation.CountOfUniqueLetters < inputCountOfUniqueLetters)
            {
                throw new ArgumentException("Count of different letters can not be greater than " +
                                            "count of unique letters in given word!");
            }
            this.inputCountOfUniqueLetters = inputCountOfUniqueLetters;
        }

        public IList<MaybeString> Divide()
        {
            var wordSplitter = new WordSplitter(wordRepresentation, inputCountOfUniqueLetters);
            return wordSplitter.SplitToParts();
        }
    }
}