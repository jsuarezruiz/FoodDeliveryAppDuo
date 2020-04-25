using System.Linq;
using Android.Views;
using FoodDeliveryAppDualScreen.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("FoodDeliveryAppDualScreen")]
[assembly: ExportEffect(typeof(StatusBarEffect), "StatusBarEffect")]
namespace FoodDeliveryAppDualScreen.Droid.Effects
{
    public class StatusBarEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var statusBarEffect = (FoodDeliveryAppDualScreen.Effects.StatusBarEffect)Element.Effects.FirstOrDefault(e => e is FoodDeliveryAppDualScreen.Effects.StatusBarEffect);

            if (statusBarEffect != null)
            {
                var backgroundColor = statusBarEffect.BackgroundColor.ToAndroid();
                Window currentWindow = GetCurrentWindow();
                currentWindow.SetStatusBarColor(backgroundColor);
            }
        }

        protected override void OnDetached()
        {

        }

        Window GetCurrentWindow()
        {
            var window = Xamarin.Essentials.Platform.CurrentActivity.Window;

            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }
    }
}