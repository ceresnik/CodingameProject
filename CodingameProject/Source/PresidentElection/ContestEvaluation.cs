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

        public EvaluatedTips CountScore()
        {
            var providedTips = new ProvidedTipsReader(ProvidedTipsFileName).Read();
            int countOfProvidedTips = providedTips.Count;
            var evaluatedTips = new EvaluatedTips();
            for (int i = 0; i < countOfProvidedTips; i++)
            {
                evaluatedTips.Add(new EvaluatedTip(providedTips[i].TipperName, 3.45));
            }
            return evaluatedTips;
        }
    }
}