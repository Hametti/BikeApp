using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeApp.Services.Alert
{
    public interface IAlertService
    {
        Task ShowMessage(string message);
    }
}
