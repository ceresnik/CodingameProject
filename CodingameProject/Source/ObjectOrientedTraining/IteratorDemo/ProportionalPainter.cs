using System;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    class ProportionalPainter : IPainter
    {
        private readonly int euroPerHour;
        private TimeSpan timeForOneSquareMeter;

        public ProportionalPainter(TimeSpan timeForOneSquareMeter, int euroPerHour, bool isAvailable)
        {
            this.timeForOneSquareMeter = timeForOneSquareMeter;
            this.euroPerHour = euroPerHour;
            IsAvailable = isAvailable;
        }

        public bool IsAvailable { get; }

        public TimeSpan EstimateDuration(int squareMeters)
        {
            TimeSpan estimatedDuration = TimeSpan.FromMinutes(squareMeters * timeForOneSquareMeter.TotalMinutes);
            estimatedDuration = TimeSpan.FromMinutes(5 * Math.Ceiling(estimatedDuration.TotalMinutes / 5));
            return estimatedDuration;
        }

        public int EstimateCosts(int squareMeters)
        {
            var durationInHours = EstimateDuration(squareMeters).TotalHours;
            return (int)(euroPerHour * durationInHours);
        }

        public override bool Equals(object obj)
        {
            ProportionalPainter otherProportionalPainter = (ProportionalPainter)obj;
            if (otherProportionalPainter != null 
                && IsAvailable == otherProportionalPainter.IsAvailable 
                && timeForOneSquareMeter == otherProportionalPainter.timeForOneSquareMeter
                && euroPerHour == otherProportionalPainter.euroPerHour)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Painter: timeForOneSquareMeter: {timeForOneSquareMeter}, euroPerMeter: {euroPerHour}, available: {IsAvailable}";
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}