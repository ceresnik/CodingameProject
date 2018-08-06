using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KGood.Source.EasyMoney
{
    public class EasyMoneyCounter
    {
        private readonly IList<double> availableMoney = new List<double> { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.5, 0.2, 0.1 };

        private const string MoneyJoiner = " x ";
        private const string MoneyDivider = ", ";
        private const string Impossible = "IMPOSSIBLE";

        public string Calculate(double amountOfMoney)
        {
            StringBuilder sb = new StringBuilder();
            foreach (double bankNote in availableMoney)
            {
                int howManyTimes = (int)(amountOfMoney / bankNote);
                if (howManyTimes > 0)
                {
                    sb.Append($"{howManyTimes} x {bankNote.ToString(CultureInfo.InvariantCulture)}, ");
                    amountOfMoney -= howManyTimes * bankNote;
                    amountOfMoney = Math.Round(amountOfMoney, 3);
                }
            }
            if (amountOfMoney > 0)
            {
                sb = new StringBuilder("IMPOSSIBLE");
            }
            else
            {
                sb.Remove(sb.Length - 2, 2).Append("€");
            }
            return sb.ToString();
        }
        public string Calculate_Version1(double amountOfMoney)
        {
            double amount = Math.Round(amountOfMoney, 2);
            string result;
            if (IsGranularityFulfilled(amount))
            {
                StringBuilder sb = new StringBuilder();
                foreach (double bankNote in availableMoney)
                {
                    sb.Append(CountBankNotes(ref amount, bankNote));
                }
                sb.Append("€");
                result = sb.ToString();
            }
            else
            {
                result = Impossible;
            }
            return result;
        }

        private static string CountBankNotes(ref double amount, double bankNote)
        {
            StringBuilder sb = new StringBuilder();
            int repetitionCount = (int)(amount / bankNote);
            if (repetitionCount > 0)
            {
                sb.Append(repetitionCount + MoneyJoiner + bankNote);
                amount = amount % bankNote;
                amount = Math.Round(amount, 2);
                if (Math.Abs(amount) > 0.001)
                {
                    sb.Append(MoneyDivider);
                }
            }
            return sb.ToString();
        }

        private bool IsGranularityFulfilled(double amount)
        {
            double decimalPart = amount * 10 - Math.Truncate(amount * 10);
            if (decimalPart > 0)
            {
                return false;
            }
            return true;
        }        
    }
}