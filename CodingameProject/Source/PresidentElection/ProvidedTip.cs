using System;

namespace CodingameProject.Source.PresidentElection
{
    public class ProvidedTip
    {
        public readonly CandidateNameElectionGainPairs Tips;
        private const int MaximumCountOfTippedPlaces = 6;

        public ProvidedTip(string tipperName, CandidateNameElectionGainPairs tips)
        {
            TipperName = tipperName;
            if (tips.Count > MaximumCountOfTippedPlaces)
            {
                throw new ArgumentException($"Maximum {MaximumCountOfTippedPlaces} tipped places are allowed.", nameof(tips));
            }
            this.Tips = tips;
        }

        public readonly string TipperName;
    }
}