using KGood.Source.StringDividing;
using Moq;
using NUnit.Framework;

namespace KGood.Tests.StringDividing
{
    [TestFixture]
    public class StringDividerTests
    {
        [Test]
        [Ignore("Will be some interaction test.")]
        public void Todo()
        {
            var mWordFactory = new Mock<IWordFactory>();
            string inputWord = "aab";
            mWordFactory.Setup(x => x.Create(inputWord))
                .Returns(new Word(new MaybeString(inputWord)));
            var sut = new StringDivider(mWordFactory.Object, new WordSplitter());
            var result = sut.Divide(inputWord, 2);

        }
    }
}