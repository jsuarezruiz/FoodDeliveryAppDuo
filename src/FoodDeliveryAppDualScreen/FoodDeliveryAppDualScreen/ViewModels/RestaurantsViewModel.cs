using FoodDeliveryAppDualScreen.Models;
using FoodDeliveryAppDualScreen.Services;
using FoodDeliveryAppDualScreen.ViewModels.Base;
using System.Collections.ObjectModel;
using Xamarin.Forms.DualScreen;

namespace FoodDeliveryAppDualScreen.ViewModels
{
    public class RestaurantsViewModel : ViewModelBase
    {
        ObservableCollection<RestaurantCategory> _categories;
        ObservableCollection<Restaurant> _restaurants;
        Restaurant _currentRestaurant;

        public RestaurantsViewModel()
        {
            LoadData();
        }

        public bool IsSpanned { get; private set; }

        public TwoPaneViewMode Mode
        {
            set
            {
                IsSpanned = DualScreenInfo.Current.SpanMode != TwoPaneViewMode.SinglePane;
                OnPropertyChanged(nameof(IsSpanned));
            }
        }
        public ObservableCollection<RestaurantCategory> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Restaurant> Restaurants
        {
            get { return _restaurants; }
            set
            {
                _restaurants = value;
                OnPropertyChanged();
            }
        }

        public Restaurant CurrentRestaurant
        {
            get { return _currentRestaurant; }
            set
            {
                _currentRestaurant = value;
                OnPropertyChanged();
            }
        }

        void LoadData()
        {
            var categories = FakeRestaurantService.Instance.GetRestaurantCategories();
            Categories = new ObservableCollection<RestaurantCategory>(categories);

            var restaurants = FakeRestaurantService.Instance.GetRestaurants();
            Restaurants = new ObservableCollection<Restaurant>(restaurants);
        }
    }
}
