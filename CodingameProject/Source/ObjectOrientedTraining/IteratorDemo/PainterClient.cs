using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    internal class PainterClient
    {
        public IPainter FindCheapestPainter(int squareMeters, IEnumerable<IPainter> painters)
        {
            //int bestCost = 10000;
            //IPainter cheapestPainter = null;
            //foreach (var painter in painters)
            //{
            //    if (painter.IsAvailable)
            //    {
            //        int price = painter.EstimateCosts(squareMeters);
            //        if (cheapestPainter == null || price < bestCost)
            //        {
            //            bestCost = price;
            //            cheapestPainter = painter;
            //        }
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

        public IPainter FindFastestPainter(int squareMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(painter => painter.IsAvailable)
                .WithMinimum(painter => painter.EstimateDuration(squareMeters));
        }

        public IPainter WorkTogether(int squareMeters, IList<IPainter> painters)
        {
            int totalCostsEachPainterSeparate = 0;
            //int totalDurationEachPainterSeparate = 0;
            int totalSpeedAllPainters = 0;
            foreach (var painter in painters)
            {
                if (painter.IsAvailable)
                {
                    totalCostsEachPainterSeparate = painter.EstimateCosts(squareMeters);
                    //totalDurationEachPainterSeparate += painter.EstimateDuration(squareMeters).Hour;
                    totalSpeedAllPainters += squareMeters / painter.EstimateDuration(squareMeters).Hour;
                }
            }
            int averageCostsPerMeter = 
                totalCostsEachPainterSeparate / squareMeters * painters.Count(painter => painter.IsAvailable);
            //int totalDurationAllPaintersParallel = 
            //    totalDurationEachPainterSeparate / painters.Count(painter => painter.IsAvailable);
            int totalDurationAllPaintersParallel = squareMeters / totalSpeedAllPainters;
            return new Painter(squareMeters / totalSpeedAllPainters, averageCostsPerMeter, true);
        }
    }
}