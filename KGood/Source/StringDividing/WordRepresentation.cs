using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    public class WordRepresentation
    {
        private readonly ChainOfSameLettersDistinguisher chainOfSameLettersDistinguisher;
        private readonly MaybeString word;

        public WordRepresentation(string word)
        :this(new MaybeString(word))
        {
        }

        public WordRepresentation(MaybeString inputWord)
        {
            word = inputWord;
            chainOfSameLettersDistinguisher = new ChainOfSameLettersDistinguisher(word);
        }

        public int Length => word.Length;

        public int CountOfUniqueLetters => word.CountOfUniqueLetters;

        public int CountOfLetterGroups
        {
            get
            {
                int countOfGroups = 0;
                for (var i = 0; i < word.Length; i++)
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
            return word.CutOffBeginningLetters();
        }

        private MaybeString GetBeginningLettersUntilStop(int count, int stopIndex)
        {
            var beginningLetters = word.GetBeginningLettersUntil(stopIndex);
            return beginningLetters.CountOfUniqueLetters == count ? beginningLetters : new MaybeString(null);
        }

        private int FindOutWhereToStop(int countOfDifferentLetters)
        {
            int endIndexOfFoundGroup = word.Length;
            var alreadyProcessedLetters = new HashSet<char>();
            for (var i = 0; i < word.Length; i++)
            {
                alreadyProcessedLetters.Add(word[i]);
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