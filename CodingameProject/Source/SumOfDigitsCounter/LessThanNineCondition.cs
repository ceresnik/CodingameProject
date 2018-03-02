namespace CodingameProject.Source.SumOfDigitsCounter
{
    public class LessThanNineCondition : ICondition
    {
        public bool IsFulfilled(int number)
        {
            return number <= 9;
        }
    }
}