using Acr.UserDialogs;
using BikeApp.Data.Themes;
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
            UserDialogs.Instance.Alert(new AlertConfig
            {
                Title = "Tracking",
                Message = "Tracking will be available later",
                OkText = "Ok"
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetLayout();
        }

        private void SetLayout()
        {
            ((StackLayout)FindByName("Content")).BackgroundColor = Color.FromHex(CurrentTheme.BackgroundColor1);
            ((Button)FindByName("TrackingButton")).BackgroundColor = Color.FromHex(CurrentTheme.ButtonColor);
            ((Button)FindByName("TrackingButton")).TextColor = Color.FromHex(CurrentTheme.TextColor);

            for(int i=1; i<=3; i++)
                ((Label)FindByName($"Label{i}")).TextColor = Color.FromHex(CurrentTheme.TextColor);
        }
    }
}