using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodOrderingApp.Helpers
{
    public class AddFoodItemData
    {
        public List<FoodItem> FoodItems { get; set; }

        FirebaseClient client;

        public AddFoodItemData()
        {
            client = new FirebaseClient("https://foodorderingapp-cd3d8-default-rtdb.firebaseio.com/");

            FoodItems = new List<FoodItem>()
            {
                new FoodItem()
                {
                    ProductID = 1,
                    CategoryID = 1,
                    ImageUrl = "Pizza1.jpg",
                    Name = "Pizza 1",
                    Description = "Pizza 1 - Description",
                    Rating = "4.8",
                    RatingDetail = "(121 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 10
                },

                new FoodItem()
                {
                    ProductID = 2,
                    CategoryID = 1,
                    ImageUrl = "Pizza2.jpg",
                    Name = "Pizza 2",
                    Description = "Pizza 2 - Description",
                    Rating = "4.4",
                    RatingDetail = "(11 ratings)",
                    HomeSelected = "EmptyHeart",
                    Price = 16
                },

                new FoodItem()
                {
                    ProductID = 3,
                    CategoryID = 2,
                    ImageUrl = "Burger1.jpg",
                    Name = "Burger 1",
                    Description = "Burger 1 - Description",
                    Rating = "4.5",
                    RatingDetail = "(101 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 20
                },

                new FoodItem()
                {
                    ProductID = 4,
                    CategoryID = 2,
                    ImageUrl = "Burger2.jpg",
                    Name = "Burger 2",
                    Description = "Burger 2 - Description",
                    Rating = "4.5",
                    RatingDetail = "(10 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 25
                },

                new FoodItem()
                {
                    ProductID = 5,
                    CategoryID = 3,
                    ImageUrl = "Cake1.jpg",
                    Name = "Cake 1",
                    Description = "Cake 1 - Description",
                    Rating = "4.5",
                    RatingDetail = "(10 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 25
                },
                
                new FoodItem()
                {
                    ProductID = 6,
                    CategoryID = 3,
                    ImageUrl = "Cake2.jpg",
                    Name = "Cake 2",
                    Description = "Cake 2 - Description",
                    Rating = "4.5",
                    RatingDetail = "(10 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 25
                },

                new FoodItem()
                {
                    ProductID = 7,
                    CategoryID = 4,
                    ImageUrl = "Salad1.jpg",
                    Name = "Salad 1",
                    Description = "Salad 1 - Description",
                    Rating = "4.5",
                    RatingDetail = "(10 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 25
                },

                new FoodItem()
                {
                    ProductID = 8,
                    CategoryID = 4,
                    ImageUrl = "Salad2.jpg",
                    Name = "Salad 2",
                    Description = "Salad 2 - Description",
                    Rating = "4.5",
                    RatingDetail = "(10 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 25
                }
            };
        }

        public async Task AddFoodItemsAsync()
        {
            try
            {
                foreach (var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                        ProductID = item.ProductID,
                        CategoryID = item.CategoryID,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Description = item.Description,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail,
                        HomeSelected = item.HomeSelected,
                        Price = item.Price
                    });
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
