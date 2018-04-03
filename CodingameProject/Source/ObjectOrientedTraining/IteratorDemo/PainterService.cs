using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingameProject.Source.ObjectOrientedTraining.IteratorDemo
{
    internal class PainterService
    {
        public IPainter WorkTogether(int squareMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan timeForEntireWork =
                TimeSpan.FromMinutes(
                    1 / painters
                        .Where(p => p.IsAvailable)
                        .Select(p => 1 / p.EstimateDuration(squareMeters).TotalMinutes)
                        .Sum());
            timeForEntireWork = TimeSpan.FromMinutes(2 * Math.Ceiling(timeForEntireWork.TotalMinutes / 2));

            //TimeSpan time =  painters.ThoseAvailable.EstimateTimeForEntireWork(squareMeters);
            //double cost = painters.ThoseAvailable.EstimateTotalCosts(squareMeters);
            //IPainter result = painters.WorkTogether(squareMeters);

            PaintingGroup paintingGroup = new PaintingGroup(painters);
            //paintingGroup.EstimateDuration(squareMeters);
            //paintingGroup.EstimateCosts(squareMeters);

            double totalCost = painters
                .Where(painter => painter.IsAvailable)
                .Select(painter => 
                    painter.EstimateCosts(squareMeters) / 
                    painter.EstimateDuration(squareMeters).TotalHours * 
                    timeForEntireWork.TotalHours)
                .Sum();

            return new ProportionalPainter(
                TimeSpan.FromMinutes(timeForEntireWork.TotalMinutes/squareMeters), 
                (int)(totalCost/timeForEntireWork.TotalHours), 
                true);
        }
    }
}