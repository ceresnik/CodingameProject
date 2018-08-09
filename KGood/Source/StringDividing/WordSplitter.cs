using System;
using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    internal class WordSplitter
    {
        private WordRepresentation wordRepresentation;
        private readonly int countOfUniqueLetters;
        private readonly WordParts wordParts;

        public WordSplitter(WordRepresentation wordRepresentation, int countOfUniqueLetters)
        {
            if (countOfUniqueLetters == 0)
            {
                
                throw new ArgumentException("Must be greater than zero.", nameof(countOfUniqueLetters));
            }
            this.wordRepresentation = wordRepresentation;
            this.countOfUniqueLetters = countOfUniqueLetters;
            wordParts = new WordParts();
        }

        private bool IsWordLongEnough => wordRepresentation.CountOfLetterGroups >= countOfUniqueLetters;

        public IList<MaybeString> SplitToParts()
        {
            while (IsWordLongEnough)
            {
                CreateWordPart();
                RemoveBeginningLettersFromWordRepresentation();
            }
            return wordParts.ToListOfMaybeStrings();
        }

        private void CreateWordPart()
        {
            var wordPart = wordRepresentation.GetBeginningLetters(countOfUniqueLetters);
            if (wordPart.IsEmpty == false)
            {
                wordParts.Add(wordPart);
            }
        }

        private void RemoveBeginningLettersFromWordRepresentation()
        {
            //TODO: is it ok to overwrite here my own field?
            wordRepresentation = new WordRepresentation(wordRepresentation.CutOffBeginningLetters());
        }
    }
}