using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.ViewModels
{
    class HomePageViewModel
    {
        public ObservableCollection<HomePageItem> HomePageItems = new ObservableCollection<HomePageItem>();

        public HomePageViewModel()
        {
            HomePageItems = new ObservableCollection<HomePageItem>() { new HomePageItem { ImgUrl = "https://www.tingstad.com/fixed/images/Main/1550834356/36178.png", Description = "Red Bull 250 ml", Price = 9.95F }, new HomePageItem { ImgUrl = "https://tantestrejf.dk/wp-content/uploads/2018/08/rugbroed-med-gaer-opskrift-tantestrejf-5.jpg", Description = "Rye Bread", Price = 29.95F }, new HomePageItem { ImgUrl = "https://www.benjerry.dk/files/live/sites/systemsite/files/flavors/products/eu/pints/open-closed-pints/cookie-dough-landing.png", Description = "Ben & Jerry Cookie Dough", Price = 14.95F }, new HomePageItem { ImgUrl = "https://trainright.com/wp-content/uploads/2019/10/red-meat-steak-beef.jpg", Description = "Meat ", Price = 79.95F } };
        }

    }
}
