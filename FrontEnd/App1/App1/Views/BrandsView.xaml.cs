using App1.CellViews;
using App1.Models;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrandsView : ContentPage
    {
        BrandsViewModel bvm = new BrandsViewModel();

        public BrandsView()
        {
            InitializeComponent();

            BindingContext = bvm;
        }

      

  

        private void brandsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Brand item = e.SelectedItem as Brand;

            item.ItemIsChecked();

            //brandsListView.SelectedItem = null;

        }

        private void DoneButton_Pressed(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void CheckBox_CheckChanged(object sender, EventArgs e)
        {
           
            ObservableCollection<Brand> pi = new ObservableCollection<Brand>();

            for (int i = 0; i < bvm.Brands.Count; i++)
            {
                Brand item = bvm.Brands[i];

                if (item.isCheck)
                {
                    pi.Add(item);
                }
            }

            bvm.pickedBrands = pi;



           
        }

        private void brandsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
        }

        private void DoneButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}