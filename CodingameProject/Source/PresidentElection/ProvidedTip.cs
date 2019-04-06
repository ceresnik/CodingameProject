namespace CodingameProject.Source.PresidentElection
{
    public class ProvidedTip
    {
        private readonly CandidateNameElectionGainPairs tips;
        public readonly string TipperName;
        public string CandidateOnFirstPosition => tips[0].CandidateName;
        public string CandidateOnSecondPosition => tips[1].CandidateName;
        public string CandidateOnThirdPosition => tips[2].CandidateName;
        public double CandidateOnFirstPositionPercent => tips[0].ElectionGainInPercent;
        public double CandidateOnSecondPositionPercent => tips[1].ElectionGainInPercent;
        public double CandidateOnThirdPositionPercent => tips[2].ElectionGainInPercent;

        public ProvidedTip(string tipperName, CandidateNameElectionGainPairs tips)
        {
            TipperName = tipperName;
            this.tips = tips;
        }
    }
}