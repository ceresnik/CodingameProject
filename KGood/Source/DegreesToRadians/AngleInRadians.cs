namespace KGood.Source.DegreesToRadians
{
    public class AngleInRadians
    {
        private readonly int countOfQuarters;
        private readonly string piSign = "P";
        private readonly string fractionSeparator = "/";
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
            ConvertNumeratorAndDenominatorToStringRepresentation(numerator, denominator);
            return ComposeResult(numerator);
        }

        private void ConvertNumeratorAndDenominatorToStringRepresentation(int numerator, int denominator)
        {
            strNumerator = countOfQuarters > 1 ? numerator.ToString() : "";
            strDenominator = denominator > 1 ? denominator.ToString() : "";
        }

        private string ComposeResult(int numerator)
        {
            string result = strNumerator;
            if (numerator > 0)
            {
                result += piSign;
            }
            else
            {
                result = "0";
            }
            if (string.IsNullOrEmpty(strDenominator) == false)
            {
                result += fractionSeparator;
            }
            result += strDenominator;
            return result;
        }
    }
}