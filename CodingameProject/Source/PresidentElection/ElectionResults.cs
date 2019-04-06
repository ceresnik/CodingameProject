using System.Collections.Generic;

namespace CodingameProject.Source.PresidentElection
{
    public class ElectionResults : List<ElectionResult>
    {
        public IList<ElectionResult> Results { get; }

        public ElectionResults()
        {
            Results = new List<ElectionResult>();
        }
    }
}