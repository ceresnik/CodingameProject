using System;
using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    public class WordSplitter
    {
        private Word word;
        private int countOfUniqueLetters;
        private readonly WordParts wordParts;

        public WordSplitter()
        {
            wordParts = new WordParts();
        }

        private bool IsWordLongEnough => word.GetCountOfLetterGroups() >= countOfUniqueLetters;

        public IList<MaybeString> SplitToParts(Word word1, int inputCountOfUniqueLetters)
        {
            if (inputCountOfUniqueLetters == 0)
            {

                throw new ArgumentException("Must be greater than zero.", nameof(countOfUniqueLetters));
            }
            word = word1;
            countOfUniqueLetters = inputCountOfUniqueLetters;
            return SplitToParts();
        }

        private IList<MaybeString> SplitToParts()
        {
            while (IsWordLongEnough)
            {
                CreateWordPart();
                RemoveBeginningLetters();
            }
            return wordParts.ToListOfMaybeStrings();
        }

        private void CreateWordPart()
        {
            var wordPart = word.GetBeginningLetters(countOfUniqueLetters);
            if (wordPart.IsEmpty == false)
            {
                wordParts.Add(wordPart);
            }
        }

        private void RemoveBeginningLetters()
        {
            //TODO: is it ok to overwrite here my own field?
            word = new Word(word.CutOffBeginningLetters());
        }
    }
}