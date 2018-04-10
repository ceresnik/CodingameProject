using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    internal class CombiningPainter:CompositePainter<IPainter>
    {
        public CombiningPainter(IEnumerable<ProportionalPainter> sequenceOfPainters) 
            : base(sequenceOfPainters, 
                  EstimateDurationForGroupOfPainters, 
                  EstimateCostsForGroupOfPainters)
        {
        }

        private static TimeSpan EstimateDurationForGroupOfPainters(IEnumerable<IPainter> sequenceOfPainters, int squareMeters)
        {
            TimeSpan timeForEntireWork =
                TimeSpan.FromMinutes(
                    1 / sequenceOfPainters
                        .Where(p => p.IsAvailable)
                        .Select(p => 1 / p.EstimateDuration(squareMeters).TotalMinutes)
                        .Sum());
            timeForEntireWork = TimeSpan.FromMinutes(Math.Round(timeForEntireWork.TotalMinutes, MidpointRounding.AwayFromZero));
            return timeForEntireWork;
        }

        private static int EstimateCostsForGroupOfPainters(IEnumerable<IPainter> sequenceOfPainters, int squareMeters)
        {
            TimeSpan timeForEntireWork = EstimateDurationForGroupOfPainters(sequenceOfPainters, squareMeters);
            double totalCost = sequenceOfPainters
                .Where(painter => painter.IsAvailable)
                .Select(painter =>
                            painter.EstimateCosts(squareMeters) /
                            painter.EstimateDuration(squareMeters).TotalHours *
                            timeForEntireWork.TotalHours)
                .Sum();
            return (int)totalCost;

        }
    }
}