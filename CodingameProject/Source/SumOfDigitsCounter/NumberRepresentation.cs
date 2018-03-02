using System.Linq;

namespace CodingameProject.Source.SumOfDigitsCounter
{
    public class NumberRepresentation
    {
        private int number;
        private readonly ICondition condition;

        public NumberRepresentation(int number)
        :this(number, new NoRestrictionCondition()) { }

        public NumberRepresentation(int number, ICondition condition)
        {
            this.number = number;
            this.condition = condition;
        }

        public int GetSumOfDigits()
        {
            do
            {
                number = number.ToString().Sum(digit => int.Parse(digit.ToString()));
            } while (condition.IsFulfilled(number) == false);
            return number;
        }
    }
}
