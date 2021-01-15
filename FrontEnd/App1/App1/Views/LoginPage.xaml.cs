using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using App1.View;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            bool hasKey = Preferences.ContainsKey("user_key");
            if (!hasKey)
            {
                Preferences.Set("user_key", "1337");
            }

            Application.Current.MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#2BED79"),
            };

        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("user_key");
        }
    }
}