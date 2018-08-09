namespace KGood.Source.DegreesToRadians
{
    public class DegreesToRadiansConvertor
    {
        public string Convert(int angle)
        {
            var angleInRadians = new AngleInRadians(new QuarterCounter().GetCountOfQuarters(angle));
            return angleInRadians.GetStringRepresentation();
        }
    }
}