using System;

namespace Pluralsight.Source
{
    public class Circle : ICircle, IEquatable<ICircle>
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

        public void Draw()
        {
            Console.WriteLine($"Circle: X={X}, Y={Y}, Radius={radius}.");
        }
    }
}