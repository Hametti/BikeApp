using Acr.UserDialogs;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            UserDialogs.Instance.Alert(new AlertConfig
            {
                Title = "Tracking",
                Message = "Tracking will be available later",
                OkText = "Ok"
            });
        }
    }
}