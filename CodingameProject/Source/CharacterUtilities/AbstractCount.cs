namespace CodingameProject.Source.CharacterUtilities
{
    abstract class AbstractCount : ICount
    {
        public virtual int Count { get; }

        public override bool Equals(object obj)
        {
            var item = obj as AbstractCount;
            if (item == null)
            {
                return false;
            }

            return this.Count == item.Count;
        }

        public override int GetHashCode()
        {
            return this.Count.GetHashCode();
        }
    }
}