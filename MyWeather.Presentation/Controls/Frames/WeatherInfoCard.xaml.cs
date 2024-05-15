using System.Windows.Input;
using Sharpnado.MaterialFrame;

namespace MyWeather.Presentation.Controls.Frames;

public partial class WeatherInfoCard : MaterialFrame
{
    public static readonly BindableProperty OnTailTapChangedCommandProperty = BindableProperty.Create(
        nameof(OnTailTapChangedCommand),
        typeof(ICommand),
        typeof(CustomSearchBar));

    public ICommand OnTailTapChangedCommand
    {
        get => (ICommand)GetValue(OnTailTapChangedCommandProperty);
        set => SetValue(OnTailTapChangedCommandProperty, value);
    }
    public WeatherInfoCard()
    {
        InitializeComponent();
    }
}