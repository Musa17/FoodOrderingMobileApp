using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class Order
    {
        public string OrderID { get; set; }
        public string Username { get; set; }
        public decimal TotalCost { get; set; }
    }
}
