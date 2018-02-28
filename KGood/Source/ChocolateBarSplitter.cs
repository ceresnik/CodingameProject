namespace KGood.Source
{
    public class ChocolateBarSplitter
    {
        /// <summary>
        /// Counts how many times have to be chocolate bar divided (splitted) into 1x1 pieces.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public int CountSplits(int rows, int columns)
        {
            int countOfSplits = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i > 0)
                {
                    countOfSplits++;
                }
                for (int j = 0; j < columns; j++)
                {
                    if (j > 0)
                    {
                        countOfSplits++;
                    }
                }
            }
            return countOfSplits;
            //simplest solution: result=rows*columns-1;
        }
    }
}