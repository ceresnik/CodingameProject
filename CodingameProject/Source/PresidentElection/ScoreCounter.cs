using System;
using System.Linq;

namespace CodingameProject.Source.PresidentElection
{
    public class ScoreCounter
    {
        private readonly CandidateNameElectionGainPairs electionResults;
        private const int BonusForCorrectPlaceTip = 5;

        public ScoreCounter(CandidateNameElectionGainPairs electionResults)
        {
            this.electionResults = electionResults;
        }

        public double Count(ProvidedTip providedTip)
        {
            double result = GetScoreOfOneTip(providedTip.CandidateOnFirstPosition,
                providedTip.CandidateOnFirstPositionPercent);
            result += GetScoreOfOneTip(providedTip.CandidateOnSecondPosition,
                providedTip.CandidateOnSecondPositionPercent);
            result += GetScoreOfOneTip(providedTip.CandidateOnThirdPosition,
                providedTip.CandidateOnThirdPositionPercent);
            result -= GetBonusForCorrectPlace(providedTip);
            return result;
        }

        private int GetBonusForCorrectPlace(ProvidedTip providedTip)
        {
            int result = 0;
            if (providedTip.CandidateOnFirstPosition == electionResults[0].CandidateName)
            {
                result = BonusForCorrectPlaceTip;
            }
            if (providedTip.CandidateOnSecondPosition == electionResults[1].CandidateName)
            {
                result += BonusForCorrectPlaceTip;
            }
            if (providedTip.CandidateOnThirdPosition == electionResults[2].CandidateName)
            {
                result += BonusForCorrectPlaceTip;
            }
            return result;
        }

        private double GetScoreOfOneTip(string tippedName, double tippedPercent)
        {
            return Math.Abs(electionResults.First(x => x.CandidateName == tippedName).ElectionGainInPercent - tippedPercent);
        }
    }
}