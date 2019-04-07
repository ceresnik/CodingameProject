using System;
using System.IO;

namespace CodingameProject.Source.PresidentElection
{
    public static class FilePathProvider
    {
        public static string ProvideFullPathToFile(string fileName, string directoryWithFile)
        {
            string baseDirectory = AppContext.BaseDirectory;
            string twoLevelsUp = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\"));
            string destinationDirectory = Path.Combine(twoLevelsUp, directoryWithFile);
            return Path.GetFullPath(Path.Combine(destinationDirectory, fileName));
        }
    }
}