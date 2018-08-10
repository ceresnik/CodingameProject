using System;
using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    internal class WordSplitter
    {
        private Word word;
        private int countOfUniqueLetters;
        private readonly WordParts wordParts;

        public WordSplitter()
        {
            wordParts = new WordParts();
        }

        private bool IsWordLongEnough => word.CountOfLetterGroups >= countOfUniqueLetters;

        public IList<MaybeString> SplitToParts()
        {
            while (IsWordLongEnough)
            {
                CreateWordPart();
                RemoveBeginningLettersFromWordRepresentation();
            }
            return wordParts.ToListOfMaybeStrings();
        }

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

        private void CreateWordPart()
        {
            var wordPart = word.GetBeginningLetters(countOfUniqueLetters);
            if (wordPart.IsEmpty == false)
            {
                wordParts.Add(wordPart);
            }
        }

        private void RemoveBeginningLettersFromWordRepresentation()
        {
            //TODO: is it ok to overwrite here my own field?
            word = new Word(word.CutOffBeginningLetters());
        }
    }
}