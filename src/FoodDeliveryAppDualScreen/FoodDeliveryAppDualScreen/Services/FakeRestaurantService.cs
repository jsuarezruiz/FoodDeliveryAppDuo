using FoodDeliveryAppDualScreen.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodDeliveryAppDualScreen.Services
{
    public class FakeRestaurantService
    {
        static FakeRestaurantService _instance;

        public static FakeRestaurantService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FakeRestaurantService();
                return _instance;
            }
        }

        public IEnumerable<Food> Foods1
        {
            get
            {
                return new List<Food>
                {
                    new Food { Name = "Burrata", Ingredients = "date conserva, roasted pistachio, crispy pancetta, arugula, grilled bread", Image = "burrata.jpg", Price = 12, Category = FoodCategory.Pizza  },
                    new Food { Name = "Prosciutto Bruschetta", Ingredients = "crescenza cheese, grilled asparagus, truffle, grana padano", Image = "prosciutto.jpg", Price = 11, Category = FoodCategory.Pizza  },
                    new Food { Name = "Grilled Cauliflower", Ingredients = "fried egg, baby asparagus, toasted breadcrumb, pancetta cream, lemon",  Image = "cauliflower.jpg", Price = 11, Category = FoodCategory.Pizza  },
                    new Food { Name = "White Truffle Garlic Bread", Ingredients = "house made ricotta, mozzarella, grana padano, herbs", Image = "trufflegarlic.jpg", Price = 12, Category = FoodCategory.Pizza  },
                    new Food { Name = "Funghi Pizza", Ingredients = "roasted mushroom, cipollini onion, smoked mozzarella", Image = "funghipizza.jpg", Price = 15, Category = FoodCategory.Pizza  },
                    new Food { Name = "Prosciutto  Pizza", Ingredients = "mission fig, goat cheese, arugula", Image = "prosciuttopizza.jpg", Price = 16, Category = FoodCategory.Pizza  },
                    new Food { Name = "Margherita  Pizza", Ingredients = "mozzarella, fresh basil, olive oil, red sauce", Image = "margheritapizza.jpg", Price = 16, Category = FoodCategory.Pizza  }
                };
            }
        }

        public IEnumerable<Food> Foods2
        {
            get
            {
                return new List<Food>
                {
                    new Food { Name = "Angus Beef Burger", Ingredients = "1/3 Lb. Patty, House Sauce, Tomato, Pickles, Shaved Onions, American Cheese", Image = "angusbeef.jpg", Price = 16, Category = FoodCategory.Burguer  },
                    new Food { Name = "Grilled Chicken Burger", Ingredients = "1/4 Lb. Chicken, Chipotle Aioli, Mixed Greens, Roma Tomato, Avocado, Swiss Cheese ",  Image = "grilledchicken.jpg", Price = 12, Category = FoodCategory.Burguer  },
                    new Food { Name = "Hawaiian Salmon Burger", Ingredients = "1/4 Lb. Patty, Red Cabbage Slaw, Pineapple, Ginger Vinaigrette, Barbecue Glaze", Image = "hawaiian.jpg", Price = 15, Category = FoodCategory.Burguer  },
                    new Food { Name = "Dry-Aged Beed Burger", Ingredients = "1/3 Lb. Patty, Barbecue, Onion Ring, Bacon, Cheddar Cheese", Image = "angusbeef.jpg", Price = 12, Category = FoodCategory.Burguer  },
                };
            }
        }
        
        public IEnumerable<RestaurantCategory> RestaurantCategories
        {
            get
            {
                return new List<RestaurantCategory>
                {
                    RestaurantCategory.American,
                    RestaurantCategory.Asian,
                    RestaurantCategory.Breakfast,
                    RestaurantCategory.Burgers,
                    RestaurantCategory.Italians,
                    RestaurantCategory.Pizzas,
                    RestaurantCategory.Salads
                };
            }
        }

        public IEnumerable<Restaurant> Restaurants
        {
            get
            {
                return new List<Restaurant>
                {
                    new Restaurant { Name = "Eat Greek", Image = "eatgreek.jpg", Category = RestaurantCategory.Salads, DeliveryCost = "1", DeliveryTime = 20, Rating = 4.2d, Food = Foods1  },
                    new Restaurant { Name = "The House Burguer", Image = "theburguerhouse.jpg", Category = RestaurantCategory.Burgers, DeliveryCost = "1", DeliveryTime = 25, Rating = 4.1d, Food = Foods2  },
                    new Restaurant { Name = "Parmigiano", Image = "parmigiano.jpg", Category = RestaurantCategory.Italians, DeliveryCost = "2", DeliveryTime = 25, Rating = 3.2d, Food = Foods1  },
                    new Restaurant { Name = "Nickel & Dinner", Image = "nickeldinner.jpg", Category = RestaurantCategory.Breakfast, DeliveryCost = "2", DeliveryTime = 30, Rating = 3.9d, Food = Foods1  },            
                    new Restaurant { Name = "Salad History", Image = "saladhistory.jpg", Category = RestaurantCategory.Salads, DeliveryCost = "0.5", DeliveryTime = 30, Rating = 4.1d, Food = Foods1  },
                    new Restaurant { Name = "Wok", Image = "wok.jpg", Category = RestaurantCategory.Asian, DeliveryCost = "1", DeliveryTime = 30, Rating = 3.3d, Food = Foods1  }
                };
            }
        }

        public IEnumerable<RestaurantCategory> GetRestaurantCategories()
        {
            return RestaurantCategories;
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return Restaurants;
        }

        public IEnumerable<Restaurant> GetRestaurantsByCateogry(RestaurantCategory restaurantCategory)
        {
            return Restaurants.Where(r => r.Category == restaurantCategory);
        }
    }
}
