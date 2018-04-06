using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    static class CompositePainterFactory
    {
        public static IPainter CreateGroup(IEnumerable<ProportionalPainter> sequenceOfPainters) 
            => new CompositePainter<ProportionalPainter>(sequenceOfPainters, EstimateDuration, EstimateCosts);

        private static TimeSpan EstimateDuration(IEnumerable<ProportionalPainter> painters, int squareMeters)
        {
            TimeSpan timeForEntireWork =
                TimeSpan.FromMinutes(
                    1 / painters
                        .Where(p => p.IsAvailable)
                        .Select(p => 1 / p.EstimateDuration(squareMeters).TotalMinutes)
                        .Sum());
            timeForEntireWork = TimeSpan.FromMinutes(Math.Round(timeForEntireWork.TotalMinutes, MidpointRounding.AwayFromZero));
            return timeForEntireWork;
        }

        private static int EstimateCosts(IEnumerable<ProportionalPainter> painters, int squareMeters)
        {
            TimeSpan timeForEntireWork = EstimateDuration(painters, squareMeters);
            double totalCost = painters
                .Where(painter => painter.IsAvailable)
                .Select(painter =>
                            painter.EstimateCosts(squareMeters) /
                            painter.EstimateDuration(squareMeters).TotalHours *
                            timeForEntireWork.TotalHours)
                .Sum();
            return (int)totalCost;

        }

        public static IPainter CreateCheapestSelector(IEnumerable<IPainter> sequenceOfPainters, int squareMeters)
            => new Painters(sequenceOfPainters).ThoseAvailable.GetCheapest(squareMeters);
    }
}