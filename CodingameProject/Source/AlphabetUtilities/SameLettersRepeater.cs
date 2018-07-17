namespace CodingameProject.Source.AlphabetUtilities
{
    public class SameLettersRepeater
    {
        private readonly StringConverter stringConverter;

        public SameLettersRepeater(string input)
        {
            stringConverter = new StringConverter(input);
        }

        public string Convert()
        {
            return stringConverter.Convert();
        }
    }
}