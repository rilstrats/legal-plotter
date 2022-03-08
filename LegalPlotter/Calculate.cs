using System;
using System.Collections.Generic;

namespace LegalPlotter
{
    public static class Calculate
    {

        public static (double, double) CalculateLine((double, double) previousPoint, Dictionary<string, string> segment)
        {
            (int, int) quadMods = DetermineQuadrant(segment);
            double radians = DegreeToRadian(segment);
            (double, double) delta = CalculateDelta(segment, radians, quadMods);
            (double, double) newPoint = CalculatePoint(previousPoint, delta);

            return newPoint;
        }


        public static (int, int) DetermineQuadrant(Dictionary<string, string> segment)
        {
            int vertical = 0;
            if (segment["vertical"] == "N" || segment["vertical"] == "NORTH")
            {
                vertical = 1;
            }
            else if (segment["vertical"] == "S" || segment["vertical"] == "SOUTH")
            {
                vertical = -1;
            }

            int horizontal = 0;
            if (segment["horizontal"] == "E" || segment["horizontal"] == "EAST")
            {
                horizontal = 1;
            }
            else if (segment["horizontal"] == "W" || segment["horizontal"] == "WEST")
            {
                horizontal = -1;
            }

            return (horizontal, vertical);
        }

        public static double DegreeToRadian(Dictionary<string, string> segment)
        {
            double seconds = Convert.ToDouble(segment["seconds"]) / 60;
            double minutes = (Convert.ToDouble(segment["minutes"]) + seconds) / 60;
            double degrees = Convert.ToDouble(segment["degrees"]) + minutes;

            double radians = degrees * Math.PI / 180;
            return radians;
        }

        public static (double, double) CalculateDelta(Dictionary<string, string> segment, double radians, (int, int) quadMods)
        {
            double distance = Convert.ToDouble(segment["distance"]);

            double distanceX = Math.Cos(radians) * distance * quadMods.Item1;
            double distanceY = Math.Sin(radians) * distance * quadMods.Item2;

            return (distanceX, distanceY);
        }

        public static (double, double) CalculatePoint((double, double) previousPoint, (double, double) delta)
        {
            double newX = previousPoint.Item1 + delta.Item1;
            double newY = previousPoint.Item2 + delta.Item2;

            return (newX, newY);

        }

        public static (double, double) CalculateCurve(
            (double, double) previousPoint, 
            Dictionary<string, string> segment)
        {
            throw new NotImplementedException();
        }
    }
}
