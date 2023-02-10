using System;
using System.CodeDom;
using Pluralsight.Tests;

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

        public bool TryAddCircle(Circle circle)
        {
            if (circle.Centre.X < 0 || circle.Centre.X > Length)
            {
                return false;
            }
            if (circle.Centre.Y < 0 || circle.Centre.Y - circle.Radius < 0)
            {
                return false;
            }
            if ((circle.Centre.X + circle.Radius < Length) && (circle.Centre.Y + circle.Radius < Width))
            {
                return true;
            }
            return false;
        }
    }
}