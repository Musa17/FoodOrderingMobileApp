﻿using Firebase.Database;
using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Services
{
    public class FoodItemService
    {
        FirebaseClient client;

        public FoodItemService()
        {
            client = new FirebaseClient("https://foodorderingapp-cd3d8-default-rtdb.firebaseio.com/");
        }

        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            var products = (await client.Child("FoodItems").OnceAsync<FoodItem>()).Select(f => new FoodItem
            {
                ProductID = f.Object.ProductID,
                CategoryID = f.Object.CategoryID,
                ImageUrl = f.Object.ImageUrl,
                Name = f.Object.Name,
                Description = f.Object.Description,
                Rating = f.Object.Rating,
                RatingDetail = f.Object.RatingDetail,
                HomeSelected = f.Object.HomeSelected,
                Price = f.Object.Price
            }).ToList();

            return products;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID)
        {
            var foodItemsByCategory = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(p => p.CategoryID == categoryID).ToList();

            foreach (var item in items)
            {
                foodItemsByCategory.Add(item);
            }

            return foodItemsByCategory;
        }

        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var latestFoodItems = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).OrderByDescending(f => f.ProductID).Take(3);

            foreach (var item in items)
            {
                latestFoodItems.Add(item);
            }

            return latestFoodItems;
        }
    }
}
