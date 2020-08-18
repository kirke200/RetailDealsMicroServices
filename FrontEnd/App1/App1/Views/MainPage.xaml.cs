//using App1.Views;
using App1.Models;
using App1.ViewModels;
using App1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.View
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ListViewModelMain lvmm = new ListViewModelMain();
        DishViewModel dvm = new DishViewModel();
        SpecialOfferViewModel sovm = new SpecialOfferViewModel();
        ListViewModel lvm = new ListViewModel();

        ICommand GoToSpecialItemListCommand;
        ICommand GoToNewListPageCommand;

        ListView currentListView = null;

        Label currentPageIndicator;

        public MainPage()
        {
            InitializeComponent();
         
            currentPageIndicator = labelHouse;

            GoToSpecialItemListCommand = new Command(() => Navigation.PushAsync(new SpecialOffersPage()));
            GoToNewListPageCommand = new Command(() => Navigation.PushAsync(new NewListPage()));

            BindingContext = dvm;

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#2BED79");

            AnimateImageButton(AddNewItemButton, 0, 120, 0);



        }

        private void ImageButton_Clicked_House(object sender, EventArgs e)
        {
            HeaderTitle.Text = "Home";

            ChangeListView(null);
            NavBarMinimize();

            NewPageSelected(labelHouse);


            AnimateImageButton(AddNewItemButton, 0, 120, 800);

        }

        private void ImageButton_Clicked_Lists(object sender, EventArgs e)
        {
            HeaderTitle.Text = "My Lists";
            NavBarMinimize();

            ChangeListView(listViewMainLists);
            AnimateImageButton(AddNewItemButton, 0, 0, 800);
            BindingContext = lvm;

            NewPageSelected(labelList);

            AddNewItemButton.Command = GoToNewListPageCommand;



        }

        private void ImageButton_Clicked_Dishes(object sender, EventArgs e)
        {
            HeaderTitle.Text = "Dishes";

         
            NavBarMinimize();
            ChangeListView(listViewMainDishes);
            AnimateImageButton(AddNewItemButton,0,120,800);

            NewPageSelected(labelBestik);
            BindingContext = dvm;


        }

        private void ImageButton_Clicked_SpeacialItems(object sender, EventArgs e)
        {
            HeaderTitle.Text = "Offer Agent";

            AddNewItemButton.Command = GoToSpecialItemListCommand;
            AnimateImageButton(AddNewItemButton, 0,0, 800);
            BindingContext = sovm;

            NavBarMinimize();

            NewPageSelected(labelSearch);

            ChangeListView(listViewMainSpecialOffers);

           



        }
        private void navButton_Clicked(object sender, EventArgs e)
        {
            NavBarExpand();
            ScaleImageButton(ImageButtonHeader, 0, 400, Easing.CubicIn);
        }

        private void Something1_Clicked(object sender, EventArgs e)
        {


        }

        private void Something2_Clicked(object sender, EventArgs e)
        {


        }

        private void LogOut_Clicked(object sender, EventArgs e)
        {


        }


        void ChangeListView(ListView lw)
        {
            if (currentListView != null)
                currentListView.IsVisible = false;
            if (lw != null)
            {
                lw.IsVisible = true;
                currentListView = lw;
            }
        }

        private void listViewMainDishes_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            Dish dish = e.Item as Dish;          

            Navigation.PushAsync(new DishView(dish));          

            if (sender is ListView lv) lv.SelectedItem = null;

        }

        private void listViewMainSpecialOffers_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SpecialOffer so = e.Item as SpecialOffer;

          

            if (sender is ListView lv) lv.SelectedItem = null;
        }


        void NewPageSelected(Label newLabel)
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(450), () =>
            {
            currentPageIndicator.BackgroundColor = Color.FromHex("#FFFFFF");
            currentPageIndicator = newLabel;
                currentPageIndicator.Scale = 0;
            currentPageIndicator.BackgroundColor = Color.FromHex("#2BED79");
                return false;
            });
        }
 /*-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                        ANIMATION STUFF
  ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        void ScaleButtonsDownAnimation()
        {
            house.ScaleTo(0, 400, easing: Easing.CubicOut);
            list.ScaleTo(0, 400, easing: Easing.CubicOut);
            bestik.ScaleTo(0, 400, easing: Easing.CubicOut);
            search.ScaleTo(0, 400, easing: Easing.CubicOut);         
        }

        void ScaleLabelAnimation(Label label, float scale, int speed, Easing easing)
        {
            label.ScaleTo(scale, (uint)speed, easing);
        }
        void ScaleButtonsUpAnimation()
        {

            ScaleImageButton(house, 1, 400, Easing.CubicInOut);
            ScaleImageButton(list, 1, 650, Easing.CubicInOut);
            ScaleImageButton(bestik, 1, 900, Easing.CubicInOut);
            ScaleImageButton(search, 1, 1050, Easing.CubicInOut);          
        }

        void ScaleImageButton(ImageButton iButton, float scale, int speed, Easing easingFucntion)
        {
            iButton.ScaleTo(scale, (uint)speed, easingFucntion);
        }


        void NavBarMinimize()
        {
            ScaleButtonsDownAnimation();
            ScaleLabelAnimation(currentPageIndicator, 0, 400, Easing.CubicIn);

            Device.StartTimer(TimeSpan.FromMilliseconds(400), () =>
            {
                AnimateNavBarOut();
                ScaleImageButton(ImageButtonHeader, 1, 800, Easing.BounceOut);
                return false;
            });
        }


        void NavBarExpand()
        {
            ScaleLabelAnimation(currentPageIndicator, 1, 400, Easing.CubicOut);
            AnimateNavBarIn();            
        }

        


        void AnimateButton(Button b, int x, int y, int speed)
        {
            b.TranslateTo(x, y, (uint)speed, Easing.CubicOut);
        }


        void AnimateImageButton(ImageButton b, int x, int y, int speed)
        {
            b.TranslateTo(x, y, (uint)speed, Easing.CubicOut);
        }

        double navWidth = 0.2;
        void AnimateNavBarOut()
        {          
            MainGrid.ColumnDefinitions[1].Width = new GridLength(navWidth, GridUnitType.Star);

            Device.StartTimer(TimeSpan.FromMilliseconds(5), () =>
            {
                navWidth -= 0.03;
                if (navWidth <= 0)
                    navWidth = 0;
                MainGrid.ColumnDefinitions[1].Width = new GridLength(navWidth, GridUnitType.Star);
                if (navWidth == 0)
                {
                    return false;
                }
                return true;
                
            });
          

        }

        void AnimateNavBarIn()
        {
            MainGrid.ColumnDefinitions[1].Width = new GridLength(navWidth, GridUnitType.Star);

            Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
            {
                navWidth += 0.03;
                if (navWidth >= 0.2)
                    navWidth = 0.2;

                MainGrid.ColumnDefinitions[1].Width = new GridLength(navWidth, GridUnitType.Star);
                if (navWidth == 0.2)
                {
                    ScaleButtonsUpAnimation();
                    return false;

                }

                return true;

            });


        }
    }
}
