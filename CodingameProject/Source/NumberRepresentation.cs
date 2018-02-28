using System;
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

        public int Number
        {
            get
            {
                return this.number;
            }
        }

        public int GetSumOfDigits()
        {
            this.number = this.number.ToString().Sum<char>((Func<char, int>)(digit => int.Parse(digit.ToString())));
            return this.number;
        }

        public int GetSumOfDigitsUntilNine()
        {
            do
                ;
            while (new NumberRepresentation(this.GetSumOfDigits()).number > 9);
            return this.number;
        }
    }
}
