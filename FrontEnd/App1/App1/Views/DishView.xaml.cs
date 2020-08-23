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
    public partial class DishView : ContentPage
    {
        Dish dish;
        ListViewModel lvm;
        public DishView(Dish d, ListViewModel _lvm)
        {
            InitializeComponent();

            dish = d;

            BindingContext = dish;

            lvm = _lvm;

            IngredientsList.ItemsSource = dish.ingredients;

            HeaderTitle.Text = dish.Topic;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            MyList myList = new MyList();

            myList.Topic = dish.Topic;

            myList.Price = dish.Price;

            myList.items = dish.ingredients;

            myList.CalcItemCount();

            lvm.AddNewList(myList);

            Navigation.PopAsync();

        }
    }
}