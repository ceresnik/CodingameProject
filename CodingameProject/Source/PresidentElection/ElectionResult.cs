namespace CodingameProject.Source.PresidentElection
{
    internal class ElectionResult
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