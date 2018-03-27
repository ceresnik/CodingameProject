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
            int sumOfEuroPerHour = 0;

            foreach (var painter in painters)
            {
                if (painter.IsAvailable)
                {
                    int durationInHours = painter.EstimateDuration(squareMeters).Hours;
                    sumOfSpeeds += squareMeters / durationInHours;
                    sumOfEuroPerHour += painter.EstimateCosts(squareMeters) / durationInHours;
                }
            }
            return new Painter(sumOfSpeeds, sumOfEuroPerHour, true);
        }
    }
}