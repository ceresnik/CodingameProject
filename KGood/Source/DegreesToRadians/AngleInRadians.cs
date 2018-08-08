namespace KGood.Source.DegreesToRadians
{
    public class AngleInRadians
    {
        private readonly int countOfQuarters;
        private readonly string piSign = "P";
        private readonly string fractionSeparator = "/";
        private string multiplySign = "*";
        private string strNumerator;
        private string strDenominator;

        public AngleInRadians(int countOfQuarters)
        {
            this.countOfQuarters = countOfQuarters;
        }

        public string GetStringRepresentation()
        {
            int numerator = countOfQuarters;
            int denominator = countOfQuarters > 0 ? 4 : 0;
            if (HaveCommonDivisor(numerator, denominator))
            {
                int commonDivisor = FindCommonDivisor(numerator, denominator);
                numerator = numerator / commonDivisor;
                denominator = denominator / commonDivisor;
            }
            ConvertNumeratorAndDenominatorToStringRepresentation(numerator, denominator);
            return ComposeResult(numerator, denominator);
        }

        private bool HaveCommonDivisor(int a, int b)
        {
            var biggestCommonDivisor = FindCommonDivisor(a, b);
            return biggestCommonDivisor > 1;
        }

        private int FindCommonDivisor(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a == 0 ? b : a;
        }

        private void ConvertNumeratorAndDenominatorToStringRepresentation(int numerator, int denominator)
        {
            strNumerator = numerator > 1 ? numerator.ToString() : "";
            strDenominator = denominator > 1 ? denominator.ToString() : "";
        }

        private string ComposeResult(int numerator, int denominator)
        {
            string result = strNumerator;
            if (numerator > 1)
            {
                result += multiplySign;
            }
            if (numerator > 0)
            {
                result += piSign;
            }
            else
            {
                result = "0";
            }
            if (denominator > 1)
            {
                result += fractionSeparator;
            }
            result += strDenominator;
            return result;
        }
    }
}