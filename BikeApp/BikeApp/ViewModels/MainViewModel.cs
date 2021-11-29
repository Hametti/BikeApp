using BikeApp.Data;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BikeApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public int z { get; set; } = 0;
        private readonly Services.Alert.IAlertService _alertService;

        public MainViewModel()
        {
            _alertService = DependencyService.Get<Services.Alert.IAlertService>();
            //Name of current tab
            Title = "Main page nr " + z;
            z++;
            MyMessage = "This is testmsg";
            BackgroundColor1 = "#ebdd05";
            ChangeSomething = new Command<object>(ChangeColor);
            
        }

        public void DoSomething()
        {
            _alertService.ShowMessage("DI works");
        }


        public void ChangeColor(object obj)
        {
            if (BackgroundColor1 != "#010101")
            {
                BackgroundColor1 = "#010101";
                MyMessage = "Testmsg2";
            }
            else
                BackgroundColor1 = "#ebdd05";

            if (obj is StackLayout sl)
            {
                sl.BackgroundColor = Color.FromHex(BackgroundColor1);
            }
        }

        public Command ChangeSomething { get; set; }
        public string MyMessage { get; set; }
        public string BackgroundColor1 { get; set; }


    }
}