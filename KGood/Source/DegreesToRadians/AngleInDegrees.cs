using System;
using System.Linq;

namespace KGood.Source.DegreesToRadians
{
    public class AngleInDegrees
    {
        private readonly int angle;

        public AngleInDegrees(int angle)
        {
            this.angle = angle;
        }

        public string ConvertToRadians()
        {
            int numerator = GetNumerator();
            int denominator = GetDenominator();
            return new AngleInRadians(numerator, denominator).ToBasicShape();
        }

        private int GetNumerator()
        {
            if (Enumerable.Range(1, 90).Contains(angle))
            {
                return 1;
            }
            if (Enumerable.Range(91, 90).Contains(angle))
            {
                return 2;
            }
            return 0;
        }

        private int GetDenominator()
        {
            int result;
            try
            {
                result = 180 / angle;
            }
            catch (DivideByZeroException)
            {
                return 1;
            }
            return result;
        }
    }
}