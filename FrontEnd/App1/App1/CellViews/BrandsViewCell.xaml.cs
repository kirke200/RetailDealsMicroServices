using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.CellViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrandsViewCell : ViewCell
    {
        public BrandsViewCell()
        {
            InitializeComponent();

            //you can init your cells here
            InitCell(); //this is just for demo
        }

        public void InitCell()
        {
            //i can access my stack:
           // brand.BackgroundColor = Color.Red;
            //and even more
            //txtEvenMore.Text = "By name? Yes! :)";
        }

        //Now not for demo but in the real world:
        //We can set content according to your data from ItemsSource
        //This will act when you set your ListView ItemsSource to something valid
        protected override void OnBindingContextChanged()
        {
            SetupCell();
            base.OnBindingContextChanged();
        }

        public void SetupCell()
        {
            //use data from ItemsSource
            var item = BindingContext as Brand;
            if (item == null) return;

            BrandIamge.Source = item.ImageUrl;

        }

    }
}