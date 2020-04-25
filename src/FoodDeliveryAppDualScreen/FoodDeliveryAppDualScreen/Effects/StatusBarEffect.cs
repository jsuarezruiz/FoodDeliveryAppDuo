using Xamarin.Forms;

namespace FoodDeliveryAppDualScreen.Effects
{
    public class StatusBarEffect : RoutingEffect
    {
        public Color BackgroundColor { get; set; }

        public StatusBarEffect() : base("FoodDeliveryAppDualScreen.StatusBarEffect")
        {

        }
    }
}