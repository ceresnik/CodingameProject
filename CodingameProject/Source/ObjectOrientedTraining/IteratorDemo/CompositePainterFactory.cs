using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    static class CompositePainterFactory
    {
        public static IPainter CreateGroup(IEnumerable<ProportionalPainter> sequenceOfPainters) 
            => new CompositePainter<ProportionalPainter>(sequenceOfPainters, EstimateDurationForGroupOfPainters, EstimateCostsForGroupOfPainters);

        private static TimeSpan EstimateDurationForGroupOfPainters(IEnumerable<ProportionalPainter> sequenceOfPainters, int squareMeters)
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

        private static int EstimateCostsForGroupOfPainters(IEnumerable<ProportionalPainter> sequenceOfPainters, int squareMeters)
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

        public static IPainter CreateCheapestSelector(IEnumerable<IPainter> sequenceOfPainters, int squareMeters)
            => new CompositePainter<IPainter>(sequenceOfPainters, EstimateDurationForOnePainter, EstimateCostsForOnePainter);

        public static IPainter CreateFastestSelector(IEnumerable<IPainter> sequenceOfPainters, int squareMeters)
        {
            return new CompositePainter<IPainter>(sequenceOfPainters, EstimateDurationForOnePainter, EstimateCostsForOnePainter);
        }

        private static TimeSpan EstimateDurationForOnePainter(IEnumerable<IPainter> painters, int squareMeters)
        {
            return new Painters(painters).ThoseAvailable.GetCheapest(squareMeters).EstimateDuration(squareMeters);
        }

        private static int EstimateCostsForOnePainter(IEnumerable<IPainter> painters, int squareMeters)
        {
            return new Painters(painters).ThoseAvailable.GetCheapest(squareMeters).EstimateCosts(squareMeters);
        }
    }
}