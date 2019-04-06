using System.IO;
using Newtonsoft.Json;

namespace CodingameProject.Source.PresidentElection
{
    public class ElectionResultsReader
    {
        public string InputFileName { get; }

        public ElectionResultsReader(string inputFileName)
        {
            var fullPath = Path.GetFullPath(inputFileName);
            if (File.Exists(fullPath) == false)
            {
                throw new FileNotFoundException($"File {fullPath} does not exist.");
            }
            InputFileName = fullPath;
        }

        public CandidateNameElectionGainPairs Read()
        {
            using (StreamReader r = new StreamReader(InputFileName))
            {
                var input = r.ReadToEnd();
                var electionResults = JsonConvert.DeserializeObject<CandidateNameElectionGainPairs>(input);
                return electionResults;
            }
        }
    }
}