using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.ViewModels
{
    public class ListViewModel
    {
        public ObservableCollection<MyList> Lists { get; private set;}

        int i;

        string[] backgroundColors = { "#cbd5e0", "#e2e8f0" }; 

        public ListViewModel()
        {
            Lists = new MyList().GetLists();


            for (i=0; i < Lists.Count; i++)
            {
                MyList l = Lists[i];
                l.CalcItemCount();
                l.backgroundColor = backgroundColors[i % backgroundColors.Length];

            }
        }




        public void AddNewList(MyList ml)
        {
            ml.backgroundColor = backgroundColors[i % backgroundColors.Length];
            Lists.Add(ml);

            i++;

        }
    }
}
