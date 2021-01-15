using App1.Models;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalcRoutePage : ContentPage
    {
        MyList ml;
        BrandsViewModel bvm;

        public CalcRoutePage(MyList _ml, BrandsViewModel _bvm)
        {
            InitializeComponent();

            ml = _ml;
            bvm = _bvm;

            BindingContext = ml;

            IngredientsList.ItemsSource = ml.items;

            NameOfListLabel.Text = ml.Topic;

            //Launcher.OpenAsync("geo:0,0?q=394+Pacific+Ave+San+Francisco+CA");
        }

        private void BrandsTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrandsView(bvm));

        }


        private async void ImageButton_Done_Clicked(object sender, EventArgs e)
        {
            //TODO Implement call to backEnd (in CalcRouteViewModel)
            var permissions = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

           // var location = await Geolocation.GetLastKnownLocationAsync();

            if (permissions != PermissionStatus.Granted)
            {
                permissions = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            //await Map.OpenAsync(location);

            await Map.OpenAsync(55.681998, 12.5763, new MapLaunchOptions
            {
                NavigationMode = NavigationMode.Default
            });
            //await Navigation.PopAsync();
        }
    }
}