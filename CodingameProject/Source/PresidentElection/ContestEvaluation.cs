namespace CodingameProject.Source.PresidentElection
{
    public class ContestEvaluation
    {
        public string ElectionResultsFileName { get; }
        public string ProvidedTipsFileName { get; }

        public ContestEvaluation(string electionResultsFileName, string providedTipsFileName)
        {
            ElectionResultsFileName = electionResultsFileName;
            ProvidedTipsFileName = providedTipsFileName;
        }

        public EvaluatedTips CountScore(int bonusForCorrectPlace)
        {
            var providedTips = new ProvidedTipsReader(ProvidedTipsFileName).Read();
            int countOfProvidedTips = providedTips.Count;
            var evaluatedTips = new EvaluatedTips();
            CandidateNameElectionGainPairs electionResults = new ElectionResultsReader(ElectionResultsFileName).Read();
            ScoreCounter scoreCounter = new ScoreCounter(electionResults, bonusForCorrectPlace);
            for (int i = 0; i < countOfProvidedTips; i++)
            {
                double score = scoreCounter.Count(providedTips[i]);
                evaluatedTips.Add(new EvaluatedTip(providedTips[i].TipperName, score));
            }
            return evaluatedTips;
        }
    }
}