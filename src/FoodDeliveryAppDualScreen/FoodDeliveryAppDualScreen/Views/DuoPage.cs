namespace Xamarin.Forms
{
    public class DuoPage : ContentPage
    {
        public DuoPage()
        {
        }

        public static readonly BindableProperty FormsWindowProperty = BindableProperty.Create("FormsWindow", typeof(FormsWindow), typeof(DuoPage),
            defaultValueCreator: OnDefaultValueCreator);

        private static object OnDefaultValueCreator(BindableObject bindable)
        {
            return new FormsWindow((ContentPage)bindable);
        }

        public FormsWindow FormsWindow
        {
            get { return (FormsWindow)GetValue(FormsWindowProperty); }
            set { SetValue(FormsWindowProperty, value); }
        }
    }
}