using System.IO;
using CodingameProject.Tests.PresidentElection;

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
            throw new System.NotImplementedException();
        }
    }
}