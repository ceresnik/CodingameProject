using CodingameProject.Source.PresidentElection;
using NUnit.Framework;

namespace CodingameProject.Tests.PresidentElection
{
    [TestFixture]
    public class EvaluatedTipTests
    {
        [Test]
        public void EvaluatedTipObject_InitializedCorrectly()
        {
            string tipperName = "TipperName1";
            double score = 3.9;

            //act
            var sut = new EvaluatedTip(tipperName, score);

            //verify
            Assert.That(sut.TipperName, Is.EqualTo(tipperName));
            Assert.That(sut.Score, Is.EqualTo(score));
        }
    }
}