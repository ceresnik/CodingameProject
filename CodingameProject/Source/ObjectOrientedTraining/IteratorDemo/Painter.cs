/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
using System;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    class Painter : IPainter
    {
        private readonly int squareMetersPerHour;
        private readonly int euroPerSquareMeter;

        public Painter(int squareMetersPerHour, int euroPerSquareMeter, bool isAvailable)
        {
            this.squareMetersPerHour = squareMetersPerHour;
            IsAvailable = isAvailable;
            this.euroPerSquareMeter = euroPerSquareMeter;
        }

        public bool IsAvailable { get; }

        public DateTime EstimateDuration(int squareMeters)
        {
            var durationInHours = squareMeters/squareMetersPerHour;
            return new DateTime().Date.AddHours(durationInHours);
        }

        public int EstimateCosts(int squareMeters)
        {
            return squareMeters * euroPerSquareMeter;
        }
    }
}