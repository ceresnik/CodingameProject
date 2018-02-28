using System.Text;

namespace KGood.Source
{
    public class AsciiArt
    {
        /// <summary>
        /// Inverts given ASCII art. First column becomes first row and vice versa.
        /// </summary>
        /// <param name="inputRows"></param>
        /// <returns></returns>
        public string InvertASCIIArt(string[] inputRows)
        {
            int countOfWords = inputRows.Length;
            int countOfLetters = inputRows[0].Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < countOfLetters; i++)
            {
                for (int j = 0; j < countOfWords; j++)
                {
                    sb.Append(inputRows[j][i]);
                }
                sb.Append(System.Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}