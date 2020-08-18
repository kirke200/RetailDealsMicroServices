using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.Models
{
    public class MyList
    {

        public string Topic { get; set; }
        public float Price { get; set; }
        public int itemCount {get; set;}

        public string backgroundColor { get; set; } = "#FFFFFFF";

        public ObservableCollection<string> items = new ObservableCollection<string>();



        public List<MyList> GetLists(){
            List<MyList> Lists = new List<MyList> { new MyList { items = { "item 1", "item 2", "item 3" }, Topic = "Indkøbsliste", Price = 120.95F, itemCount = 0 }, new MyList { items = { "item 1", "item 2", "item 3" }, Topic = "Indkøbsliste", Price = 120.95F, itemCount = 0 }, new MyList { items = { "item 1", "item 2", "item 3" }, Topic = "Indkøbsliste", Price = 120.95F, itemCount = 0 }, new MyList { items = { "item 1", "item 2", "item 3" }, Topic = "Indkøbsliste", Price = 120.95F, itemCount = 0 }, new MyList { items = { "item 1", "item 2", "item 3" }, Topic = "Indkøbsliste", Price = 120.95F, itemCount = 0 }, new MyList { items = { "item 1", "item 2", "item 3" }, Topic = "Indkøbsliste", Price = 120.95F, itemCount = 0 }, new MyList { items = {"item 1", "item 2", "item 3"}, Topic = "Indkøbsliste", Price = 120.95F , itemCount= 0}, new MyList { items = { "item 1", "item 2" }, itemCount= 10, Topic = "Fest", Price = 1200 } };
            return Lists; }
    
        
        
        public void CalcItemCount()
        {
            itemCount = items.Count;
        }
    }


}
