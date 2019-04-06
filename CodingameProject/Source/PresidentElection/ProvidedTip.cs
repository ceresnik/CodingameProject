namespace CodingameProject.Source.PresidentElection
{
    public class ProvidedTip
    {
        private readonly CandidateNameElectionGainPairs tips;
        public readonly string TipperName;
        public string CandidateOnFirstPosition => tips[0].CandidateName;
        public double CandidateOnFirstPositionPercent => tips[0].ElectionGainInPercent;

        public ProvidedTip(string tipperName, CandidateNameElectionGainPairs tips)
        {
            TipperName = tipperName;
            this.tips = tips;
        }
    }
}