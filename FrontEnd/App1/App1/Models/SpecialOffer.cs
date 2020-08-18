using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    class SpecialOffer
    {
    
            public string ImageUrl { get; set; }
            public string Topic { get; set; }
            public float Price { get; set; }

            public bool isOnSale { get; set; }


        


            public List<SpecialOffer> GetSpecialOffers()
            {
            List<SpecialOffer> specialOffers = new List<SpecialOffer>() { new SpecialOffer { ImageUrl = "https://1.bp.blogspot.com/-b6kPJ02tjRc/VHbs3lvJQ7I/AAAAAAAAACI/KgKx4U1KM9o/s1600/ristorante-pizza-prosciutto-pizza-und-snacks.png", Price = 25, Topic = "Pizza" }, new SpecialOffer { ImageUrl = "https://thumbs.dreamstime.com/b/brokoli-brocoli-green-natural-cabbage-flowers-30767358.jpg", Price = 70, Topic = "Brocoli", isOnSale = true }, new SpecialOffer { ImageUrl = "https://www.pricerunner.dk/product/1200x630/1871622771/Bombay-Sapphire-Gin-London-Dry-Gin-40-40-70-cl.jpg", Price = 70, Topic = "Gin" }, new SpecialOffer { isOnSale = true, ImageUrl = "https://www.bestiloghent.dk/images/media/Products/121-2157.jpg", Price = 5, Topic = "Kakao" } };

                return specialOffers;
            }
    }
    
}
