using System;
using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    public class MaybeString
    {
        private readonly string word;

        public MaybeString(string word)
        {
            this.word = String.IsNullOrEmpty(word) ? "" : word;
        }

        public char this[int index] => word[index];

        public int Length => word.Length;

        public int CountOfUniqueLetters
        {
            get
            {
                var uniqueLetters = new HashSet<char>();
                foreach (char c in word)
                {
                    uniqueLetters.Add(c);
                }
                return uniqueLetters.Count;
            }
        }

        public bool IsEmpty => word.Equals("");

        public MaybeString GetBeginningLettersUntil(int endIndex)
        {
            return new MaybeString(word.Substring(0, endIndex));
        }

        public MaybeString CutOffBeginningLetters()
        {
            string wordWithoutBeginningLetters = this.word;
            char firstLetter = wordWithoutBeginningLetters[0];
            do
            {
                wordWithoutBeginningLetters = wordWithoutBeginningLetters.Remove(0, 1);
            } while (wordWithoutBeginningLetters.Length > 0 && wordWithoutBeginningLetters[0] == firstLetter);
            //TODO: is it ok to create here a new instance of myself?
            return new MaybeString(wordWithoutBeginningLetters);
        }

        protected bool Equals(MaybeString other)
        {
            return string.Equals(word, other.word);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MaybeString)obj);
        }

        public override int GetHashCode()
        {
            return word != null ? word.GetHashCode() : 0;
        }
    }
}