namespace KGood.Source
{
    public class RobberyData
    {
        public RobberyData(int timeNeededByPolice, int wordsPerMinute, int timeAfterSentence, int timeAfterAllSentences, string inputSentence)
        {
            TimeNeededByPolice = timeNeededByPolice;
            WordsPerMinute = wordsPerMinute;
            TimeAfterSentence = timeAfterSentence;
            TimeAfterAllSentences = timeAfterAllSentences;
            InputSentence = inputSentence;
        }

        public int TimeNeededByPolice { get; }
        public int WordsPerMinute { get; }
        public int TimeAfterSentence { get; }
        public int TimeAfterAllSentences { get; }
        public string InputSentence { get; }
    }
}