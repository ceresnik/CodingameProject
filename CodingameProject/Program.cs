using System;
using Pluralsight.Source;

namespace CodingameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var frame = new Frame
            {
                Width = 5,
                Length = 5
            };
            TryAddCircle(frame, 2, 2, 1);
            TryAddCircle(frame, 2, 3, 1);
            TryAddCircle(frame, 2, 2, 1);
            TryAddCircle(frame, 2, 5, 1);
            frame.Draw();
            Console.ReadLine();
        }

        private static void TryAddCircle(Frame frame, int x, int y, int radius)
        {
            var circle = new Circle
            {
                X = x,
                Y = y,
                Radius = radius
            };
            if (frame.TryAddCircle(circle))
            {
                Console.WriteLine($"Successfully added circle X:{x}, Y:{y}, radius:{radius}");
            }
            else
            {
                Console.WriteLine($"Did not manage to add circle X:{x}, Y:{y}, radius:{radius}");
            }

        }
    }
}
