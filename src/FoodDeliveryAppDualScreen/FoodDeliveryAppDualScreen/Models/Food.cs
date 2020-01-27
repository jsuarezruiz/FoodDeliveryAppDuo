namespace FoodDeliveryAppDualScreen.Models
{
    public class Food
    {
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public FoodCategory Category { get; set; }
    }
}
