﻿namespace KGood.Source.StringDividing
{
    internal class WordSplitter
    {
        private WordRepresentation wordRepresentation;
        private readonly int countOfUniqueLetters;
        private readonly WordParts wordParts;

        public WordSplitter(WordRepresentation wordRepresentation, int countOfUniqueLetters)
        {
            this.wordRepresentation = wordRepresentation;
            this.countOfUniqueLetters = countOfUniqueLetters;
            wordParts = new WordParts();
        }

        private bool IsWordLongEnough => wordRepresentation.CountOfLetterGroups >= countOfUniqueLetters;

        public WordParts SplitToParts()
        {
            while (IsWordLongEnough)
            {
                AddBeginningLettersToWordParts();
                RemoveBeginningLettersFromWordRepresentation();
            }
            return wordParts;
        }

        private void AddBeginningLettersToWordParts()
        {
            wordParts.Add(wordRepresentation.GetBeginningLetters(countOfUniqueLetters));
        }

        private void RemoveBeginningLettersFromWordRepresentation()
        {
            wordRepresentation = new WordRepresentation(wordRepresentation.Word.CutOffBeginningLetters());
        }
    }
}