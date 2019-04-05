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

        public ElectionResults Read()
        {
            using (StreamReader r = new StreamReader(InputFileName))
            {
                var input = r.ReadToEnd();
                //var electionResult = JsonConvert.DeserializeObject<ElectionResult>(input);
                var electionResults = JsonConvert.DeserializeObject<ElectionResults>(input);
                //foreach (var result in electionResults)
                //{
                //    Console.WriteLine($"{result.CandidateName} : {result.ResultInPercent}");
                //}
                //Console.WriteLine($"Name: {electionResult.CandidateName}, percent: {electionResult.ResultInPercent}");

                //var electionResults = new ElectionResults();
                //electionResults.Add(electionResult);
                return electionResults;
            }
        }

        public ElectionResult ReadOneResult()
        {
            using (StreamReader r = new StreamReader(InputFileName))
            {
                var input = r.ReadToEnd();
                var electionResult = JsonConvert.DeserializeObject<ElectionResult>(input);
                return electionResult;
            }
        }
    }
}