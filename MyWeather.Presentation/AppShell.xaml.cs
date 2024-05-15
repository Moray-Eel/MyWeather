using MyWeather.Presentation.ViewModels;

namespace MyWeather.Presentation;

public partial class AppShell
{
    public AppShell(AppShellViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
     }
}