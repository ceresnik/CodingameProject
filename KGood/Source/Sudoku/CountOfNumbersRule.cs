using System;

namespace KGood.Source.Sudoku
{
    public class CountOfNumbersRule : ISudokuLineRule
    {
        private readonly int countOfNumbersRequired = 8;

        public void Validate(string input)
        {
            var countOfNumbers = CountNumbersIn(input);
            if (countOfNumbers != countOfNumbersRequired)
            {
                throw new ArgumentException("Line does not contain 8 numbers.");
            }
        }

        private int CountNumbersIn(string input)
        {
            int countOfNumbers = 0;
            foreach (char c in input)
            {
                if (int.TryParse(c.ToString(), out int _))
                {
                    countOfNumbers++;
                }
            }
            return countOfNumbers;
        }
    }
}