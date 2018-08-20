using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    public class Word
    {
        private readonly ChainOfSameLettersDistinguisher chainOfSameLettersDistinguisher;
        private readonly MaybeString maybeString;

        public Word(string word)
        :this(new MaybeString(word))
        {
        }

        public Word(MaybeString inputMaybeString)
        {
            maybeString = inputMaybeString;
            chainOfSameLettersDistinguisher = new ChainOfSameLettersDistinguisher(maybeString);
        }

        public int Length => maybeString.Length;

        public int CountOfLetterGroups
        {
            get
            {
                int countOfGroups = 0;
                for (var i = 0; i < maybeString.Length; i++)
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

        public MaybeString CutOffBeginningLetters()
        {
            return maybeString.CutOffBeginningLetters();
        }

        public bool HasEnoughUniqueLetters(int countOfUniqueLetters)
        {
            return maybeString.CountOfUniqueLetters >= countOfUniqueLetters;
        }

        private MaybeString GetBeginningLettersUntilStop(int count, int stopIndex)
        {
            var beginningLetters = maybeString.GetBeginningLettersUntil(stopIndex);
            return beginningLetters.CountOfUniqueLetters == count ? beginningLetters : new MaybeString(null);
        }

        private int FindOutWhereToStop(int countOfDifferentLetters)
        {
            int endIndexOfFoundGroup = maybeString.Length;
            var alreadyProcessedLetters = new HashSet<char>();
            for (var i = 0; i < maybeString.Length; i++)
            {
                alreadyProcessedLetters.Add(maybeString.LetterAt(i));
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