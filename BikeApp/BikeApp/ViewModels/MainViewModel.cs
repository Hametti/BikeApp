using BikeApp.Data;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BikeApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Title = "Main page";

            //This code segment is part of example how to interact with ViewModel from xaml file(you can find command and method call in MainPage.xaml)
            //ChangeSomething = new Command<object>(ChangeColor);
        }

        public void DoSomething()
        {
            
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