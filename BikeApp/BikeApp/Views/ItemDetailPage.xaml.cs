using BikeApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BikeApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}