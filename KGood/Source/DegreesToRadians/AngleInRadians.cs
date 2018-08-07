namespace KGood.Source.DegreesToRadians
{
    public class AngleInRadians
    {
        private readonly int numerator;
        private readonly int denominator;
        private string fractionSeparator = "/";
        private string piSign = "P";

        public AngleInRadians(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public string ToBasicShape()
        {
            if (numerator == 0 && denominator == 1)
            {
                return "0";
            }
            var basicShapeOfDenominator = CountBasicShapeOfDenominator();
            var result = CountBasicShapeOfNumerator() + piSign;
            if (basicShapeOfDenominator > 1)
            {
                result += fractionSeparator + basicShapeOfDenominator;
            }
            return result;
        }

        private string CountBasicShapeOfNumerator()
        {
            if (numerator == 1)
            {
                return "";
            }
            return "";
        }

        private int CountBasicShapeOfDenominator()
        {
            return denominator;
        }
    }
}