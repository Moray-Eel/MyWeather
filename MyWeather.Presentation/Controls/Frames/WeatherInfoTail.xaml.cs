using System.Windows.Input;

namespace MyWeather.Presentation.Controls.Frames;

public partial class WeatherInfoTail : StackLayout
{
    public static readonly BindableProperty OnTapCommandProperty = BindableProperty.Create(
        nameof(OnTapCommand),
        typeof(ICommand),
        typeof(CustomSearchBar));

    public ICommand OnTapCommand
    {
        get => (ICommand)GetValue(OnTapCommandProperty);
        set => SetValue(OnTapCommandProperty, value);
    }
    
    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(nameof(Icon), typeof(ImageSource), typeof(WeatherInfoTail), default(ImageSource));

    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(WeatherInfoTail), default(string));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(nameof(Value), typeof(string), typeof(WeatherInfoTail), default(string));

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    public WeatherInfoTail()
    {
        InitializeComponent();
    }
}