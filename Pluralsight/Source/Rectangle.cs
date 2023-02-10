using System;

namespace Pluralsight.Source
{
    internal class Rectangle
    {
        private int length;

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
        }
    }
}