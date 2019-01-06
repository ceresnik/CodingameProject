namespace CodingameProject.Source.AlphabetUtilities
{
    public class StringFormatter
    {
        private readonly string format;

        public StringFormatter(string format)
        {
            this.format = format;
        }

        public string Format(string input)
        {
            string result = "";
            int currentInputIndex = 0;
            foreach (char currentFormatChar in format)
            {
                if (currentFormatChar == 'X' || currentFormatChar == 'x')
                {
                    if (currentFormatChar == 'X')
                        result += char.ToUpper(input[currentInputIndex]);
                    else
                        result += char.ToLower(input[currentInputIndex]);
                    currentInputIndex++;
                }
                else
                {
                    result += currentFormatChar;
                }
            }
            return result;
        }
    }
}