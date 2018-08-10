namespace KGood.Source.StringDividing
{
    public class WordFactory : IWordFactory
    {
        public Word Create(string word)
        {
            return new Word(new MaybeString(word));
        }
    }
}