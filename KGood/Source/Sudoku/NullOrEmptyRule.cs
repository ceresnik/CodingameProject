using System;

namespace KGood.Source.Sudoku
{
    public class NullOrEmptyRule : ISudokuLineRule
    {
        public void Validate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Line must not be null or empty.");
            }
        }
    }
}