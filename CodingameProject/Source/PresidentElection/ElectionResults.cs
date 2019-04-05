using System.Collections.Generic;

namespace CodingameProject.Source.PresidentElection
{
    public class ElectionResults
    {
        public IList<ElectionResult> Results { get; set; }

        public ElectionResults()
        {
            Results = new List<ElectionResult>();
        }

        public int Count()
        {
            return Results.Count;
        }
    }
}