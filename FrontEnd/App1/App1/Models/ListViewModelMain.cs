using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    class ListViewModelMain
    {
        public string[] offers { get; set; }

        public string[] myLists { get; set; }

        public string[] dishes { get; set; }

        public string[] myOffers { get; set; }

    public ListViewModelMain()
    {
            offers   = new string[] { "data1", "data2", "data3" , "data4"};
            myLists  = new string[] { "List1", "List2", "List3", "List4" };
            dishes   = new string[] { "Pizza", "Pasta med tun uden tun", "Lasange", "spaghetti carbonára", "Pizza", "Pasta med tun uden tun", "Lasange", "spaghetti carbonára" , "Pizza", "Pasta med tun uden tun", "Lasange", "spaghetti carbonára" , "Pizza", "Pasta med tun uden tun", "Lasange", "spaghetti carbonára" , "Pizza", "Pasta med tun uden tun", "Lasange", "spaghetti carbonára" , "Pizza", "Pasta med tun uden tun", "Lasange", "spaghetti carbonára" };
            myOffers = new string[] { "Gin", "Sodavand", "Salat", "Kakao" };
        }


    }
}
