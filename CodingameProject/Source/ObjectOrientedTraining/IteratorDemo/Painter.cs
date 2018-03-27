using System;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    class Painter : IPainter
    {
        private readonly int squareMetersPerHour;
        private readonly int euroPerHour;

        public Painter(int squareMetersPerHour, int euroPerHour, bool isAvailable)
        {
            this.squareMetersPerHour = squareMetersPerHour;
            this.euroPerHour = euroPerHour;
            IsAvailable = isAvailable;
        }

        public bool IsAvailable { get; }

        public TimeSpan EstimateDuration(int squareMeters)
        {
            var durationInHours = squareMeters/squareMetersPerHour;
            return new TimeSpan(0, durationInHours, 0, 0);
        }

        public int EstimateCosts(int squareMeters)
        {
            var durationInHours = EstimateDuration(squareMeters).Hours;
            return euroPerHour * durationInHours;
        }

        public override bool Equals(object obj)
        {
            Painter otherPainter = (Painter)obj;
            if (otherPainter != null 
                && IsAvailable == otherPainter.IsAvailable 
                && squareMetersPerHour == otherPainter.squareMetersPerHour 
                && euroPerHour == otherPainter.euroPerHour)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Painter: metersPerHour: {squareMetersPerHour}, euroPerMeter: {euroPerHour}, available: {IsAvailable}";
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}