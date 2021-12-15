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
