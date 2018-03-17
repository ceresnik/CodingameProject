using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    internal class PainterClient
    {
        public IPainter FindCheapestPainterOldFashioned(int squareMeters, IEnumerable<IPainter> painters)
        {
            IPainter result = painters.ElementAt(0);
            foreach (var painter in painters)
            {
                if (painter.IsAvailable)
                {
                    if (painter.EstimateCosts(squareMeters) < result.EstimateCosts(squareMeters))
                    {
                        result = painter;
                    }
                }
            }
            return result;
        }

        public IPainter FindCheapestPainter(int squareMeters, IEnumerable<IPainter> painters)
        {
            //int bestCost = 10000;
            //IPainter cheapestPainter = null;
            //foreach (var painter in painters)
            //{
            //    int price = painter.EstimateCosts(squareMeters);
            //    if (cheapestPainter == null || price < bestCost)
            //    {
            //        bestCost = price;
            //        cheapestPainter = painter;
            //    }
            //}
            //return cheapestPainter;
            //return
            //    painters
            //        .Where(painter => painter.IsAvailable)
            //        .Aggregate((IPainter)null, (best, current)
            //                                       => best == null ||
            //                                          best.EstimateCosts(squareMeters) > current.EstimateCosts(squareMeters)
            //                                           ? current
            //                                           : best);
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .WithMinimum(painter => painter.EstimateCosts(squareMeters));
        }
    }
}