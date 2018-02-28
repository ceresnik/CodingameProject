using System.Collections.Generic;
using System.Text;

namespace KGood.Source
{
    internal static class Bonobo
    {
        /// <summary>
        /// Does this: from "bonobo" makes "bonoobbooo".
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string Convert(string inputString)
        {
            IDictionary<char, int> occurencesOfLetters = new Dictionary<char, int>();
            StringBuilder sb = new StringBuilder();
            foreach (char c in inputString)
            {
                if (occurencesOfLetters.ContainsKey(c) == false)
                {
                    occurencesOfLetters.Add(new KeyValuePair<char, int>(c, 0));
                }
                occurencesOfLetters[c]++;
                for (int i = 0; i < occurencesOfLetters[c]; i++)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}