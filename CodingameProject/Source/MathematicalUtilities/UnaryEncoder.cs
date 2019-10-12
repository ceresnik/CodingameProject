using System;

namespace CodingameProject.Source.MathematicalUtilities
{
    public class UnaryEncoder
    {
        private string serieOneSign = "0";
        private string serieZeroSign = "00";
        private string spaceSign = " ";

        public string Encrypt(string input)
        {
            char inputChar = input[0];
            string result = "";
            int asciiValueDecimal = inputChar;
            string asciiValueBinary = Convert.ToString(asciiValueDecimal, 2);

            int lengthOfSerieCounter = 1;
            int currentSerieSign = asciiValueBinary[0];
            int index = 1;
            int counter = 0;

            while (index <= 6)
            {
                do
                {
                    counter++;
                } while (currentSerieSign == asciiValueBinary[index++] && index < 6);
                if (currentSerieSign == '1')
                {
                    result += serieOneSign;
                }
                else
                {
                    result += serieZeroSign;
                }

                result += spaceSign;

                for (int i = 0; i < counter; i++)
                {
                    result += 0;
                }

                counter = 0;
                currentSerieSign = asciiValueBinary[index];
                result += spaceSign;
            }
            return result;
        }
    }
}