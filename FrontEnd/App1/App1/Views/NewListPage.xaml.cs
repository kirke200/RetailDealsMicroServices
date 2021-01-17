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
        ListViewModel lvm;

        public NewListPage( ListViewModel _lvm)
        {
            InitializeComponent();

            lvm = _lvm;
        }

        private void ImageButton_Done_Clicked(object sender, EventArgs e)
        {
            //TODO Implement a real list instead of dummy list

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