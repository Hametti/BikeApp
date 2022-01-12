using Acr.UserDialogs;
using BikeApp.Data.Routes;
using BikeApp.Models;
using BikeApp.Services.Alert;
using BikeApp.Views;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BikeApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        public string itemId;
        private string text;
        private string description;
        private string totalTime;
        private string totalDistance;
        private string averageSpeed;

        public ItemDetailViewModel()
        {
            DeleteItem = new Command(OnDeleteItem);
        }

        private void OnDeleteItem()
        {
            var confi = new ConfirmConfig();
            confi.Title = "Route";
            confi.Message = "Are you sure you want to delete this route?";
            confi.OkText = "Yes";
            confi.CancelText = "No";
            confi.OnAction = b =>
            {
                if (b)
                {
                    Delete();
                    Shell.Current.GoToAsync("..");
                }
            };

            UserDialogs.Instance.Confirm(confi);
        }

        private void Delete()
        {
            var itemToDelete = Routes.AllRoutes.FirstOrDefault(r => r.Id == itemId);
            Routes.AllRoutes.Remove(itemToDelete);
            Routes.Save();
            AlertService.ShowMessage("Route", "Your route has been deleted", "Ok");
        }

        public Command DeleteItem { get; }
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string TotalTime
        {
            get => totalTime;
            set => SetProperty(ref totalTime, value);
        }

        public string TotalDistance
        {
            get => totalDistance;
            set => SetProperty(ref totalDistance, value);
        }

        public string AverageSpeed
        {
            get => averageSpeed;
            set => SetProperty(ref averageSpeed, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public void LoadItemId(string itemId)
        {
            try
            {
                var item = Routes.AllRoutes.FirstOrDefault(r => r.Id == itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                TotalTime = item.GetTotalTime();
                TotalDistance = item.GetDistanceInKm().ToString() + " km";
                AverageSpeed = item.GetAvgSpeedInKmph().ToString() + " km/h";
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
