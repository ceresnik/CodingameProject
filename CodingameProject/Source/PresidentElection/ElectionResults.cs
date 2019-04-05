using System.Collections.Generic;

namespace CodingameProject.Source.PresidentElection
{
    public class ElectionResults
    {
        public IList<ElectionResult> Results { get; set; }

        public int Count()
        {
            return Results.Count;
        }
    }
}