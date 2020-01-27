using FoodDeliveryAppDualScreen.Controls;
using Xamarin.Forms;

namespace FoodDeliveryAppDualScreen.Views
{
    public partial class MainView : DuoPage
    {
        public MainView()
        {
            InitializeComponent();

            TwoPaneView.TallModeConfiguration = TwoPaneViewTallModeConfiguration.TopBottom;
        }
    }
}