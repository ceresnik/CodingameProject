using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingameProject.Source.AlphabetUtilities
{
    /// <summary>
    /// Does this: from "bonobo" makes "bonoobbooo".
    /// </summary>
    public class StringConverter
    {
        private readonly IEnumerable<char> input;

        public StringConverter(string input)
        {
            this.input = input;
        }

        public string Convert()
        {
            var output = new StringBuilder();
            var usedLetters = new List<char>();
            foreach (char c in input)
            {
                usedLetters.Add(c);
                int countOfCurrentLetter = usedLetters.Count(x => Char.ToLower(x).Equals(Char.ToLower(c)));
                for (int i = 0; i < countOfCurrentLetter; i++)
                {
                    output.Append(c);
                }
            }
            return output.ToString();
        }
    }
}