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

        public MaybeString GetBeginningLettersUntil(int endIndex)
        {
            return new MaybeString(word.Substring(0, endIndex));
        }

        public MaybeString CutOffBeginningLetters()
        {
            string word = this.word;
            char firstLetter = word[0];
            do
            {
                word = word.Remove(0, 1);
            } while (word.Length > 0 && word[0] == firstLetter);
            return new MaybeString(word);
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