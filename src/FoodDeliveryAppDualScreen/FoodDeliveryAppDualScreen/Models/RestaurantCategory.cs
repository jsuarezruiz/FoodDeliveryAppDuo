namespace FoodDeliveryAppDualScreen.Models
{
    public class RestaurantCategory
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public static RestaurantCategory American { get { return new RestaurantCategory { Name = "American", Icon = "american" }; } }
        public static RestaurantCategory Asian { get { return new RestaurantCategory { Name = "Asian", Icon = "asian" }; } }
        public static RestaurantCategory Breakfast { get { return new RestaurantCategory { Name = "Breakfast", Icon = "sandwitch" }; } }
        public static RestaurantCategory Burgers { get { return new RestaurantCategory { Name = "Burgers", Icon = "burguer" }; } }
        public static RestaurantCategory Italians { get { return new RestaurantCategory { Name = "Italians", Icon = "italian" }; } }
        public static RestaurantCategory Pizzas { get { return new RestaurantCategory { Name = "Pizzas", Icon = "pizza" }; } }
        public static RestaurantCategory Salads { get { return new RestaurantCategory { Name = "Salads", Icon = "salad" }; } }
    }
}
