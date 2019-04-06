namespace CodingameProject.Source.PresidentElection
{
    public class ElectionResult
    {
        public string CandidateName { get; }
        public double ResultInPercent { get; }

        public ElectionResult(string candidateName, double resultInPercent)
        {
            CandidateName = candidateName;
            ResultInPercent = resultInPercent;
        }
    }
}