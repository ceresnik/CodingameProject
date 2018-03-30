using System;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    class ProportionalPainter : IPainter
    {
        private readonly int squareMetersPerHour;
        private readonly int euroPerHour;

        public ProportionalPainter(int squareMetersPerHour, int euroPerHour, bool isAvailable)
        {
            this.squareMetersPerHour = squareMetersPerHour;
            this.euroPerHour = euroPerHour;
            IsAvailable = isAvailable;
        }

        public bool IsAvailable { get; }

        public TimeSpan EstimateDuration(int squareMeters)
        {
            return TimeSpan.FromHours(squareMeters/squareMetersPerHour);
        }

        public int EstimateCosts(int squareMeters)
        {
            var durationInHours = EstimateDuration(squareMeters).Hours;
            return euroPerHour * durationInHours;
        }

        public override bool Equals(object obj)
        {
            ProportionalPainter otherProportionalPainter = (ProportionalPainter)obj;
            if (otherProportionalPainter != null 
                && IsAvailable == otherProportionalPainter.IsAvailable 
                && squareMetersPerHour == otherProportionalPainter.squareMetersPerHour 
                && euroPerHour == otherProportionalPainter.euroPerHour)
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