using App1.ConnectionControllers;
using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModels
{
    public class ListViewModel
    {
        public ObservableCollection<MyList> Lists { get; private set;}

        ListAPI listAPI = new ListAPI();

        int colorIndex = 0;

        string[] backgroundColors = { "#cbd5e0", "#e2e8f0" }; 

        public ListViewModel()
        {
            Lists = new ObservableCollection<MyList>();

            /*Lists = new MyList().GetLists();


            for (i=0; i < Lists.Count; i++)
            {
                MyList l = Lists[i];
                l.CalcItemCount();
                l.backgroundColor = backgroundColors[i % backgroundColors.Length];

            }*/
        }

        public async Task LoadMyLists(int userId)
        {
            var lists = await listAPI.GetLists(userId);
            foreach(MyList list in lists)
            {
                AddNewList(list);
            }

            
        }

        public void AddNewList(MyList ml)
        {
            ml.backgroundColor = backgroundColors[colorIndex % backgroundColors.Length];
            Lists.Add(ml);

            colorIndex++;

        }
    }
}
