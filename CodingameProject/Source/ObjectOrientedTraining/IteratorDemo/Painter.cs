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
            this.euroPerSquareMeter = euroPerSquareMeter;
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
            return euroPerSquareMeter * squareMeters;
        }

        public override bool Equals(object obj)
        {
            Painter otherPainter = (Painter)obj;
            if (otherPainter != null 
                && IsAvailable == otherPainter.IsAvailable 
                && squareMetersPerHour == otherPainter.squareMetersPerHour 
                && euroPerSquareMeter == otherPainter.euroPerSquareMeter)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Painter: metersPerHour: {squareMetersPerHour}, euroPerMeter: {euroPerSquareMeter}, available: {IsAvailable}";
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}