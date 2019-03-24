using System;
using System.IO;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class ElectionResultsReaderTests
    {
        [Test]
        public void ElectionResultsReaderObject_InitializedCorrectly()
        {
            var testResultsFileName = "TestResults.json";
            var sut = new ElectionResultsReader(testResultsFileName);
            Assert.That(sut.InputFileName, Is.EqualTo(testResultsFileName));
        }

        [Test]
        public void InputFileDoesNotExist_ExceptionIsThrown()
        {
            var notExistingFile = "NotExistingFile.json";
            Assert.Throws<FileNotFoundException>(() => { new ElectionResultsReader(notExistingFile); });
        }
    }

    public class ElectionResultsReader
    {
        public string InputFileName { get; }

        public ElectionResultsReader(string inputFileName)
        {
            if (File.Exists(inputFileName) == false)
            {
                var fileInfo = new FileInfo(inputFileName);
                var currentDirectory = Directory.GetCurrentDirectory();
                Console.Error.WriteLine($"Current directory is {currentDirectory}");
                throw new FileNotFoundException(
                    $"File {inputFileName} in directory {fileInfo.DirectoryName} does not exist.");
            }
            InputFileName = inputFileName;
        }
    }
}