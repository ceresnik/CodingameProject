using KGood.Source.Extensions;

namespace KGood.Source
{
    public class AsciiCodeToLetterConverter
    {
        public string ConvertAsciiCodesToLetters(string input)
        {
            var chunksConsistingOfThreeChars = input.SplitToChunksOf(3);
            string result = "";
            foreach (var chunk in chunksConsistingOfThreeChars)
            {
                int asciiCode = int.Parse(chunk);
                result += ((char)asciiCode).ToString();
            }
            return result;
        }
    }
}