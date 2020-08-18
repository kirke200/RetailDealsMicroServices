using App1.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Views
{
   
    class SplashPage : ContentPage
    {
        Image splashImage;

        bool finishedLoading = true;


        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();

            splashImage = new Image
            {
                Source = "Foodmaps.png",
           
               
            };
            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);          

            this.BackgroundColor = Color.FromHex("#2BED79");
            this.Content = sub;
         }




        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // while (!finishedLoading)
            //{               
                await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
                await splashImage.ScaleTo(1.1, 1500, Easing.Linear);

            //}
            Application.Current.MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#2BED79"),
            };
        }
    }
}


