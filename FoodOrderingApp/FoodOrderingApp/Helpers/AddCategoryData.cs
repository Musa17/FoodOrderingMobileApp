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
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }

        FirebaseClient client;
        public AddCategoryData()
        {
            client = new FirebaseClient("https://foodorderingapp-cd3d8-default-rtdb.firebaseio.com/");

            Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryID = 1,
                    CategoryName = "Pizza",
                    CategoryPoster = "PizzasPoster.jpg",
                    ImageUrl = "Pizzas.png"
                },

                new Category()
                {
                    CategoryID = 2,
                    CategoryName = "Burgers",
                    CategoryPoster = "BurgersPoster.jpg",
                    ImageUrl = "Burgers.png"
                },

                new Category()
                {
                    CategoryID = 3,
                    CategoryName = "Cakes",
                    CategoryPoster = "CakesPoster.jpg",
                    ImageUrl = "Cakes.png"
                }
            };
        }

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl
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
