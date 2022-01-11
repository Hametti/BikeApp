using Android.Locations;
using BikeApp.Services.Alert;
using BikeApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Android.Content;

namespace BikeApp.Sensors
{
    public class Location
    {
        private static MapPage currentInstance;
        public static Position Position { get; set; } = new Position(49.61670746702909, 20.715038889839153);

        internal async static void UpdateLocation(MapPage contentPage)
        {
            currentInstance = contentPage;
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                    throw new FeatureNotEnabledException();

                Position = new Position(location.Latitude, location.Longitude);

                //Polyline polyline = new Polyline
                //{
                //    StrokeColor = Color.Blue,
                //    StrokeWidth = 12,
                //    Geopath =
                //    {
                //        new Position(49.58514665724434, 20.715647442036513),
                //        new Position(49.582826187575115, 20.71954282098077),
                //        new Position(49.582182751417896, 20.72559924868848),
                //        new Position(49.582558380046976, 20.72669359000185),
                //        new Position(49.58553906764385, 20.72585284675587),
                //    }
                //};

                //contentPage.AddRoute(polyline);
                contentPage.UpdateMap();

                
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                AlertService.ShowMessage("Feature not supported", "This feature is not supported on your device.", "Ok");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                AlertService.ShowMessage("Location", "Location is not enabled", "Ok");
            }
            catch (PermissionException pEx)
            {
                AlertService.ShowMessage("Permission", "Permission error. Make sure this application has necessary permissions", "Ok");
            }
            catch (Exception ex)
            {
                AlertService.ShowMessage("Error", $"Unknown error: {ex.Message}", "Ok");
            }
        }

        public static bool IsGpsEnabled()
        {
            LocationManager locationManager = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);
            return locationManager.IsProviderEnabled(LocationManager.GpsProvider);
        }
    }
}
