using System;

namespace KGood.Source.Sudoku
{
    public class QuestionMarkRule : ISudokuLineRule
    {
        public void Validate(string line)
        {
            if (line.Contains("?") == false)
            {
                throw new ArgumentException("Line must contain question mark.");
            }
        }
    }
}