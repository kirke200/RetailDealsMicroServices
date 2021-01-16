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
        MyAnimations animations;
        UInt32 APISearchAnimationSpeed = 500;

        public CalcRoutePage(MyList _ml, BrandsViewModel _bvm)
        {
            InitializeComponent();

            animations = new MyAnimations();
            ml = _ml;
            bvm = _bvm;

            BindingContext = ml;

            Products.ItemsSource = ml.items;

            HeaderTitle.Text = ml.Topic;

            animations.TranslateStackLayout(APISearch, -Application.Current.MainPage.Width, 0, 0, Easing.Linear);

            //animations.TranslateStackLayout(SearchItems, 0, Application.Current.MainPage.Height, Convert.ToUInt32( Application.Current.MainPage.Height), Easing.CubicOut);

            //Launcher.OpenAsync("geo:0,0?q=394+Pacific+Ave+San+Francisco+CA");
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

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;

            if (searchBar.Text == "")
                searchResults.IsVisible = false;

            else
            {
                searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);
                searchResults.IsVisible = true;
            }



        }

        private void searchResults_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            APISearchGrid.IsVisible = true;
            animations.TranslateStackLayout(APISearch, 0, 0, APISearchAnimationSpeed, Easing.CubicInOut);
        }

        private void APISearchButton_Clicked(object sender, EventArgs e)
        {
            animations.TranslateStackLayout(APISearch, -Application.Current.MainPage.Width, 0, APISearchAnimationSpeed, Easing.CubicInOut);
            DelayActionAsync((int)APISearchAnimationSpeed, SetAPISearchGridInvisible);


        }

        void SetAPISearchGridInvisible()
        {
            APISearchGrid.IsVisible = false;
        }

        public async Task DelayActionAsync(int delay, Action action)
        {
            await Task.Delay(delay);

            action();
        }
    }
}