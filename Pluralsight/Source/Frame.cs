using System;

namespace Pluralsight.Source
{
    internal class Frame
    {
        private double length;
        private double width;

        public double Length
        {
            get => length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length must be positive.");
                }
                length = value;
            }
            //but remember - letting an object to have it's dimension modifiable is very dangerous idea.
        }

        public double Width
        {
            get => width;
            set {
                if (value <= 0)
                {
                    throw new ArgumentException("Width must be positive.");
                }
                width = value;
            }
        }
    }
}