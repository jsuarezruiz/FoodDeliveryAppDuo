using System;
using System.Linq;
using Android.Content;
using FoodDeliveryAppDualScreen.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AView = Android.Views.View;
using ADragFlags = Android.Views.DragFlags;
using AUri = Android.Net.Uri;

[assembly: ExportEffect(typeof(DragAndDropEffect), "DragAndDropEffect")]
namespace FoodDeliveryAppDualScreen.Droid.Effects
{
    public class DragAndDropEffect : PlatformEffect
    {
        protected override void OnAttached()
        {            
            Control.SetOnLongClickListener(new LongClickListen(this));          
        }

        protected override void OnDetached()
        {
            if (Control != null && Control.Handle != IntPtr.Zero)
                Control.SetOnLongClickListener(null);
        }

        public class LongClickListen : Java.Lang.Object, AView.IOnLongClickListener
        {
            DragAndDropEffect _dragAndDropEffect;

            public LongClickListen(DragAndDropEffect dragAndDropEffect)
            {
                _dragAndDropEffect = dragAndDropEffect;
            }

            public bool OnLongClick(AView v)
            {
                if (v.Handle == IntPtr.Zero)
                    return false;

                var dragAndDropEffect = (FoodDeliveryAppDualScreen.Effects.DragAndDropEffect)
                        _dragAndDropEffect.Element.Effects.FirstOrDefault(e => e is FoodDeliveryAppDualScreen.Effects.DragAndDropEffect);

                string uri = dragAndDropEffect.Uri;

                if(uri == null && _dragAndDropEffect.Element is Image i && i.Source is UriImageSource uriIS)
                {
                    uri = uriIS.Uri.ToString();
                }

                if (String.IsNullOrWhiteSpace(uri))
                    return true;

                var data = ClipData.NewRawUri(new Java.Lang.String(dragAndDropEffect.Description ?? String.Empty),
                    AUri.Parse(uri.ToString()));

                var dragShadowBuilder = new AView.DragShadowBuilder(v);

                v.StartDragAndDrop(data, dragShadowBuilder, v, (int)ADragFlags.Global | (int)ADragFlags.GlobalUriRead | (int)ADragFlags.GlobalUriWrite);
                return true;
            }
        }
    }
}