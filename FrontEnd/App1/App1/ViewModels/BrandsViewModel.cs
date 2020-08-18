using App1.Models;
using App1.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class BrandsViewModel
    {
        public ObservableCollection<Brand> Brands { get; set; }

        public ObservableCollection<Brand> pickedBrands = new ObservableCollection<Brand>();

  

        public BrandsViewModel()
        {
            Brands = new Brand().GetBrands();
        }




    }
}
