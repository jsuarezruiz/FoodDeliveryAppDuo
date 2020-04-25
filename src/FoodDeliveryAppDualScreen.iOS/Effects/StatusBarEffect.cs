using System.Linq;
using FoodDeliveryAppDualScreen.iOS.Effects;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("FoodDeliveryAppDualScreen")]
[assembly: ExportEffect(typeof(StatusBarEffect), "StatusBarEffect")]
namespace FoodDeliveryAppDualScreen.iOS.Effects
{
    public class StatusBarEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var statusBarEffect = (FoodDeliveryAppDualScreen.Effects.StatusBarEffect)Element.Effects.FirstOrDefault(e => e is FoodDeliveryAppDualScreen.Effects.StatusBarEffect);

            if (statusBarEffect != null)
            {
                UIView statusBar = GetStatusBar();
                if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
                {
                    statusBar.BackgroundColor = statusBarEffect.BackgroundColor.ToUIColor();
                }
            }
        }

        protected override void OnDetached()
        {

        }

        UIView GetStatusBar()
        {
            UIView statusBar;
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                int tag = 123; 
                UIWindow window = UIApplication.SharedApplication.Windows.FirstOrDefault();
                statusBar = window.ViewWithTag(tag);

                if (statusBar == null)
                {
                    statusBar = new UIView(UIApplication.SharedApplication.StatusBarFrame)
                    {
                        Tag = tag
                    };

                    window.AddSubview(statusBar);
                }
            }
            else
            {
                statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            }

            return statusBar;
        }
    }
}