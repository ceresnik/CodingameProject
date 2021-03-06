﻿using System;
using System.IO;
using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class ElectionResultsReaderTests
    {
        private string inputDataDirectoryName = @"Tests\PresidentElection\InputData";

        [Test]
        public void ElectionResultsReaderObject_InitializedCorrectly()
        {
            //prepare
            var inputFileNameFullPath = FilePathProvider.ProvideFullPathToFile("TestResults.json", inputDataDirectoryName);

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
        public void Read_ReturnsCandidateNameElectionGainPairsObject()
        {
            //prepare
            var inputFileNameFullPath = FilePathProvider.ProvideFullPathToFile("TestResults.json", inputDataDirectoryName);
            var sut = new ElectionResultsReader(inputFileNameFullPath);

            //act
            CandidateNameElectionGainPairs candidateNameElectionGainPairs = sut.Read();

            //assert
            Assert.That(candidateNameElectionGainPairs, Is.TypeOf<CandidateNameElectionGainPairs>());
        }

        [Test]
        public void Read_ReturnedThreeCandidateNameElectionGainPairs()
        {
            //prepare
            var inputFileNameFullPath = FilePathProvider.ProvideFullPathToFile("TestResults.json", inputDataDirectoryName);
            var sut = new ElectionResultsReader(inputFileNameFullPath);

            //act
            CandidateNameElectionGainPairs candidateNameElectionGainPairs = sut.Read();
            foreach (var candidateNameElectionGainPair in candidateNameElectionGainPairs)
            {
                Console.Error.WriteLine($"candidate name: {candidateNameElectionGainPair.CandidateName}");
                Console.Error.WriteLine($"result in percent : {candidateNameElectionGainPair.ElectionGainInPercent}");
            }

            //assert
            Assert.That(candidateNameElectionGainPairs.Count, Is.EqualTo(3));
        }

        [Test]
        public void Read_ReadOutValuesFitWithValuesInFile()
        {
            //prepare
            var inputFileNameFullPath = FilePathProvider.ProvideFullPathToFile("TestResults.json", inputDataDirectoryName);
            var sut = new ElectionResultsReader(inputFileNameFullPath);

            //act
            CandidateNameElectionGainPairs candidateNameElectionGainPairs = sut.Read();

            //assert
            Assert.That(candidateNameElectionGainPairs[0].CandidateName, Is.EqualTo("TestCandidate1"));
            Assert.That(candidateNameElectionGainPairs[1].CandidateName, Is.EqualTo("TestCandidate2"));
            Assert.That(candidateNameElectionGainPairs[2].CandidateName, Is.EqualTo("TestCandidate3"));
            Assert.That(candidateNameElectionGainPairs[0].ElectionGainInPercent, Is.EqualTo(40));
            Assert.That(candidateNameElectionGainPairs[1].ElectionGainInPercent, Is.EqualTo(30));
            Assert.That(candidateNameElectionGainPairs[2].ElectionGainInPercent, Is.EqualTo(20));
        }
    }
}