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

        public IEnumerable<IPainter> ThoseAvailable
        {
            get { return painters.Where(painter => painter.IsAvailable); }
        }
    }
}