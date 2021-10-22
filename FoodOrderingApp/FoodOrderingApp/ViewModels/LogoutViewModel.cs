using FoodOrderingApp.Services;
using FoodOrderingApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderingApp.ViewModels
{
    public class LogoutViewModel : BaseViewModel
    {
        private int _UserCartItemsCount;
        public int UserCartItemsCount
        {
            get
            {
                return _UserCartItemsCount;
            }

            set
            {
                _UserCartItemsCount = value;
                OnPropertyChanged();
            }
        }

        private bool _IsCartExists;
        public bool IsCartExists
        {
            get
            {
                return _IsCartExists;
            }

            set
            {
                _IsCartExists = value;
                OnPropertyChanged();
            }
        }

        public Command LogoutCommand { get; set; }
        public Command GoToCartCommand { get; set; }

        public LogoutViewModel()
        {
            UserCartItemsCount = new CartItemService().GetUserCartCount();

            IsCartExists = (UserCartItemsCount > 0) ? true : false;

            LogoutCommand = new Command(async () => await LogoutUserAsync());
            GoToCartCommand = new Command(async () => await GoToCartAsync());
        }

        private async Task GoToCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async Task LogoutUserAsync()
        {
            var cis = new CartItemService();
            cis.RemoveItemsFromCart();
            Preferences.Remove("Username");
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginView());
        }
    }
}
