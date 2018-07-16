namespace CodingameProject.Source.MathematicalCorner
{
    /// <summary>
    /// Arithmetic series is sum of all members of Arithmetic progression.
    /// </summary>
    public class ArithmeticSeriesCounter
    {
        private readonly int commonDifference;

        public ArithmeticSeriesCounter(int commonDifference)
        {
            this.commonDifference = commonDifference;
        }

        internal int CountSum(int initialItem, int countOfItems)
        {
            var lastItem = GetItemByPosition(initialItem, countOfItems);
            return countOfItems * (initialItem + lastItem) / 2;
        }

        private int GetItemByPosition(int initialItem, int position)
        {
            int itemAtPosition = initialItem + (position - 1) * commonDifference;
            return itemAtPosition;
        }
    }
}