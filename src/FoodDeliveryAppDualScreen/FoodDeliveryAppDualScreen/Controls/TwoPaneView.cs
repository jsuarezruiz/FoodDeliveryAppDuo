using System.Linq;
using FoodDeliveryAppDualScreen.Views;
using Xamarin.Forms;

namespace FoodDeliveryAppDualScreen.Controls
{
    public enum TwoPaneViewTallModeConfiguration
    {
        SinglePane,
        TopBottom,
        BottomTop,
    }

    public enum TwoPaneViewWideModeConfiguration
    {
        SinglePane,
        LeftRight,
        RightLeft,
    }

    public class TwoPaneView : Layout<View>
    {
        ContentPage _contentPage;
        FormsWindow _screenViewModel;

        public static readonly BindableProperty TallModeConfigurationProperty = BindableProperty.Create("TallModeConfiguration", typeof(TwoPaneViewTallModeConfiguration), typeof(TwoPaneView), defaultValue: TwoPaneViewTallModeConfiguration.SinglePane);
        public static readonly BindableProperty WideModeConfigurationProperty = BindableProperty.Create("WideModeConfiguration", typeof(TwoPaneViewWideModeConfiguration), typeof(TwoPaneView), defaultValue: TwoPaneViewWideModeConfiguration.LeftRight);


        public TwoPaneViewTallModeConfiguration TallModeConfiguration
        {
            get { return (TwoPaneViewTallModeConfiguration)GetValue(TallModeConfigurationProperty); }
            set { SetValue(TallModeConfigurationProperty, value); }
        }

        public TwoPaneViewWideModeConfiguration WideModeConfiguration
        {
            get { return (TwoPaneViewWideModeConfiguration)GetValue(WideModeConfigurationProperty); }
            set { SetValue(WideModeConfigurationProperty, value); }
        }

        public TwoPaneView() : base()
        {
            this.VerticalOptions = LayoutOptions.FillAndExpand;
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
        }

        FormsWindow ScreenViewModel
        {
            get
            {
                ContentPage parentPage = null;

                var parent = this.Parent;

                while (parentPage == null && parent != null)
                {
                    parentPage = parent as ContentPage;
                    parent = parent?.Parent;
                }

                if (_contentPage != parentPage && parentPage != null)
                {
                    if (_screenViewModel != null)
                        _screenViewModel.PropertyChanged -= OnScreenViewModelChanged;

                    _screenViewModel = new FormsWindow(parentPage);
                    _contentPage = parentPage;
                    _screenViewModel.PropertyChanged += OnScreenViewModelChanged;
                }

                return _screenViewModel;
            }
        }

        private void OnScreenViewModelChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InvalidateLayout();
        }

        public View Pane1
            => Children?.FirstOrDefault();

        public View Pane2
            => Children?.Skip(1)?.FirstOrDefault();

        public bool IsDualView
            => Pane1.IsVisible && Pane2.IsVisible;

        public bool IsLandscape
            => ScreenViewModel.IsLandscape;

        public bool IsPortrait
            => !IsLandscape;

        public bool IsSpanned
            => ScreenViewModel.IsSpanned;

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            var left = Pane1;
            var right = Pane2;

            if (left == null)
                return;

            var formsWindows = ScreenViewModel;
            var pane1 = formsWindows.Pane1;
            var pane2 = formsWindows.Pane2;

            Rectangle leftViewRect = Rectangle.Zero;
            Rectangle rightViewRect = Rectangle.Zero;

            if (!formsWindows.IsSpanned)
            {
                leftViewRect = pane1;
                rightViewRect = pane2;
                if (right != null)
                    right.IsVisible = false;

                left.IsVisible = true;
            }
            else if (formsWindows.IsPortrait)
            {
                if (WideModeConfiguration == TwoPaneViewWideModeConfiguration.LeftRight)
                {
                    if (right != null)
                        right.IsVisible = true;

                    leftViewRect = pane1;
                    rightViewRect = pane2;
                }
                else if (WideModeConfiguration == TwoPaneViewWideModeConfiguration.RightLeft)
                {
                    if (right != null)
                        right.IsVisible = true;

                    left.IsVisible = true;
                    leftViewRect = pane2;
                    rightViewRect = pane1;
                }
                else if (WideModeConfiguration == TwoPaneViewWideModeConfiguration.SinglePane)
                {
                    if (right != null)
                        right.IsVisible = false;

                    left.IsVisible = true;
                    leftViewRect = formsWindows.ContainerArea;
                }
            }
            else
            {
                if (TallModeConfiguration == TwoPaneViewTallModeConfiguration.TopBottom)
                {
                    if (right != null)
                        right.IsVisible = true;

                    leftViewRect = pane1;
                    rightViewRect = pane2;
                }
                else if (TallModeConfiguration == TwoPaneViewTallModeConfiguration.BottomTop)
                {
                    if (right != null)
                        right.IsVisible = true;

                    left.IsVisible = true;
                    leftViewRect = pane2;
                    rightViewRect = pane1;
                }
                else if (TallModeConfiguration == TwoPaneViewTallModeConfiguration.SinglePane)
                {
                    if (right != null)
                        right.IsVisible = false;

                    left.IsVisible = true;
                    leftViewRect = formsWindows.ContainerArea;
                }
            }

            if (left.IsVisible)
                LayoutChildIntoBoundingRegion(left, leftViewRect);

            if (right != null && right.IsVisible)
                LayoutChildIntoBoundingRegion(right, rightViewRect);

            OnPropertyChanged(nameof(IsLandscape));
            OnPropertyChanged(nameof(IsPortrait));
            OnPropertyChanged(nameof(IsDualView));
            OnPropertyChanged(nameof(IsSpanned));
        }

    }
}