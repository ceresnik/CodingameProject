using System.IO;

namespace CodingameProject.Tests.PresidentElection
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
    }
}