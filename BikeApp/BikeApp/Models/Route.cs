using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using Xamarin.Forms;

namespace BikeApp.Models
{
    public class Route
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public List<Position> MapPath { get; set; }

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
