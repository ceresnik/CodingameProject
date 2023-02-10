using System;
using System.Drawing;

namespace Pluralsight.Tests
{
    internal class Circle
    {
        private double radius;

        public double Radius
        {
            get => radius;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius must not be negative.");
                }
                radius = value;
            }
        }

        public Point Centre { get; set; }
    }
}