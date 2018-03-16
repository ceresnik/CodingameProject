using System;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    class Painter : IPainter
    {
        private readonly int squareMetersPerHour;
        private readonly int euroPerSquareMeter;

        public Painter(int squareMetersPerHour, int euroPerSquareMeter, bool isAvailable)
        {
            this.squareMetersPerHour = squareMetersPerHour;
            IsAvailable = isAvailable;
            this.euroPerSquareMeter = euroPerSquareMeter;
        }

        public bool IsAvailable { get; }

        public DateTime EstimateDuration(int squareMeters)
        {
            var durationInHours = squareMeters/squareMetersPerHour;
            return new DateTime().Date.AddHours(durationInHours);
        }

        public int EstimateCosts(int squareMeters)
        {
            return squareMeters * euroPerSquareMeter;
        }

        public override bool Equals(object obj)
        {
            Painter otherPainter = (Painter)obj;
            if (otherPainter != null && IsAvailable == otherPainter.IsAvailable && squareMetersPerHour == otherPainter.squareMetersPerHour && euroPerSquareMeter == otherPainter.euroPerSquareMeter)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}