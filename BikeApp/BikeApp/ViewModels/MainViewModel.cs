using BikeApp.Data;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BikeApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly Services.Alert.IAlertService _alertService;

        public MainViewModel()
        {
            _alertService = DependencyService.Get<Services.Alert.IAlertService>();
            Title = "Main page";

            //This code segment is part of example how to interact with ViewModel from xaml file(you can find command and method call in MainPage.xaml)
            //ChangeSomething = new Command<object>(ChangeColor);
        }

        public void DoSomething()
        {
            _alertService.ShowMessage("DI works");
        }

        //This code segment is part of example how to interact with ViewModel from xaml file(you can find command and method call in MainPage.xaml)
        //public void ChangeColor(object obj)
        //{
        //    if (BackgroundColor1 != "#010101")
        //    {
        //        BackgroundColor1 = "#010101";
        //        MyMessage = "Testmsg2";
        //    }
        //    else
        //        BackgroundColor1 = "#ebdd05";

        //    if (obj is StackLayout sl)
        //    {
        //        sl.BackgroundColor = Color.FromHex(BackgroundColor1);
        //    }
        //}
        //public Command ChangeSomething { get; set; }
    }
}