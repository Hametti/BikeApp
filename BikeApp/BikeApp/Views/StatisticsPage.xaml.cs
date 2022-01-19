using BikeApp.Data.Routes;
using BikeApp.Data.Themes;
using BikeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : ContentPage
    {
        public StatisticsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateLayout();
            UpdateData();
        }

        private void UpdateData()
        {
            var avgSpeed = GetAverageSpeed();
            var avgTripTime = GetAverageTripTime();
            var avgTripDist = GetAverageTripDistance();
            var maxDist = GetMaxDistance();
            var minDist = GetMinDistance();
            var longestRoute = GetLongestRoute();
            var shortestRoute = GetShortestRoute();
            var totalRoutes = Routes.AllRoutes?.Count;

            AvgSpeed.Text = "Average speed: " + avgSpeed + " km/h";
            AvgTripTime.Text = "Average trip time: " + avgTripTime;
            AvgTripDist.Text = "Average trip distance: " + avgTripDist + " km";
            MaxDist.Text = "Maximum distance: " + maxDist + " km";
            MinDist.Text = "Minimum distance: " + minDist + " km";
            LongestRoute.Text = "Longest route: " + longestRoute;
            ShortestRoute.Text = "Shortest route: " + shortestRoute;
            TotalRoutes.Text = $"Total routes: " + totalRoutes;
        }

        private string GetShortestRoute()
        {
            var route = Routes.AllRoutes.OrderBy(r => r.Seconds).FirstOrDefault();

            if (route == null)
                return "Unknown";
            else 
                return route.GetTotalTime();
        }

        private string GetLongestRoute()
        {
            var route = Routes.AllRoutes.OrderByDescending(r => r.Seconds).FirstOrDefault();

            if (route == null)
                return "Unknown";
            else
                return route.GetTotalTime();
        }

        private string GetMinDistance()
        {
            var route = Routes.AllRoutes.OrderBy(r => r.GetDistanceInKm()).FirstOrDefault();

            if (route == null)
                return "Unknown";
            else
                return Math.Round(route.GetDistanceInKm(), 2).ToString();
        }

        private string GetMaxDistance()
        {
            var route = Routes.AllRoutes.OrderByDescending(r => r.GetDistanceInKm()).FirstOrDefault();

            if (route == null)
                return "Unknown";
            else
                return Math.Round(route.GetDistanceInKm(), 2).ToString();
        }

        private string GetAverageTripDistance()
        {
            if (Routes.AllRoutes.Count < 1)
                return "Unknown";

            double sum = 0;
            
            foreach (Route route in Routes.AllRoutes)
                sum += route.GetDistanceInKm();

            return Math.Round(sum, 2).ToString();
        }

        private string GetAverageTripTime()
        {
            if (Routes.AllRoutes.Count < 1)
                return "Unknown";

            int sum = 0;

            foreach (Route route in Routes.AllRoutes)
                sum += route.Seconds;

            int seconds = sum / Routes.AllRoutes.Count;

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

        private string GetAverageSpeed()
        {
            if (Routes.AllRoutes.Count < 1)
                return "Unknown";

            double totalDistance = 0;
            double totalTime = 0;

            foreach(Route route in Routes.AllRoutes)
            {
                totalDistance += route.GetDistanceInKm();
                totalTime += route.Seconds;
            }

            return Math.Round(totalDistance / (totalTime / 3600), 2).ToString();
        }

        private void UpdateLayout()
        {
            ((ContentPage)FindByName("Content")).BackgroundColor = Color.FromHex(CurrentTheme.BackgroundColor1);
            ((Label)FindByName("AvgSpeed")).TextColor = Color.FromHex(CurrentTheme.TextColor);
            ((Label)FindByName("AvgTripTime")).TextColor = Color.FromHex(CurrentTheme.TextColor);
            ((Label)FindByName("AvgTripDist")).TextColor = Color.FromHex(CurrentTheme.TextColor);
            ((Label)FindByName("MaxDist")).TextColor = Color.FromHex(CurrentTheme.TextColor);
            ((Label)FindByName("MinDist")).TextColor = Color.FromHex(CurrentTheme.TextColor);
            ((Label)FindByName("LongestRoute")).TextColor = Color.FromHex(CurrentTheme.TextColor);
            ((Label)FindByName("ShortestRoute")).TextColor = Color.FromHex(CurrentTheme.TextColor);
            ((Label)FindByName("TotalRoutes")).TextColor = Color.FromHex(CurrentTheme.TextColor);
        }
    }
}