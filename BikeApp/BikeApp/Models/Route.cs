using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace BikeApp.Models
{
    public class Route
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int Seconds { get; set; }
        public List<Position> MapPath { get; set; }

        public double GetDistanceInKm()
        {
            if (MapPath.Count < 2)
                return 0;

            double totalDistance = 0;

            for (int i = 0; i < MapPath.Count - 1; i++)
            {
                var start = MapPath[i];
                var end = MapPath[i + 1];
                totalDistance += Location.CalculateDistance(start.Latitude, start.Longitude, end.Latitude, end.Longitude, 0);
            }

            var result = Math.Round(totalDistance, 2);
            return result;
        }

        public string GetTotalTime()
        {
            var seconds = Seconds;

            int hours = seconds / 3600;
            seconds -= hours * 3600;

            int minutes = seconds / 60;
            seconds -= minutes * 60;

            if (hours > 0)
                return $"{hours}h {minutes}m {seconds}s";

            else if (minutes > 0)

                return $"{minutes}m {seconds}s";

            else
                return $"{seconds}s";
        }

        public double GetAvgSpeedInKmph()
        {
            var result = GetDistanceInKm() / (Convert.ToDouble(Seconds) / 3600);
            result = Math.Round(result, 2);

            return result;
        }

        public Polyline GetPolyline()
        {
            var result = new Polyline
            {
                StrokeColor = Color.Blue,
                StrokeWidth = 12,
            };

            foreach (var position in MapPath)
                result.Geopath.Add(position);

            return result;
        }
    }
}
