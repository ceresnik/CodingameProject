using System;
using System.Linq;

namespace CodingameProject.Source.PresidentElection
{
    public class ScoreCounter
    {
        private readonly CandidateNameElectionGainPairs electionResults;
        private readonly int bonusForCorrectPlaceTip;
        private const double BadScore = 100;

        public ScoreCounter(CandidateNameElectionGainPairs electionResults, int bonusForCorrectPlace)
        {
            this.electionResults = electionResults;
            this.bonusForCorrectPlaceTip = bonusForCorrectPlace;
        }

        public double Count(ProvidedTip providedTip, int countOfTippedPlaces)
        {
            double result = 0;
            for (int i = 0; i < countOfTippedPlaces; i++)
            {
                result += GetScoreOfOneTip(providedTip.Tips[i].CandidateName,
                    providedTip.Tips[i].ElectionGainInPercent);

            }
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
            CandidateNameElectionGainPair foundCandidate;
            try
            {
                foundCandidate = electionResults.First(x => x.CandidateName == tippedName);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Candidate with name {tippedName} not found in election results.");
                return BadScore;
            }
            return Math.Abs(foundCandidate.ElectionGainInPercent - tippedPercent);
        }
    }
}