using System;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    public interface IPainter
    {
        bool IsAvailable { get; }
        DateTime EstimateDuration(int squareMeters);
        int EstimateCosts(int squareMeters);
    }
}