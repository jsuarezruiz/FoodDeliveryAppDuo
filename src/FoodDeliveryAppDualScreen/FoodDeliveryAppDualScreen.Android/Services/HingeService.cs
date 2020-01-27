using System;
using System.ComponentModel;
using System.Linq;
using Android.App;
using Android.Views;
using FoodDeliveryAppDualScreen.Droid.Services;
using FoodDeliveryAppDualScreen.Services;
using Microsoft.Device.Display;
using Xamarin.Forms;

[assembly: Dependency(typeof(HingeService))]
namespace FoodDeliveryAppDualScreen.Droid.Services
{
    public class HingeService : IHingeService, IDisposable
	{
		static ScreenHelper _helper;
		readonly bool _isDuo = false;
		readonly HingeSensor _hingeSensor;
		int _hingeAngle;
		Rectangle _hingeLocation;
		static Activity _mainActivity;

		public static Activity MainActivity
		{
			get => _mainActivity;
			set => _mainActivity = value;
		}

		ILayoutService LayoutService => DependencyService.Get<ILayoutService>();

		public HingeService()
		{
			if (_helper == null)
				_helper = new ScreenHelper();

			_isDuo = _helper.Initialize(MainActivity);

			if (_isDuo)
			{
				_hingeSensor = new HingeSensor(MainActivity);
				_hingeSensor.OnSensorChanged += OnSensorChanged;
				_hingeSensor.StartListening();
			}
		}

		void OnSensorChanged(object sender, HingeSensor.HingeSensorChangedEventArgs e)
		{
			if (_hingeLocation != GetHinge())
			{
				_hingeLocation = GetHinge();
				LayoutService.AddLayoutGuide("Hinge", _hingeLocation);
			}

			if (_hingeAngle != e.HingeAngle)
				OnHingeUpdated?.Invoke(this, new HingeEventArgs(e.HingeAngle));

			_hingeAngle = e.HingeAngle;
		}

		public void Dispose()
		{
			if (_hingeSensor != null)
			{
				_hingeSensor.OnSensorChanged -= OnSensorChanged;
				_hingeSensor.StopListening();
			}
		}

		public bool IsSpanned
			=> _isDuo && (_helper?.IsDualMode ?? false);

		public Rectangle GetHinge()
		{
			if (!_isDuo || _helper == null)
				return Rectangle.Zero;

			var rotation = ScreenHelper.GetRotation(_helper.Activity);
			var hinge = _helper.DisplayMask.GetBoundingRectsForRotation(rotation).FirstOrDefault();
			var hingeDp = new Rectangle(PixelsToDp(hinge.Left), PixelsToDp(hinge.Top), PixelsToDp(hinge.Width()), PixelsToDp(hinge.Height()));

			return hingeDp;
		}

		public bool IsLandscape
		{
			get
			{
				if (!_isDuo || _helper == null)
					return false;

				var rotation = ScreenHelper.GetRotation(_helper.Activity);

				return (rotation == SurfaceOrientation.Rotation270 || rotation == SurfaceOrientation.Rotation90);
			}
		}

		double PixelsToDp(double px)
			=> px / MainActivity.Resources.DisplayMetrics.Density;

		public event EventHandler<HingeEventArgs> OnHingeUpdated;
		public event PropertyChangedEventHandler PropertyChanged;
	}
}