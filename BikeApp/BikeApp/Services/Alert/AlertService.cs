using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeApp.Services.Alert
{
    public class AlertService : IAlertService
    {
        public async Task ShowMessage(string message)
        {
            await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("TestAlert", message, "Ok");
        }
    }
}
