using MyWeather.Presentation.ViewModels;

namespace MyWeather.Presentation;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}