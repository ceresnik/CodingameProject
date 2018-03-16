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
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .OrderBy(x => x.EstimateCosts(squareMeters))
                    .FirstOrDefault();
            //.Aggregate((s1, s2) => s1.EstimateCosts(squareMeters) < s2.EstimateCosts(squareMeters) ? s1:s2);

            //return 
            //    painters
            //    .WhichAreAvailable()
            //    .WithMinimum(painter.EstimateCosts(squareMeters));
        }
    }
}