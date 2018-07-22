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
            if (Word.IsLetterSameAsPrevious(index))
            {
                return false;
            }
            return true;
        }
    }
}