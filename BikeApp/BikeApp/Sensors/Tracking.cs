using BikeApp.Services.Alert;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace BikeApp.Sensors
{
    public class Tracking
    {
        //Variable that holds timer(triggers event that adds current location to list every 10 seconds)
        private static Timer timer;

        //This variable stores list of GPS locations collected every 10 seconds
        public static List<Position> GPSPositions { get; set; } = new List<Position>();

        public static int Seconds = 0;

        //This property stores state of GPS tracking
        public static bool IsEnabled { get; private set; }

        //Initializing timer
        public static void Initialize()
        {
            GPSPositions = new List<Position>();
            //10 sec interval
            timer = new Timer(2000);

            //Action executed every 10 seconds
            timer.Elapsed += OnTimedEvent;

            //Auto reset(timer resets every interval)
            //Enabled(timer triggers event every interval)
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        //Enable GPS tracking
        public static void Enable()
        {
            Geolocation.GetLocationAsync();
            Initialize();
            IsEnabled = true;
            timer.Start();
        }

        //Disable GPS tracking
        public static void Disable()
        {
            IsEnabled = false;
            timer.Dispose();
        }

        //Timer event
        private static void OnTimedEvent(object sender, ElapsedEventArgs e) => AddCurrentLocation();

        //Adding current location with exception handling
        internal async static void AddCurrentLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                    throw new FeatureNotEnabledException();

                GPSPositions.Add(new Position(location.Latitude, location.Longitude));
                Seconds += 5;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                AlertService.ShowMessage("Feature not supported", "This feature is not supported on your device.", "Ok");
                Disable();
            }
            catch (FeatureNotEnabledException fneEx)
            {
                AlertService.ShowMessage("Feature not enabled", "Location is not enabled", "Ok");
                Disable();
            }
            catch (PermissionException pEx)
            {
                AlertService.ShowMessage("Permission", "Permission error. Make sure this application has necessary permissions", "Ok");
                Disable();
            }
            catch (Exception ex)
            {
                AlertService.ShowMessage("Error", $"Unknown error: {ex.Message}", "Ok");
                Disable();
            }
        }
    }
}
