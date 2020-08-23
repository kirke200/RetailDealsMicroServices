using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.Models
{
    public class Dish
    {
        public string ImageUrl { get; set; }
        public string Topic { get; set; }
        public float Price { get; set; }

        public ObservableCollection<string> ingredients = new ObservableCollection<string>();

        public int itemCount = 0;



        public List<Dish> GetDishes()
        {


            List<Dish> dishes = new List<Dish>() { new Dish { ImageUrl = "https://www.cookingclassy.com/wp-content/uploads/2019/11/best-salad-7.jpg", Topic = "Salad", Price = 20 }, new Dish {ImageUrl = "https://mambeno.dk/wp-content/uploads/2017/11/Lasagne-med-oestershatte.jpg", Price = 1337, Topic = "Lasange" }, new Dish {ImageUrl = "https://www.lifeloveandsugar.com/wp-content/uploads/2018/04/Raspberry-Chocolate-Layer-Cake3.jpg", Topic = "Cake", Price = 100 }, new Dish { ImageUrl = "https://migogkbh.dk/wp-content/uploads/2020/01/20-800x480.jpg", Price = 70, Topic = "pizza", ingredients = { "Bread", "Cheese" } }, new Dish { ImageUrl = "https://firenze-haderslev.dk/wp-content/uploads/2017/11/pasta.jpg", Price = 80, Topic = "Pasta", ingredients = { "Pasta", "Bacon" } } };

            return dishes;
        }


        public void CalcItemCount()
        {
            itemCount = ingredients.Count;
        }
    }
}
