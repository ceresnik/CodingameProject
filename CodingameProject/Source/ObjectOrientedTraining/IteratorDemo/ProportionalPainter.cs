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

        /// <summary>
        /// Estimates duration for given area in m2.
        /// </summary>
        /// <remarks>Accuracy is two minutes, rounding up.</remarks>
        /// <example>Calculated duration 62 minutes is not changed.</example>
        /// <example>Calculated duration 63 minutes is adapted to 64 minutes.</example>
        /// <param name="squareMeters"></param>
        /// <returns></returns>
        public TimeSpan EstimateDuration(int squareMeters)
        {
            TimeSpan estimatedDuration = TimeSpan.FromMinutes(squareMeters * timeForOneSquareMeter.TotalMinutes);
            estimatedDuration = TimeSpan.FromMinutes(Math.Round(estimatedDuration.TotalMinutes, MidpointRounding.AwayFromZero));
            return estimatedDuration;
        }

        public int EstimateCosts(int squareMeters)
        {
            var durationInHours = EstimateDuration(squareMeters).TotalHours;
            return (int)Math.Round(euroPerHour * durationInHours, MidpointRounding.AwayFromZero);
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