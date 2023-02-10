using System;

namespace Pluralsight.Source
{
    internal class Frame
    {
        private int length;
        private int width;

        public int Length
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

        public int Width
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