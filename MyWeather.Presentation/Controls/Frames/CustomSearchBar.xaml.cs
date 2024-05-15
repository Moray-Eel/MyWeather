using System.Windows.Input;
using Sharpnado.MaterialFrame;

namespace MyWeather.Presentation.Controls.Frames;

public partial class CustomSearchBar : MaterialFrame
{
    public CustomSearchBar()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty TextChangedCommandProperty = BindableProperty.Create(
        nameof(TextChangedCommand),
        typeof(ICommand),
        typeof(CustomSearchBar));

    public ICommand TextChangedCommand
    {
        get => (ICommand)GetValue(TextChangedCommandProperty);
        set => SetValue(TextChangedCommandProperty, value);
    }
}