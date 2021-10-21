using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class Cart
    {
        public string UserName { get; set; }
        public int CartID { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
