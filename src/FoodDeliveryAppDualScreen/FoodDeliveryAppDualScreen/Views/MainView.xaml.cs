using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.DualScreen;

namespace FoodDeliveryAppDualScreen.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SetupViews();

            DualScreenInfo.Current.PropertyChanged += OnFormsWindowPropertyChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            DualScreenInfo.Current.PropertyChanged -= OnFormsWindowPropertyChanged;
        }

        void OnFormsWindowPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DualScreenInfo.Current.SpanMode) ||
                e.PropertyName == nameof(DualScreenInfo.Current.IsLandscape))
                SetupViews();
        }

        void SetupViews()
        {
            var currentSpanMode = DualScreenInfo.Current.SpanMode;

            if (currentSpanMode == TwoPaneViewMode.SinglePane)
                TwoPaneView.Pane1Length = 400;
            else
                TwoPaneView.Pane1Length = new GridLength(1, GridUnitType.Star);
        }
    }
}