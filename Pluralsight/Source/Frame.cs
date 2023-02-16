using System;
using System.Collections.Generic;

namespace Pluralsight.Source
{
    public class Frame
    {
        /*
         * -------------------------------
         * - W                           -
         * - i                           -
         * - d                           -
         * - t                           -
         * - h                           -
         * -                             -
         * -                             -
         * -          Length             -
         * -------------------------------
         */
        private double length;
        private double width;
        private readonly ICollection<ICircle> circles = new List<ICircle>();

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

        public int CirclesCount => circles.Count;

        public bool TryAddCircle(ICircle circle)
        {
            if (circle.X < 0 || circle.X > Length)
            {
                return false;
            }
            if (circle.Y < 0 || circle.Y > Width)
            {
                return false;
            }
            if (circle.X - circle.Radius < 0 || circle.Y - circle.Radius < 0)
            {
                return false;
            }
            if (circle.X + circle.Radius <= Length && circle.Y + circle.Radius <= Width)
            {
                if (circles.Contains(circle) == false)
                {
                    circles.Add(circle);
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            Console.WriteLine($"Frame: Length (horizontal):{Length}, Width (vertical):{Width}");
            foreach (var circle in circles)
            {
                circle.Draw();
            }
        }
    }
}