namespace CodingameProject.Source.PresidentElection
{
    public class ElectionResult
    {
        public string CandidateName { get; }
        public string ResultInPercent { get; }

        public ElectionResult(string candidateName, string resultInPercent)
        {
            CandidateName = candidateName;
            ResultInPercent = resultInPercent;
        }
    }
}