using System.Collections.Generic;
using System.Linq;
using CodingameProject.Source.ObjectOrientedTraining.IteratorDemo;

namespace CodingameProject
{
    class Program
    {
        private static IPainter FindCheapestPainter(int squareMeters, IEnumerable<IPainter> painters)
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

        static void Main(string[] args)
        {
            IEnumerable<IPainter> painters = new List<IPainter>
                                             {
                                                 new Painter(2, 3, true),
                                                 new Painter(4, 7, false),
                                                 new Painter(1, 5, true),
                                                 new Painter(5, 2, true),
                                                 new Painter(9, 3, false)
                                             };
            var cheapestPainter = FindCheapestPainter(10, painters);
        }
    }
}
