namespace CodingameProject.Source.PresidentElection
{
    public class ContestEvaluation
    {
        public string ElectionResultsFile { get; }
        public string ProvidedTipsFile { get; }

        public ContestEvaluation(string electionResultsFile, string providedTipsFile)
        {
            ElectionResultsFile = electionResultsFile;
            ProvidedTipsFile = providedTipsFile;
        }

        public EvaluatedTips CountScore()
        {
            int countOfProvidedTips = new ProvidedTipsReader(ProvidedTipsFile).Read().Count;
            var evaluatedTips = new EvaluatedTips();
            for (int i = 0; i < countOfProvidedTips; i++)
            {
                evaluatedTips.Add(new EvaluatedTip("TipperName", 3.45));
            }
            return evaluatedTips;
        }
    }
}