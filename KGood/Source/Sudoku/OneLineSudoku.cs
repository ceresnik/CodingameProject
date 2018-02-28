using System;
using System.Collections.Generic;

namespace KGood.Source.Sudoku
{
    public class OneLineSudoku
    {
        private readonly IList<int> givenNumbers;

        public OneLineSudoku(string line)
        {
            IList<ISudokuLineRule> sudokuLineRules = new List<ISudokuLineRule>
                                                     {
                                                         new NullOrEmptyRule(),
                                                         new LengthRule(),
                                                         new QuestionMarkRule(),
                                                         new CountOfNumbersRule()
                                                     };
            foreach (var sudokuLineRule in sudokuLineRules)
            {
                sudokuLineRule.Validate(line);
            }
            givenNumbers = Parse(line);
        }

        private static List<int> Parse(string line)
        {
            var numbers = new List<int>();
            foreach (char c in line)
            {
                if (Int32.TryParse(c.ToString(), out int number))
                {
                    numbers.Add(number);
                }
            }
            return numbers;
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