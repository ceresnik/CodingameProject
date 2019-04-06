using System;
using System.IO;
using CodingameProject.Source.PresidentElection;
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
            var inputFileNameFullPath = ProvideFullPathToFile("TestResults.json");

            //act
            var sut = new ElectionResultsReader(inputFileNameFullPath);
            Console.WriteLine($"Full file name: {sut.InputFileName}");
            
            //assert
            Assert.That(sut.InputFileName, Is.EqualTo(inputFileNameFullPath));
        }

        [Test]
        public void InputFileDoesNotExist_ExceptionIsThrown()
        {
            var notExistingFile = "NotExistingFile.json";
            Assert.Throws<FileNotFoundException>(() => { new ElectionResultsReader(notExistingFile); });
        }

        [Test]
        public void Read_ReturnsElectionResultsObject()
        {
            //prepare
            var inputFileNameFullPath = ProvideFullPathToFile("TestResults.json");
            var sut = new ElectionResultsReader(inputFileNameFullPath);

            //act
            CandidateNameElectionGainPairs candidateNameElectionGainPairs = sut.Read();

            //assert
            Assert.That(candidateNameElectionGainPairs, Is.TypeOf<CandidateNameElectionGainPairs>());
        }

        [Test]
        public void Read_ReturnedElectionResultsContainsThreeObjects()
        {
            //prepare
            var inputFileNameFullPath = ProvideFullPathToFile("TestResults.json");
            var sut = new ElectionResultsReader(inputFileNameFullPath);

            //act
            CandidateNameElectionGainPairs candidateNameElectionGainPairs = sut.Read();
            foreach (var electionResult in candidateNameElectionGainPairs)
            {
                Console.Error.WriteLine($"candidate name: {electionResult.CandidateName}");
                Console.Error.WriteLine($"result in percent : {electionResult.ElectionGainInPercent}");
            }

            //assert
            Assert.That(candidateNameElectionGainPairs.Count, Is.EqualTo(3));
        }

        [Test]
        public void Read_ReadOutValuesFitWithValuesInFile()
        {
            //prepare
            var inputFileNameFullPath = ProvideFullPathToFile("TestResults.json");
            var sut = new ElectionResultsReader(inputFileNameFullPath);

            //act
            CandidateNameElectionGainPairs candidateNameElectionGainPairs = sut.Read();

            //assert
            Assert.That(candidateNameElectionGainPairs[0].CandidateName, Is.EqualTo("TestCandidate1"));
            Assert.That(candidateNameElectionGainPairs[1].CandidateName, Is.EqualTo("TestCandidate2"));
            Assert.That(candidateNameElectionGainPairs[2].CandidateName, Is.EqualTo("TestCandidate3"));
            Assert.That(candidateNameElectionGainPairs[0].ElectionGainInPercent, Is.EqualTo(21.11));
            Assert.That(candidateNameElectionGainPairs[1].ElectionGainInPercent, Is.EqualTo(22.22));
            Assert.That(candidateNameElectionGainPairs[2].ElectionGainInPercent, Is.EqualTo(23.33));
        }

        //TODO: extract to separate utility/helper
        private static string ProvideFullPathToFile(string fileName)
        {
            string baseDirectory = AppContext.BaseDirectory;
            string twoLevelsUp = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\"));
            string destinationDirectory = Path.Combine(twoLevelsUp, @"Tests\PresidentElection");
            return Path.GetFullPath(Path.Combine(destinationDirectory, fileName));
        }
    }
}