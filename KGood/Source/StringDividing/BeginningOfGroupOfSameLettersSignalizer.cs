using System;

namespace KGood.Source.StringDividing
{
    public class BeginningOfGroupOfSameLettersSignalizer
    {
        public BeginningOfGroupOfSameLettersSignalizer(string inputWord)
        :this(new MaybeString(inputWord))
        {
        }

        public BeginningOfGroupOfSameLettersSignalizer(MaybeString inputWord)
        {
            Word = inputWord;
        }

        private MaybeString Word { get; }

        public bool Signalize(int index)
        {
            if (index >= Word.Length)
            {
                throw new ArgumentException("index");
            }
            if (index == 0)
            {
                return true;
            }
            if (Word.LetterAtIndex(index) == Word.LetterAtIndex(index - 1))
            {
                return false;
            }
            return true;
        }
    }
}