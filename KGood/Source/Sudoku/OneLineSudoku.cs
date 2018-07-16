using System;
using System.Collections.Generic;

namespace KGood.Source.Sudoku
{
    public class OneLineSudoku
    {
        private IList<int> givenNumbers;
        private readonly string inputLine;
        private readonly IList<ISudokuLineRule> rules;

        public OneLineSudoku(string inputLine)
        {
            rules = new List<ISudokuLineRule>
                    {
                        new NullOrEmptyRule(),
                        new LengthRule(),
                        new QuestionMarkRule(),
                        new CountOfNumbersRule()
                    };
            this.inputLine = inputLine;
            ValidateInputLine();
            Parse();
        }

        private void ValidateInputLine()
        {
            foreach (var sudokuLineRule in rules)
            {
                sudokuLineRule.Validate(inputLine);
            }
        }

        private void Parse()
        {
            givenNumbers = new List<int>();
            foreach (char c in inputLine)
            {
                if (Int32.TryParse(c.ToString(), out int number))
                {
                    givenNumbers.Add(number);
                }
            }
        }

        public int GetSolution()
        {
            IList<int> allNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (var i = 1; i <= 9; i++)
            {
                if (givenNumbers.Contains(i))
                {
                    allNumbers.Remove(i);
                }
            }
            return allNumbers[0];
        }
    }
}