namespace CodingameProject.Source.PresidentElection
{
    public class ProvidedTip
    {
        private readonly CandidateNameElectionGainPairs tips;
        public readonly string TipperName;
        public string CandidateOnFirstPosition => tips[0].CandidateName;
        public string CandidateOnSecondPosition
        {
            get
            {
                string result = string.Empty;
                if (tips.Count > 1)
                {
                    result = tips[1].CandidateName;
                }
                return result;
            }
        }

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