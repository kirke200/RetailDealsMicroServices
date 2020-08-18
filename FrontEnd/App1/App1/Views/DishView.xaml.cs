using App1.Models;
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
    public partial class DishView : ContentPage
    {
        Dish dish;
        public DishView(Dish d)
        {
            InitializeComponent();

            dish = d;

            BindingContext = dish;


            IngredientsList.ItemsSource = dish.ingredients;

            HeaderTitle.Text = dish.Topic;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();

        }
    }
}