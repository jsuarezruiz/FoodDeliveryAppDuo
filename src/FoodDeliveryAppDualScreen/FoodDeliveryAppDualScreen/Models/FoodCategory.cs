namespace FoodDeliveryAppDualScreen.Models
{
    public class FoodCategory
    {
        public string Name { get; set; }

        public static FoodCategory Breaskfast { get { return new FoodCategory { Name = "Breaskfast" }; } }
        public static FoodCategory Burguer { get { return new FoodCategory { Name = "Burguer" }; } }
        public static FoodCategory Desert { get { return new FoodCategory { Name = "Desert" }; } }
        public static FoodCategory Pizza { get { return new FoodCategory { Name = "Pizza" }; } }
        public static FoodCategory Salad { get { return new FoodCategory { Name = "Salad" }; } }
    }
}