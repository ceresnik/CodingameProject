using System;

namespace KGood.Source.Sudoku
{
    public class CountOfNumbersRule : ISudokuLineRule
    {
        public void Validate(string input)
        {
            int countOfNumbers = 0;
            foreach (char c in input)
            {
                if (Int32.TryParse(c.ToString(), out int _))
                {
                    countOfNumbers++;
                }
            }
            if (countOfNumbers != 8)
            {
                throw new ArgumentException("Line does not contain 8 numbers.");
            }
        }
    }
}