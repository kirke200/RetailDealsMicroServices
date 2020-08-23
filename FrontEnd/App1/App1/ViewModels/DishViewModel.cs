using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    class DishViewModel
    {
        public List<Dish> Dishes { get; set; }

        public DishViewModel()
        {
            Dishes = new Dish().GetDishes();
        }


    }
}
