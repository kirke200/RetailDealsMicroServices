using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    class ListViewModel
    {
        public List<MyList> Lists { get; set;}

        string[] backgroundColors = {"#77F4A9", "#99F7BF", "#BBF9D4", "#DDFCEA" }; 

        public ListViewModel()
        {
            Lists = new MyList().GetLists();

            for (int i = 0; i < Lists.Count; i++)
            {
                MyList l = Lists[i];
                l.CalcItemCount();
                l.backgroundColor = backgroundColors[i %4];

            }
        }
    }
}
