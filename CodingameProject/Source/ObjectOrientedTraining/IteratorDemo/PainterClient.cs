using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    internal class PainterClient
    {
        public IPainter FindCheapestPainter(int squareMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .WithMinimum(painter => painter.EstimateCosts(squareMeters));
        }

        public IPainter FindFastestPainter(int squareMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(painter => painter.IsAvailable)
                .WithMinimum(painter => painter.EstimateDuration(squareMeters));
        }

        public IPainter WorkTogether(int squareMeters, IEnumerable<ProportionalPainter> painters)
        {
            int overallSpeed = 0;
            int sumOfEuroPerHour = 0;
            foreach (var painter in painters)
            {
                if (painter.IsAvailable)
                {
                    int durationInHours = painter.EstimateDuration(squareMeters).Hours;
                    overallSpeed += squareMeters / durationInHours;
                    sumOfEuroPerHour += painter.EstimateCosts(squareMeters) / durationInHours;
                }
            }

            TimeSpan timeForEntireWork =
                TimeSpan.FromHours(
                    1 / painters
                        .Where(p => p.IsAvailable)
                        .Select(p => (double)1 / p.EstimateDuration(squareMeters).Hours).Sum());

            var totalCosts = timeForEntireWork.Hours * sumOfEuroPerHour;
            return new ProportionalPainter(overallSpeed, sumOfEuroPerHour, true);
        }
    }
}