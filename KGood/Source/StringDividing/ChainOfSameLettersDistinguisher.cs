using System;

namespace KGood.Source.StringDividing
{
    public class ChainOfSameLettersDistinguisher
    {
        private readonly MaybeString maybeString;

        public ChainOfSameLettersDistinguisher(string inputWord)
        :this(new MaybeString(inputWord))
        {
        }

        public ChainOfSameLettersDistinguisher(MaybeString inputWord)
        {
            maybeString = inputWord;
        }

        public bool LetterChanged(int index)
        {
            if (index >= maybeString.Length)
            {
                throw new ArgumentException("index");
            }
            if (index == 0)
            {
                return true;
            }
            if (maybeString.IsLetterSameAsPrevious(index))
            {
                return false;
            }
            return true;
        }
    }
}