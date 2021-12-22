using Acr.UserDialogs;
using BikeApp.Data.Themes;
using BikeApp.Sensors;
using BikeApp.Services.Alert;
using System;
using System.ComponentModel;
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

        void Button_Clicked(object sender, System.EventArgs e)
        {
            var state = TrackingButton.Text;
            switch(state)
            {
                case "Start tracking":
                    AlertService.ShowMessage("Tracking", "Tracking enabled", "Ok");
                    Tracking.Enable();
                    UpdateButtonText();
                    break;
                case "Stop tracking":
                    if(Tracking.GPSPositions.Count > 1)
                        AddNewTrail();
                    else
                    {
                        AlertService.ShowMessage("Tracking", "Tracking disabled", "Ok");
                        Tracking.Disable();
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