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

        private readonly Func<IEnumerable<TPainter>, int, int> EstimateCostsFunc;

        public CompositePainter(IEnumerable<TPainter> sequenceOfPainters, 
            Func<IEnumerable<TPainter>, int, TimeSpan> estimateDurationFunc, 
            Func<IEnumerable<TPainter>, int, int> estimateCostsFunc)
        {
            Painters = sequenceOfPainters;
            EstimateDurationFunc = estimateDurationFunc;
            EstimateCostsFunc = estimateCostsFunc;
        }

        public bool IsAvailable => Painters.Any(painter => painter.IsAvailable);

        public TimeSpan EstimateDuration(int squareMeters)
        {
            return EstimateDurationFunc(Painters, squareMeters);
        }

        public int EstimateCosts(int squareMeters)
        {
            return EstimateCostsFunc(Painters, squareMeters);
        }
    }
}