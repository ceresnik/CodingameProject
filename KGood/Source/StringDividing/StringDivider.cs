/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2017. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Linq;

namespace KGood.Source.StringDividing
{
    public class StringDivider
    {
        public string Word { get; }
        public int Cardinality { get; }

        public StringDivider(string word, int cardinality)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException(word);
            }
            var countOfUniqueLetters = GetCountOfUniqueLetters(word);
            if (countOfUniqueLetters < cardinality)
            {
                throw new ArgumentException("Cardinality must be less or equal to count of unique letters!");
            }
            Word = word;
            Cardinality = cardinality;
        }

        public IList<string> Divide()
        {
            string wordToProcess = Word;
            int countOfUniqueLetters = GetCountOfUniqueLetters(wordToProcess);
            if (countOfUniqueLetters == Cardinality)
            {
                return new List<string>{Word};
            }
            var result = new List<string>();
            int countOfGroupsOfSameLetter = GetCountOfLetterGroups(wordToProcess);
            int countOfCycles = countOfGroupsOfSameLetter - Cardinality + 1;
            for (int i = 0; i < countOfCycles; i++)
            {
                if (wordToProcess.Length >= Cardinality)
                {
                    var foundSubstring = GetCardinalitySubstring(wordToProcess);
                    if (foundSubstring == null)
                    {
                        break;
                    }
                    result.Add(foundSubstring);
                    wordToProcess = CutOffBeginningLetters(wordToProcess);
                }
            }
            return result;
        }

        private int GetCountOfLetterGroups(string word)
        {
            var beginningOfGroupOfSameLettersSignalizer = new BeginningOfGroupOfSameLettersSignalizer(word);
            int countOfGroups = 0;
            for (var i = 0; i < word.Length; i++)
            {
                if (beginningOfGroupOfSameLettersSignalizer.Signalize(i))
                {
                    countOfGroups++;
                }
            }
            return countOfGroups;
        }

        public long GetLengthOfLongestSubstring()
        {
            return DivideAndOrder().First().Length;
        }

        public IOrderedEnumerable<string> DivideAndOrder()
        {
            return Divide().OrderByDescending(x => x.Length);
        }

        private static int GetCountOfUniqueLetters(string word)
        {
            var uniqueLetters = new HashSet<char>();
            foreach (char c in word)
            {
                uniqueLetters.Add(c);
            }
            return uniqueLetters.Count;
        }

        private static string CutOffBeginningLetters(string word)
        {
            char firstLetter = word[0];
            do
            {
                word = word.Remove(0, 1);                
            } while (word.Length > 0 && word[0] == firstLetter);
            return word;
        }

        private string GetCardinalitySubstring(string word)
        {
            var processedLetters = new HashSet<char>();
            int lengthOfSubstring = word.Length;
            for (var i = 0; i < word.Length; i++)
            {
                processedLetters.Add(word[i]);
                if (processedLetters.Count > Cardinality)
                {
                    lengthOfSubstring = i;
                    break;
                }
            }
            var result = word.Substring(0, lengthOfSubstring);
            return GetCountOfUniqueLetters(result) == Cardinality ? result : null;
        }
    }
}