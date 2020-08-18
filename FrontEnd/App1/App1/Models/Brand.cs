using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.Models
{
    class Brand
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public bool isCheck { get; set; }


        public Brand()
        {
        }


        public void ItemIsChecked()
        {
            isCheck = !isCheck;
        }
       
        
        public ObservableCollection<Brand> GetBrands()
        {
            ObservableCollection<Brand> brands = new ObservableCollection<Brand>() { new Brand { ImageUrl = "https://broenshopping.dk/media/1144/logo_kvickly.jpg", isCheck = false }, new Brand { ImageUrl = "https://www.bilka.dk/img/logo-og.png", isCheck = false }, new Brand { ImageUrl = "https://seeklogo.com/images/L/lidl-logo-AFAFEAFE19-seeklogo.com.png", isCheck = false }, new Brand {ImageUrl = "https://meremobil.dk/wp-content/uploads/2016/09/fakta.png" }, new Brand { ImageUrl = "https://www.co2pro.dk/wp-content/uploads/2019/06/MENY-logo.png" } ,new Brand { ImageUrl = "https://yuvul2juk352vmfty1xejgo6-wpengine.netdna-ssl.com/wp-content/uploads/2019/07/foetex-i-city2-300x300.png", Price = 70, Name = "pizza" }, new Brand { ImageUrl = "https://i.dlpng.com/static/png/333013_preview.png", Price = 80, Name = "Pasta" } };

            return brands;
        }
    }
}
