using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    internal class PaintingGroup:IPainter
    {
        public IEnumerable<IPainter> Painters { get; }

        public PaintingGroup(IEnumerable<IPainter> sequenceOfPainters)
        {
            Painters = sequenceOfPainters;
        }

        public bool IsAvailable => Painters.Any(painter => painter.IsAvailable);

        public TimeSpan EstimateDuration(int squareMeters)
        {
            TimeSpan timeForEntireWork =
                TimeSpan.FromMinutes(
                    1 / Painters
                        .Where(p => p.IsAvailable)
                        .Select(p => 1 / p.EstimateDuration(squareMeters).TotalMinutes)
                        .Sum());
            timeForEntireWork = TimeSpan.FromMinutes(Math.Round(timeForEntireWork.TotalMinutes, MidpointRounding.AwayFromZero));
            return timeForEntireWork;
        }

        public int EstimateCosts(int squareMeters)
        {
            TimeSpan timeForEntireWork = EstimateDuration(squareMeters);
            double totalCost = Painters
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