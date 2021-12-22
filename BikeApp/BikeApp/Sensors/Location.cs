using BikeApp.Services.Alert;
using BikeApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

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

                if (location != null)
                    Position = new Position(location.Latitude, location.Longitude);


                Polyline polyline = new Polyline
                {
                    StrokeColor = Color.Blue,
                    StrokeWidth = 12,
                    Geopath =
                    {
                        new Position(49.58514665724434, 20.715647442036513),
                        new Position(49.582826187575115, 20.71954282098077),
                        new Position(49.582182751417896, 20.72559924868848),
                        new Position(49.582558380046976, 20.72669359000185),
                        new Position(49.58553906764385, 20.72585284675587),
                    }
                };

                contentPage.AddRoute(polyline);
                contentPage.UpdateMap();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}
