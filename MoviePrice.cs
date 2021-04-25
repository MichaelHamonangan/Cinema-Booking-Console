using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Booking_System
{
    class MoviePrice
    {
        private int price;
        public int Price { get => price; set => price = value; }
        public int total;

        public MoviePrice(int price)
        {
            this.Price = price;
        }

        public void totalPrices(int n)
        {
            total = price * n;
        }
    }
}
