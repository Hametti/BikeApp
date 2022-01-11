using Acr.UserDialogs;
using BikeApp.Data.Themes;
using BikeApp.Sensors;
using BikeApp.Services.Alert;
using System;
using System.ComponentModel;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeApp.Views
{
    public partial class TrackingPage : ContentPage
    {
        public TrackingPage()
        {
            InitializeComponent();
        }

        //Initializing timer
        private Timer GpsEnabledValidation;
        public void Initialize()
        {
            //10 sec interval
            GpsEnabledValidation = new Timer(5000);

            //Action executed every 10 seconds
            GpsEnabledValidation.Elapsed += OnTimedEvent;

            //Auto reset(timer resets every interval)
            //Enabled(timer triggers event every interval)
            GpsEnabledValidation.AutoReset = true;
            GpsEnabledValidation.Enabled = true;
        }

        public void EnableTimer()
        {
            Initialize();
            IsEnabled = true;
            GpsEnabledValidation.Start();
        }

        public void DisableTimer()
        {
            GpsEnabledValidation.Dispose();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if(!Location.IsGpsEnabled())
            {
                DisableTimer();
                if (Tracking.GPSPositions.Count > 1)
                {
                    Tracking.Disable();
                    AddNewTrail();
                    UpdateButtonText();
                }
                else
                {
                    AlertService.ShowMessage("Tracking", "Tracking disabled", "Ok");
                    Tracking.Disable();
                    UpdateButtonText();
                }
            }
        }

        void Button_Clicked(object sender, System.EventArgs e)
        {
            var state = TrackingButton.Text;
            switch(state)
            {
                case "Start tracking":
                    if (Location.IsGpsEnabled())
                    {
                        EnableTimer();
                        Tracking.Enable();
                        UpdateButtonText();
                        AlertService.ShowMessage("Tracking", "Tracking enabled", "Ok");
                    }
                    else
                        AlertService.ShowMessage("Error", "Please enable location", "Ok");
                    break;
                case "Stop tracking":
                    if(Tracking.GPSPositions.Count > 1)
                    {
                        Tracking.Disable();
                        AddNewTrail();
                        UpdateButtonText();
                    }
                    else
                    {
                        Tracking.Disable();
                        AlertService.ShowMessage("Tracking", "Tracking disabled", "Ok");
                        UpdateButtonText();
                    }
                    
                    break;
                default:
                    AlertService.ShowMessage("Error", "Switch loop error in TrackingPage.xaml.cs", "Ok");
                    break;
            }       
        }

        private async void AddNewTrail()
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        private void UpdateButtonText()
        {
            if (Tracking.IsEnabled)
                TrackingButton.Text = "Stop tracking";
            else
                TrackingButton.Text = "Start tracking";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateLayout();
            UpdateButtonText();
        }

        private void UpdateLayout()
        {
            ((StackLayout)FindByName("Content")).BackgroundColor = Color.FromHex(CurrentTheme.BackgroundColor1);
            ((Button)FindByName("TrackingButton")).BackgroundColor = Color.FromHex(CurrentTheme.ButtonColor);
            ((Button)FindByName("TrackingButton")).TextColor = Color.FromHex(CurrentTheme.TextColor);

            for(int i=1; i<=3; i++)
                ((Label)FindByName($"Label{i}")).TextColor = Color.FromHex(CurrentTheme.TextColor);
        }
    }
}