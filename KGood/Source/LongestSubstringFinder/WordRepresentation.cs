/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Linq;

namespace KGood.Source.LongestSubstringFinder
{
    internal class WordRepresentation
    {
        private readonly string word;
        private readonly int countOfDistinctLetters;

        public WordRepresentation(string word, int countOfDistinctLetters)
        {
            if (word == null)
            {
                throw new ArgumentNullException();
            }
            if (word == string.Empty)
            {
                throw new ArgumentException(word);
            }
            if (word.Length < countOfDistinctLetters)
            {
                throw new ArgumentException("Count of distinct letters must be less or equal to word length.");
            }
            this.word = word;
            this.countOfDistinctLetters = countOfDistinctLetters;
        }

        internal string JoinGroupsAndReturnLongestOne(IList<string> sameLetterGroups)
        {
            IList<string> groupedLettersList = new List<string>();
            string buffer = "";
            int counter = 0;
            foreach (string group in sameLetterGroups)
            {
                counter++;
                buffer += group;
                if (counter == countOfDistinctLetters)
                {
                    groupedLettersList.Add(buffer);
                    counter = 0;
                }
            }
            return groupedLettersList.OrderBy(s => s.Length).First();
        }

        internal IList<string> GroupToSameLetterGroups()
        {
            char previousChar = word[0];
            string currentResult = word[0].ToString();
            string bestResult = currentResult;
            IList<string> sameLetterGroups = new List<string>();
            for (int i = 1; i < word.Length; i++)
            {
                char currentChar = word[i];
                if (previousChar == currentChar)
                {
                    currentResult += currentChar;
                    if (bestResult.Length < currentResult.Length)
                    {
                        bestResult = currentResult;
                    }
                }
                else
                {
                    previousChar = currentChar;
                    sameLetterGroups.Add(currentResult);
                    currentResult = currentChar.ToString();
                }
            }
            sameLetterGroups.Add(currentResult);
            return sameLetterGroups;
        }
    }
}