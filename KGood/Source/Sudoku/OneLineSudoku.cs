using System;
using System.Collections.Generic;
using System.Linq;

namespace KGood.Source.Sudoku
{
    public class OneLineSudoku
    {
        private IList<int> givenNumbers;
        private readonly IList<ISudokuLineRule> rules;

        public OneLineSudoku()
        {
            rules = new List<ISudokuLineRule>
                    {
                        new NullOrEmptyRule(),
                        new LengthRule(),
                        new QuestionMarkRule(),
                        new CountOfNumbersRule()
                    };
        }

        public int GetSolution(string input)
        {
            Validate(input);
            Parse(input);
            var result = UncheckGivenNumbers();
            return result[0];
        }

        private List<int> UncheckGivenNumbers()
        {
            var allNumbers = Enumerable.Range(1, 9).ToList();
            for (var i = 1; i <= 9; i++)
            {
                if (givenNumbers.Contains(i))
                {
                    allNumbers.Remove(i);
                }
            }
            return allNumbers;
        }

        private void Validate(string input)
        {
            foreach (var rule in rules)
            {
                rule.Validate(input);
            }
        }

        private void Parse(string input)
        {
            givenNumbers = new List<int>();
            foreach (char c in input)
            {
                if (Int32.TryParse(c.ToString(), out int number))
                {
                    givenNumbers.Add(number);
                }
            }
        }
    }
}