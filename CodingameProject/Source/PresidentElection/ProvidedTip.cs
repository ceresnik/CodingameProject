using System;

namespace CodingameProject.Source.PresidentElection
{
    public class ProvidedTip
    {
        public readonly CandidateNameElectionGainPairs Tips;
        private const int MaximumCountOfTips = 5;

        public ProvidedTip(string tipperName, CandidateNameElectionGainPairs tips)
        {
            TipperName = tipperName;
            if (tips.Count > MaximumCountOfTips)
            {
                throw new ArgumentException($"Maximum {MaximumCountOfTips} tips are allowed.", nameof(tips));
            }
            this.Tips = tips;
        }

        public readonly string TipperName;
    }
}