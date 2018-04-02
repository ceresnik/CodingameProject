using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    public class Painters
    {
        private readonly IEnumerable<IPainter> painters;

        public Painters(IEnumerable<IPainter> painters)
        {
            this.painters = painters;
        }

        public Painters ThoseAvailable
        {
            get { return new Painters(painters.Where(painter => painter.IsAvailable)); }
        }

        public IPainter GetCheapest(int squareMeters)
        {
            return painters.WithMinimum(painter => painter.EstimateDuration(squareMeters));
        }

        internal IPainter GetFastest(int squareMeters)
        {
            return painters.WithMinimum(painter => painter.EstimateDuration(squareMeters));
        }
    }
}