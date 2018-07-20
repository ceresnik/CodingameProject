﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace KGood.Source.StringDividing
{
    public class StringDivider
    {
        private readonly WordRepresentation wordRepresentation;
        private int InputCountOfUniqueLetters { get; }

        public StringDivider(string inputWord, int inputCountOfUniqueLetters)
        :this(new WordRepresentation(new MaybeString(inputWord)), inputCountOfUniqueLetters){
        }

        private StringDivider(WordRepresentation inputWord, int inputCountOfUniqueLetters)
        {
            wordRepresentation = inputWord;
            if (wordRepresentation.CountOfUniqueLetters < inputCountOfUniqueLetters)
            {
                throw new ArgumentException("Count of different letters can not be greater than " +
                                            "count of unique letters in given word!");
            }
            InputCountOfUniqueLetters = inputCountOfUniqueLetters;
        }

        public IList<MaybeString> Divide()
        {
            if (wordRepresentation.CountOfUniqueLetters == InputCountOfUniqueLetters)
            {
                return new List<MaybeString> { wordRepresentation.Word };
            }
            var wordSplitter = new WordSplitter(wordRepresentation, InputCountOfUniqueLetters);
            return wordSplitter.SplitToParts().ToListOfMaybeStrings();
        }

        public long GetLengthOfLongestSubstring()
        {
            return DivideAndOrder().First().Length;
        }

        public IOrderedEnumerable<MaybeString> DivideAndOrder()
        {
            return Divide().OrderByDescending(x => x.Length);
        }
    }
}