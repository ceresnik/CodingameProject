namespace CodingameProject.Source.CharacterUtilities
{
    class DefinedCount : AbstractCount
    {
        public DefinedCount(int count)
        {
            Count = count;
        }
        public override int Count { get; }
    }
}