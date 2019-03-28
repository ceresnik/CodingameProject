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
            //prepare
            var testResultsFileName = "TestResults.json";
            string baseDirectory = AppContext.BaseDirectory;
            string twoLevelsUp = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\"));
            string directoryWithResultsFile = Path.Combine(twoLevelsUp, @"Tests\PresidentElection");
            string inputFileNameWithFullPath = Path.GetFullPath(Path.Combine(directoryWithResultsFile, testResultsFileName));
            
            //act
            var sut = new ElectionResultsReader(inputFileNameWithFullPath);
            Console.WriteLine($"Full file name: {sut.InputFileName}");
            
            //assert
            Assert.That(sut.InputFileName, Is.EqualTo(inputFileNameWithFullPath));
        }

        [Test]
        public void InputFileDoesNotExist_ExceptionIsThrown()
        {
            var notExistingFile = "NotExistingFile.json";
            Assert.Throws<FileNotFoundException>(() => { new ElectionResultsReader(notExistingFile); });
        }
    }
}