using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    internal class CompositePainter<TPainter>:IPainter
        where TPainter:IPainter
    {
        public IEnumerable<TPainter> Painters { get; }

        private readonly Func<IEnumerable<TPainter>, int, TimeSpan> EstimateDurationFunc;

        public CompositePainter(IEnumerable<TPainter> sequenceOfPainters, 
            Func<IEnumerable<TPainter>, int, TimeSpan> estimateDurationFunc)
        {
            Painters = sequenceOfPainters;
            EstimateDurationFunc = estimateDurationFunc;
        }

        public bool IsAvailable => Painters.Any(painter => painter.IsAvailable);

        public TimeSpan EstimateDuration(int squareMeters)
        {
            return EstimateDurationFunc(Painters, squareMeters);
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