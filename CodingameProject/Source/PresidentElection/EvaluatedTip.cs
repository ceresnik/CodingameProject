namespace CodingameProject.Source.PresidentElection
{
    public class EvaluatedTip
    {
        public string TipperName { get; }
        public double Score { get; }

        public EvaluatedTip(string tipperName, double score)
        {
            TipperName = tipperName;
            Score = score;
        }
    }
}