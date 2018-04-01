using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    internal class PainterService
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
            TimeSpan timeForEntireWork =
                TimeSpan.FromMinutes(
                    1 / painters
                        .Where(p => p.IsAvailable)
                        .Select(p => 1 / p.EstimateDuration(squareMeters).TotalMinutes).Sum());
            timeForEntireWork = TimeSpan.FromMinutes(5 * Math.Ceiling(timeForEntireWork.TotalMinutes / 5));

            double sumOfEuroPerHour = painters
                .Where(painter => painter.IsAvailable)
                .Select(painter => painter.EstimateCosts(squareMeters) / painter.EstimateDuration(squareMeters).TotalHours).Sum();

            return new ProportionalPainter(TimeSpan.FromMinutes(timeForEntireWork.TotalMinutes/squareMeters), (int)sumOfEuroPerHour, true);
        }
    }
}