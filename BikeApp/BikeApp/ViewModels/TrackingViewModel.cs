using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BikeApp.ViewModels
{
    public class TrackingViewModel : BaseViewModel
    {
        public TrackingViewModel()
        {
            //Name of current tab
            Title = "BikeApp";
            StartTracking = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand StartTracking { get; }
    }
}