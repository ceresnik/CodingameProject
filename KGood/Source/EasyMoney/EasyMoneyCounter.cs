using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace KGood.Source.EasyMoney
{
    public class EasyMoneyCounter
    {
        private readonly IList<double> availableMoney = new List<double> { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.5, 0.2, 0.1 };
        private const string CurrencySymbol = "€";
        private const string Multiplicator = "x";
        private const string Divider = ", ";
        private const string Impossible = "IMPOSSIBLE";

        public string Split(double amountOfMoney)
        {
            var countOfBankNotesByBankNote = new Dictionary<string, int>();
            foreach (double bankNote in availableMoney)
            {
                int howManyTimes = (int)(amountOfMoney / bankNote);
                if (howManyTimes > 0)
                {
                    countOfBankNotesByBankNote.Add(bankNote.ToString(CultureInfo.InvariantCulture), howManyTimes);
                    amountOfMoney -= howManyTimes * bankNote;
                    amountOfMoney = Math.Round(amountOfMoney, 3);
                }
            }
            string result;
            if (amountOfMoney > 0)
            {
                result = Impossible;
            }
            else
            {
                IEnumerable<string> pairs = countOfBankNotesByBankNote.Select(
                    c => $"{c.Value} {Multiplicator} {c.Key}");
                result = string.Join(Divider, pairs) + CurrencySymbol;
            }

            return result;
        }
    }
}