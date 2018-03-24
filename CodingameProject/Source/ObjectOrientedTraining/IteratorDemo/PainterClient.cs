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

        public IPainter WorkTogether(int squareMeters, IList<IPainter> painters)
        {
            int sumOfSpeeds = 0;
            int sumOfCosts = 0;
            foreach (var painter in painters)
            {
                if (painter.IsAvailable)
                {
                    sumOfSpeeds += squareMeters / painter.EstimateDuration(squareMeters).Hours;
                    sumOfCosts += painter.EstimateCosts(squareMeters) / squareMeters;
                }
            }
            return new Painter(sumOfSpeeds, sumOfCosts, true);
        }
    }
}