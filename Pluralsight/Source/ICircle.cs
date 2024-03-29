﻿namespace Pluralsight.Source
{
    public interface ICircle
    {
        double X { get; set; }
        double Y { get; set; }
        double Radius { get; set; }
        void Draw();
    }
}