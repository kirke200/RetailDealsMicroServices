using Acr.UserDialogs;
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
    public partial class NewListPage : ContentPage
    {

        BrandsViewModel bvm;
        ListViewModel lvm;

        public NewListPage(BrandsViewModel _bvm, ListViewModel _lvm)
        {
            InitializeComponent();

            bvm = _bvm;
            lvm = _lvm;
        }

        private void BrandsTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrandsView(bvm));
        }

        private void ImageButton_Done_Clicked(object sender, EventArgs e)
        {
            MyList myNewList = new MyList();

            myNewList.Topic = EntryNameOfList.Text;
            myNewList.Price = 1337;
            myNewList.items =  new System.Collections.ObjectModel.ObservableCollection<string> { "test1", "test2", "test3"};
            myNewList.CalcItemCount();

            lvm.AddNewList(myNewList);



            Navigation.PopAsync();
        }
    }
}