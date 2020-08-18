using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.ViewModels
{
    class SpecialOfferViewModel
    {

        public ObservableCollection<SpecialOffer> SpecialOffers { get; set; }

        public SpecialOfferViewModel()
        {
            SpecialOffers = new ObservableCollection<SpecialOffer>();
            var items = new SpecialOffer().GetSpecialOffers();

            foreach (var item in items)
            {
                if (item.isOnSale)
                    SpecialOffers.Insert(0, item);

                else
                    SpecialOffers.Add(item);
            }

        }



    }
}
