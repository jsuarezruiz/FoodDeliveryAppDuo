using System;
using Xamarin.Forms;

namespace FoodDeliveryAppDualScreen.Effects
{
    public class DragAndDropEffect : RoutingEffect
    {
        public string Uri { get; set; }

        public string Description { get; set; }

        public DragAndDropEffect() : base("FoodDeliveryAppDualScreen.DragAndDropEffect")
        {

        }
    }
}