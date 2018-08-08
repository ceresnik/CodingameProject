namespace KGood.Source.DegreesToRadians
{
    public class QuarterCounter
    {
        public int GetCountOfQuarters(int angleInDegrees)
        {
            while (angleInDegrees < 0)
            {
                angleInDegrees += 360;
            }
            while (angleInDegrees > 360)
            {
                angleInDegrees -= 360;
            }
            return angleInDegrees / 45;
        }
    }
}