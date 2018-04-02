using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    internal class PainterService
    {
        public IPainter FindCheapestAvailablePainter(int squareMeters, Painters painters)
        {
            return painters
                .ThoseAvailable
                .GetCheapest(squareMeters);
        }

        public IPainter FindCheapestPainter(int squareMeters, Painters painters)
        {
            return painters
                .GetCheapest(squareMeters);
        }

        public IPainter FindFastestAvailablePainter(int squareMeters, Painters painters)
        {
            return painters
                .ThoseAvailable
                .GetFastest(squareMeters);
        }

        public IPainter FindFastestPainter(int squareMeters, Painters painters)
        {
            return painters
                .GetFastest(squareMeters);
        }

        public IPainter WorkTogether(int squareMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan timeForEntireWork =
                TimeSpan.FromMinutes(
                    1 / painters
                        .Where(p => p.IsAvailable)
                        .Select(p => 1 / p.EstimateDuration(squareMeters).TotalMinutes)
                        .Sum());
            timeForEntireWork = TimeSpan.FromMinutes(2 * Math.Ceiling(timeForEntireWork.TotalMinutes / 2));

            double totalCost = painters
                .Where(painter => painter.IsAvailable)
                .Select(painter => 
                    painter.EstimateCosts(squareMeters) / 
                    painter.EstimateDuration(squareMeters).TotalHours * 
                    timeForEntireWork.TotalHours)
                .Sum();

            return new ProportionalPainter(
                TimeSpan.FromMinutes(timeForEntireWork.TotalMinutes/squareMeters), 
                (int)(totalCost/timeForEntireWork.TotalHours), 
                true);
        }
    }
}