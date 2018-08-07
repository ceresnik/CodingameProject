namespace KGood.Source.DegreesToRadians
{
    public class DegreesToRadiansConvertor
    {
        public string Convert(int angle)
        {
            var angleInDegrees = new AngleInDegrees(angle);
            return angleInDegrees.ConvertToRadians();
        }
    }
}