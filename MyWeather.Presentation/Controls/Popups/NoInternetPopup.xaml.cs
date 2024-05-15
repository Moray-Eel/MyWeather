using Material.Components.Maui;
using MyWeather.Presentation.ViewModels;

namespace MyWeather.Presentation.Controls.Popups;

public partial class NoInternetPopup : Popup
{
    public NoInternetPopup()
    {
        InitializeComponent();
    }

    private void Confirm_OnClicked(object? sender, TouchEventArgs e)
    {
        Close();
    }
}