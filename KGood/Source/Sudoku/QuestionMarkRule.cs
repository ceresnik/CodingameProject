using System;

namespace KGood.Source.Sudoku
{
    public class QuestionMarkRule : ISudokuLineRule
    {
        public void Validate(string input)
        {
            if (input.Contains("?") == false)
            {
                throw new ArgumentException("Line must contain question mark.");
            }
        }
    }
}