namespace CodingameProject.Source.PresidentElection
{
    public class ProvidedTip
    {
        public readonly string TipperName;
        public readonly string CandidateOnFirstPosition;
        public readonly double CandidateOnFirstPositionPercent;

        public ProvidedTip(string tipperName, string candidateOnFirstPosition, double candidateOnFirstPositionPercent)
        {
            TipperName = tipperName;
            CandidateOnFirstPosition = candidateOnFirstPosition;
            CandidateOnFirstPositionPercent = candidateOnFirstPositionPercent;
        }
    }
}