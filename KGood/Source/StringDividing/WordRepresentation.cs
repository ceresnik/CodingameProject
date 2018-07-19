using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    public class WordRepresentation
    {
        private readonly ChainOfSameLettersDistinguisher chainOfSameLettersDistinguisher;

        public WordRepresentation(string word)
        :this(new MaybeString(word))
        {
        }

        public WordRepresentation(MaybeString inputWord)
        {
            Word = inputWord;
            chainOfSameLettersDistinguisher = new ChainOfSameLettersDistinguisher(Word);
        }

        public MaybeString Word { get; }

        public int Length => Word.Length;

        public int CountOfUniqueLetters => Word.CountOfUniqueLetters;

        public int CountOfLetterGroups
        {
            get
            {
                int countOfGroups = 0;
                for (var i = 0; i < Word.Length; i++)
                {
                    if (chainOfSameLettersDistinguisher.LetterChanged(i))
                    {
                        countOfGroups++;
                    }
                }
                return countOfGroups;
            }
        }

        public MaybeString GetBeginningLetters(int count)
        {
            var stopIndex = FindOutWhereToStop(count);
            return GetBeginningLettersUntilStop(count, stopIndex);
        }

        private MaybeString GetBeginningLettersUntilStop(int count, int stopIndex)
        {
            var beginningLetters = Word.GetBeginningLettersUntil(stopIndex);
            return beginningLetters.CountOfUniqueLetters == count ? beginningLetters : new MaybeString(null);
        }

        private int FindOutWhereToStop(int countOfDifferentLetters)
        {
            int endIndexOfFoundGroup = Word.Length;
            var alreadyProcessedLetters = new HashSet<char>();
            for (var i = 0; i < Word.Length; i++)
            {
                alreadyProcessedLetters.Add(Word[i]);
                if (alreadyProcessedLetters.Count > countOfDifferentLetters)
                {
                    endIndexOfFoundGroup = i;
                    break;
                }
            }
            return endIndexOfFoundGroup;
        }
    }
}