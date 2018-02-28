using System;

namespace KGood.Source.Sudoku
{
    public class CountOfNumbersRule : ISudokuLineRule
    {
        public void Validate(string line)
        {
            int countOfNumbers = 0;
            foreach (char c in line)
            {
                bool result = Int32.TryParse(c.ToString(), out int number);
                if (result)
                {
                    countOfNumbers++;
                }
            }
            if (countOfNumbers != 8)
            {
                throw new ArgumentException("Line contain 8 numbers.");
            }
        }
    }
}