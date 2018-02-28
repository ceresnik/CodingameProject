using System.Linq;

namespace CodingameProject.Source
{
    public class NumberRepresentation
    {
        private int number;

        public NumberRepresentation(int number)
        {
            this.number = number;
        }

        public int Sum => number;

        public NumberRepresentation GetSumOfDigits()
        {
            number = number.ToString().Sum(digit => int.Parse(digit.ToString()));
            return this;
        }
        public int GetSumOfDigitsUntilNine()
        {
            NumberRepresentation numberRepresentation;
            do
                numberRepresentation = GetSumOfDigits();
            while (numberRepresentation.number > 9);
            return numberRepresentation.number;
        }

    }
}
