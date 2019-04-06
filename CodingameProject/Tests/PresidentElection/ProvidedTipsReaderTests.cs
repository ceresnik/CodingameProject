using System;
using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class ProvidedTipsReaderTests
    {
        [Test]
        public void ProvidedTipsReaderObject_InitializedCorrectly()
        {
            //prepare
            string inputFileName = "TestTips.json";

            //act
            var sut = new ProvidedTipsReader(inputFileName);
            Console.Error.WriteLine($"Full file name: {sut.InputFileName}");

            //verify
            Assert.That(sut.InputFileName, Is.EqualTo(inputFileName));
        }

        [Ignore("Not implemented.")]
        [Test]
        public void Read()
        {
            var sut = new ProvidedTipsReader("TestTips.json");
            ProvidedTips providedTips = sut.Read();
        }
    }

    public class ProvidedTips
    {
    }
}