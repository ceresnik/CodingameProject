using System;

namespace KGood.Source.StringDividing
{
    public class ChainOfSameLettersDistinguisher
    {
        public ChainOfSameLettersDistinguisher(string inputWord)
        :this(new MaybeString(inputWord))
        {
        }

        public ChainOfSameLettersDistinguisher(MaybeString inputWord)
        {
            Word = inputWord;
        }

        private MaybeString Word { get; }

        public bool LetterChanged(int index)
        {
            if (index >= Word.Length)
            {
                throw new ArgumentException("index");
            }
            if (index == 0)
            {
                return true;
            }
            if (Word[index] == Word[index - 1])
            {
                return false;
            }
            return true;
        }
    }
}