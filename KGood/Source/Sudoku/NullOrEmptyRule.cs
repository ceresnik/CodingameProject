using System;

namespace KGood.Source.Sudoku
{
    public class NullOrEmptyRule : ISudokuLineRule
    {
        public void Validate(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                throw new ArgumentException("Line must not be null or empty.");
            }
        }
    }
}