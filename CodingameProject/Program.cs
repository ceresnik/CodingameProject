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
            var circle = TryAddCircle(frame, 2, 3, 1);
            TryAddCircle(frame, 2, 2, 1);
            TryAddCircle(frame, 2, 5, 1);
            frame.Draw();

            //Defect #1: now reduce the vertical dimension of the frame
            /*
            Successfully added circle X:2, Y:3, radius:1
            Frame: Length (horizontal):5, Width (vertical):3
            Circle: X=2, Y=3, Radius=1.
             */
            frame.Width = 3;
            frame.Draw();

            //Defect #2: now change the already added circle's position
            /*
            Successfully added circle X:2, Y:2, radius:1
            Successfully added circle X:2, Y:3, radius:1
            Circle: X=2, Y=2, Radius=1.
            Circle: X=2, Y=2, Radius=1.
             */
            /*circle.Y = 2;
            frame.Draw();*/

            //Defect #3: change the circles from List<ICircle> to HashSet<ICircle>
            /*
            Successfully added circle X:2, Y:2, radius:1
            Successfully added circle X:2, Y:2, radius:2
            Circle: X=2, Y=2, Radius=2.
            Circle: X=2, Y=2, Radius=2.
             */
            /*circle.Radius = 2;
            TryAddCircle(frame, 2, 2, 2);
            frame.Draw();*/

            Console.ReadLine();
        }

        private static ICircle TryAddCircle(Frame frame, int x, int y, int radius)
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
            return circle;
        }
    }
}
