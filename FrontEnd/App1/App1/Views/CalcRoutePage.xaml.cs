using App1.Models;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        }

        private void BrandsTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrandsView(bvm));

        }


        private void ImageButton_Done_Clicked(object sender, EventArgs e)
        {
            //TODO Implement call to backEnd (in CalcRouteViewModel)
            Navigation.PopAsync();
        }
    }
}