using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderingApp.Services
{
    public class OrderService
    {
        FirebaseClient client;

        public OrderService()
        {
            client = new FirebaseClient("https://foodorderingapp-cd3d8-default-rtdb.firebaseio.com/");
        }

        public async Task<string> PlaceOrderAsync()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var data = cn.Table<CartItem>().ToList();

            var orderID = Guid.NewGuid().ToString();
            var uname = Preferences.Get("Username", "Guest");

            decimal totalCost = 0;

            foreach (var item in data)
            {
                OrderDetails od = new OrderDetails()
                {
                    OrderID = orderID,
                    OrderDetailID = Guid.NewGuid().ToString(),
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity
                };

                totalCost += item.Price * item.Quantity;
                await client.Child("OrderDetails").PostAsync(od);
            }

            await client.Child("Orders").PostAsync(
                new Order()
                {
                    OrderID = orderID,
                    Username = uname,
                    TotalCost = totalCost
                });

            return orderID;
        }
    }
}
