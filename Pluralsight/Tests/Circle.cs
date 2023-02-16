using System;

namespace Pluralsight.Tests
{
    internal class Circle : ICircle, IEquatable<ICircle>
    {
        private double radius;

        public double X { get; set; }
        public double Y { get; set; }
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

        public bool Equals(ICircle other)
        {
            //return other != null && Math.Abs(other.X - X) < 0.1 && Math.Abs(other.Y - Y) < 0.1
            //       && Math.Abs(other.Radius - Radius) < 0.1;
            return other != null && other.X == X && other.Y == Y && other.Radius == Radius;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ICircle);
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode() ^ X.GetHashCode() ^ Y.GetHashCode();
        }
    }

    internal interface ICircle
    {
        double X { get; set; }
        double Y { get; set; }
        double Radius { get; set; }
    }
}