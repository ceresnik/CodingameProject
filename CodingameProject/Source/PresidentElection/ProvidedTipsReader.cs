using System.IO;
using CodingameProject.Tests.PresidentElection;
using Newtonsoft.Json;

namespace CodingameProject.Source.PresidentElection
{
    public class ProvidedTipsReader
    {
        public string InputFileName { get; }

        public ProvidedTipsReader(string inputFileName)
        {
            var fullPath = Path.GetFullPath(inputFileName);
            if (File.Exists(fullPath) == false)
            {
                throw new FileNotFoundException($"File {fullPath} does not exist.");
            }
            InputFileName = inputFileName;
        }

        public ProvidedTips Read()
        {
            using (var r = new StreamReader(InputFileName))
            {
                var input = r.ReadToEnd();
                ProvidedTips providedTips = JsonConvert.DeserializeObject<ProvidedTips>(input);
                return providedTips;
            }
        }
    }
}