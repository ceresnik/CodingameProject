using System;
using System.Collections.Generic;
using System.Linq;

namespace KGood.Source.StringDividing
{
    public class StringDivider
    {
        private WordRepresentation wordRepresentation;
        private int CountOfDifferentLettersOfResult { get; }

        public StringDivider(string word, int countOfDifferentLettersOfResult)
        :this(new MaybeString(word), countOfDifferentLettersOfResult){
        }

        public StringDivider(MaybeString inputWord, int countOfDifferentLettersOfResult)
        {
            wordRepresentation = new WordRepresentation(inputWord);
            if (wordRepresentation.Word.CountOfUniqueLetters < countOfDifferentLettersOfResult)
            {
                throw new ArgumentException("Count of different letters must be less or equal to " +
                                            "count of unique letters in given word!");
            }
            CountOfDifferentLettersOfResult = countOfDifferentLettersOfResult;
        }

        public IList<MaybeString> Divide()
        {
            if (wordRepresentation.CountOfUniqueLetters == CountOfDifferentLettersOfResult)
            {
                return new List<MaybeString> { wordRepresentation.Word };
            }
            var result = new List<MaybeString>();
            int countOfCycles = GetCountOfCycles();
            for (int i = 0; i < countOfCycles; i++)
            {
                if (wordRepresentation.Length >= CountOfDifferentLettersOfResult)
                {
                    var foundSubstring = wordRepresentation.GetBeginningLetters(CountOfDifferentLettersOfResult);
                    result.Add(foundSubstring);
                    wordRepresentation = new WordRepresentation(wordRepresentation.Word.CutOffBeginningLetters());
                }
            }
            return result;
        }

        private int GetCountOfCycles()
        {
            return wordRepresentation.CountOfLetterGroups - CountOfDifferentLettersOfResult + 1;
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