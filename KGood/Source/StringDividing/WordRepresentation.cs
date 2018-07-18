using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    public class WordRepresentation
    {
        public WordRepresentation(string word)
        :this(new MaybeString(word))
        {
        }

        public WordRepresentation(MaybeString inputWord)
        {
            Word = inputWord;
        }

        public MaybeString Word { get; }

        public int Length => Word.Length;

        public int GetCountOfLetterGroups()
        {
            var beginningOfGroupOfSameLettersSignalizer = new BeginningOfGroupOfSameLettersSignalizer(Word);
            int countOfGroups = 0;
            for (var i = 0; i < Word.Length; i++)
            {
                if (beginningOfGroupOfSameLettersSignalizer.Signalize(i))
                {
                    countOfGroups++;
                }
            }
            return countOfGroups;
        }

        public MaybeString GetCardinalitySubstring(int countOfDifferentLettersOfResult)
        {
            var alreadyProcessedLetters = new HashSet<char>();
            int endIndexOfFoundGroup = Word.Length;
            for (var i = 0; i < Word.Length; i++)
            {
                alreadyProcessedLetters.Add(Word.LetterAtIndex(i));
                if (alreadyProcessedLetters.Count > countOfDifferentLettersOfResult)
                {
                    endIndexOfFoundGroup = i;
                    break;
                }
            }
            var resultLetterGroup = new WordRepresentation(Word.Substring(0, endIndexOfFoundGroup));
            return resultLetterGroup.Word.GetCountOfUniqueLetters() == countOfDifferentLettersOfResult ? 
                resultLetterGroup.Word : new MaybeString(null);
        }
    }
}