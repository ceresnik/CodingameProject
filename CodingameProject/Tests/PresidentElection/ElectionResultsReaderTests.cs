﻿using System;
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
            var inputFileNameFullPath = ProvidePathToTestFile("TestResults.json");
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
            var inputFileNameFullPath = ProvidePathToTestFile("TestResults.json");
            var sut = new ElectionResultsReader(inputFileNameFullPath);

            //act
            ElectionResults electionResults = sut.Read();

            //assert
            Assert.That(electionResults, Is.TypeOf<ElectionResults>());
        }

        [Test]
        public void Read_ReturnedElectionResultsContainsThreeObjects()
        {
            //prepare
            var inputFileNameFullPath = ProvidePathToTestFile("TestResults.json");
            var sut = new ElectionResultsReader(inputFileNameFullPath);

            //act
            ElectionResults electionResults = sut.Read();
            foreach (var electionResult in electionResults)
            {
                Console.Error.WriteLine($"candidate name: {electionResult.CandidateName}");
                Console.Error.WriteLine($"result in percent : {electionResult.ResultInPercent}");
            }

            //assert
            Assert.That(electionResults.Count, Is.EqualTo(3));
        }

        [Test]
        public void Read_ReadOutValuesFitWithValuesInFile()
        {
            //prepare
            var inputFileNameFullPath = ProvidePathToTestFile("TestResults.json");
            var sut = new ElectionResultsReader(inputFileNameFullPath);

            //act
            ElectionResults electionResults = sut.Read();

            //assert
            Assert.That(electionResults[0].CandidateName, Is.EqualTo("TestCandidate1"));
            Assert.That(electionResults[1].CandidateName, Is.EqualTo("TestCandidate2"));
            Assert.That(electionResults[2].CandidateName, Is.EqualTo("TestCandidate3"));
            Assert.That(electionResults[0].ResultInPercent, Is.EqualTo(21.11));
            Assert.That(electionResults[1].ResultInPercent, Is.EqualTo(22.22));
            Assert.That(electionResults[2].ResultInPercent, Is.EqualTo(23.33));
        }

        private static string ProvidePathToTestFile(string resultsFileName)
        {
            var testResultsFileName = resultsFileName;
            string baseDirectory = AppContext.BaseDirectory;
            string twoLevelsUp = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\"));
            string directoryWithResultsFile = Path.Combine(twoLevelsUp, @"Tests\PresidentElection");
            string fileNameFullPath = Path.GetFullPath(Path.Combine(directoryWithResultsFile, testResultsFileName));
            return fileNameFullPath;
        }
    }
}