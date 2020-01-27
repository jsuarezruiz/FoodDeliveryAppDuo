using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace FoodDeliveryAppDualScreen.Services
{
	public interface IHingeService : INotifyPropertyChanged, IDisposable
	{
		event EventHandler<HingeEventArgs> OnHingeUpdated;

		bool IsSpanned { get; }

		bool IsLandscape { get; }

		Rectangle GetHinge();
	}

	public class HingeEventArgs : EventArgs
	{
		public HingeEventArgs(int angle)
			: base()
		{
			Angle = angle;
		}

		public int Angle { get; private set; }
	}
}
