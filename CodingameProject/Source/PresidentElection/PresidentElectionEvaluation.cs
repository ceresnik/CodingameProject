using System.Collections.Generic;

namespace CodingameProject.Source.PresidentElection
{
    public class PresidentElectionEvaluation
    {
        public string ElectionResultsFile { get; }
        public string ProvidedTipsFile { get; }

        public PresidentElectionEvaluation(string electionResultsFile, string providedTipsFile)
        {
            ElectionResultsFile = electionResultsFile;
            ProvidedTipsFile = providedTipsFile;
        }

        public EvaluatedTips CountScore()
        {
            return new EvaluatedTips();
        }
    }

    public class EvaluatedTips : List<EvaluatedTip>
    {
    }

    public class EvaluatedTip
    {
    }
}