using System;
using System.Linq;

namespace CodingameProject.Source.PresidentElection
{
    public class ScoreCounter
    {
        private readonly CandidateNameElectionGainPairs electionResults;
        private readonly int bonusForCorrectPlaceTip;

        public ScoreCounter(CandidateNameElectionGainPairs electionResults, int bonusForCorrectPlace)
        {
            this.electionResults = electionResults;
            this.bonusForCorrectPlaceTip = bonusForCorrectPlace;
        }

        public double Count(ProvidedTip providedTip)
        {
            double result = GetScoreOfOneTip(providedTip.Tips[0].CandidateName,
                providedTip.Tips[0].ElectionGainInPercent);
            result += GetScoreOfOneTip(providedTip.Tips[1].CandidateName,
                providedTip.Tips[1].ElectionGainInPercent);
            result += GetScoreOfOneTip(providedTip.Tips[2].CandidateName,
                providedTip.Tips[2].ElectionGainInPercent);
            result -= GetBonusForCorrectPlace(providedTip);
            return result;
        }

        private int GetBonusForCorrectPlace(ProvidedTip providedTip)
        {
            int result = 0;
            if (providedTip.Tips[0].CandidateName == electionResults[0].CandidateName)
            {
                result = bonusForCorrectPlaceTip;
            }
            if (providedTip.Tips[1].CandidateName == electionResults[1].CandidateName)
            {
                result += bonusForCorrectPlaceTip;
            }
            if (providedTip.Tips[2].CandidateName == electionResults[2].CandidateName)
            {
                result += bonusForCorrectPlaceTip;
            }
            return result;
        }

        private double GetScoreOfOneTip(string tippedName, double tippedPercent)
        {
            return Math.Abs(electionResults.First(x => x.CandidateName == tippedName).ElectionGainInPercent - tippedPercent);
        }
    }
}