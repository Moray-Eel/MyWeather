using MyWeather.Presentation.ViewModels;

namespace MyWeather.Presentation;

public partial class InitPage : ContentPage
{
    public InitPage(InitPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}