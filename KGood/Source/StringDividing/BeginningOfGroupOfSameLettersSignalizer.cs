/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2017. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;

namespace KGood.Source.StringDividing
{
    public class BeginningOfGroupOfSameLettersSignalizer
    {
        public BeginningOfGroupOfSameLettersSignalizer(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException("word");
            }
            Word = word;
        }

        public string Word { get; private set; }

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
            if (Word[index] == Word[index - 1])
            {
                return false;
            }
            return true;
        }
    }
}