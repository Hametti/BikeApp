using BikeApp.Data;
using BikeApp.Data.Helpers;
using BikeApp.Services;
using BikeApp.Services.Alert;
using BikeApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeApp
{
    public partial class App : Application
    {

        public App()
        {
            Initializer.LoadTheme();
            DependencyService.Register<Services.Alert.IAlertService, Services.Alert.AlertService>();
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
