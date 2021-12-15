using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeApp.Services.Alert
{
    public class AlertService
    {
        public static void ShowMessage(string title, string message, string cancel)
        {
            var config = new AlertConfig
            {
                Title = title,
                Message = message,
                OkText = cancel
            };

            UserDialogs.Instance.AlertAsync(config);
        }
    }
}
