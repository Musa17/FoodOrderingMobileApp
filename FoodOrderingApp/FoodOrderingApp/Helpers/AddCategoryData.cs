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
                    categoryID = 1,
                    categoryName = "Pizza",
                    categoryPoster = "Pizza",
                    imageUrl = "Pizza.jpg"
                },

                new Category()
                {
                    categoryID = 2,
                    categoryName = "Burger",
                    categoryPoster = "Burger",
                    imageUrl = "Burger.jpg"
                },

                new Category()
                {
                    categoryID = 3,
                    categoryName = "Cakes",
                    categoryPoster = "Cakes",
                    imageUrl = "Cakes.jpg"
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
                        categoryID = category.categoryID,
                        categoryName = category.categoryName,
                        categoryPoster = category.categoryPoster,
                        imageUrl = category.imageUrl
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
