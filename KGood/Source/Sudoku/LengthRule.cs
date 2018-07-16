using System;

namespace KGood.Source.Sudoku
{
    public class LengthRule : ISudokuLineRule
    {
        public void Validate(string input)
        {
            if (input.Length != 9)
            {
                throw new ArgumentException("Line must contain exactly 9 characters.");
            }
        }
    }
}