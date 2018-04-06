using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    static class CompositePainterFactory
    {
        public static IPainter CreateGroup(IEnumerable<ProportionalPainter> sequenceOfPainters) 
            => new CompositePainter<ProportionalPainter>(sequenceOfPainters, EstimateDuration);

        private static TimeSpan EstimateDuration(IEnumerable<ProportionalPainter> proportionalPainters, int squareMeters)
        {
            TimeSpan timeForEntireWork =
                TimeSpan.FromMinutes(
                    1 / proportionalPainters
                        .Where(p => p.IsAvailable)
                        .Select(p => 1 / p.EstimateDuration(squareMeters).TotalMinutes)
                        .Sum());
            timeForEntireWork = TimeSpan.FromMinutes(Math.Round(timeForEntireWork.TotalMinutes, MidpointRounding.AwayFromZero));
            return timeForEntireWork;
        }

        public static IPainter CreateCheapestSelector(IEnumerable<IPainter> sequenceOfPainters, int squareMeters)
            => new Painters(sequenceOfPainters).ThoseAvailable.GetCheapest(squareMeters);
    }
}