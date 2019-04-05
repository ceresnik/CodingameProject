using System.Collections;
using System.Collections.Generic;

namespace CodingameProject.Source.PresidentElection
{
    public class ElectionResults : IEnumerable<ElectionResult>
    {
        public IList<ElectionResult> Results;

        public ElectionResults()
        {
            Results = new List<ElectionResult>();
        }

        public IEnumerator<ElectionResult> GetEnumerator()
        {
            return Results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ElectionResult electionResult)
        {
            Results.Add(electionResult);
        }
    }
}