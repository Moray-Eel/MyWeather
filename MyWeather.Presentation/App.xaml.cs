using MyWeather.Infrastructure;

namespace MyWeather.Presentation;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App(InitPage initPage)
    {
        InitializeComponent();
        MainPage = initPage;
    }
}