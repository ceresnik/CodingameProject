﻿using System;
using System.Collections.Generic;

namespace KGood.Source.StringDividing
{
    public class MaybeString
    {
        public MaybeString(string word)
        {
            Word = String.IsNullOrEmpty(word) ? "" : word;
        }

        private string Word { get; }
        public int Length => Word.Length;

        public char LetterAtIndex(int index)
        {
            return Word[index];
        }

        public string Substring(int startIndex, int length)
        {
            return Word.Substring(startIndex, length);
        }

        public MaybeString CutOffBeginningLetters()
        {
            string word = Word;
            char firstLetter = word[0];
            do
            {
                word = word.Remove(0, 1);
            } while (word.Length > 0 && word[0] == firstLetter);
            return new MaybeString(word);
        }

        public int GetCountOfUniqueLetters()
        {
            var uniqueLetters = new HashSet<char>();
            foreach (char c in Word)
            {
                uniqueLetters.Add(c);
            }
            return uniqueLetters.Count;
        }

        protected bool Equals(MaybeString other)
        {
            return string.Equals(Word, other.Word);
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
            return (Word != null ? Word.GetHashCode() : 0);
        }
    }
}