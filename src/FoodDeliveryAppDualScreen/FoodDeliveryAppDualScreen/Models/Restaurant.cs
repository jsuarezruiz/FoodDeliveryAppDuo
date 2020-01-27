using System.Collections.Generic;

namespace FoodDeliveryAppDualScreen.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public RestaurantCategory Category { get; set; }
        public double Rating { get; set; }
        public double DeliveryTime { get; set; }
        public string DeliveryCost { get; set; }
        public IEnumerable<Food> Food { get; set; }
    }
}