using System;
using System.Globalization;
using Xamarin.Forms;

namespace FoodDeliveryAppDualScreen.Converters
{
    public class IsRestaurantMenuVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform != Device.Android)
                return true;

            bool IsSpanned = (bool)value;

            return IsSpanned;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
