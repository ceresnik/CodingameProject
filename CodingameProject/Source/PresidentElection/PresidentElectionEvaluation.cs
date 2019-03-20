using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CodingameProject.Source.PresidentElection
{
    public class PresidentElectionEvaluation
    {
        void Evaluate()
        {
            
        }

        void ReadoutElectionResults()
        {
            string jsonInputFile = "ElectionResults.json";
            using (StreamReader r = new StreamReader(jsonInputFile))
            {
                var input = r.ReadToEnd();
                var electionResults = JsonConvert.DeserializeObject<List<ElectionResults>>(input);
                foreach (var result in electionResults)
                {
                    Console.WriteLine($"{result.name} : {result.result}");
                }
            }
        }

        class ElectionResults
        {
            public string name;
            public double result;
        }
    }
}