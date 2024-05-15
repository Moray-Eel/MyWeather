using Material.Components.Maui;
using MyWeather.Presentation.ViewModels;

namespace MyWeather.Presentation.Controls.Popups;

public partial class CityAlreadyExistsPopup : Popup
{
    public CityAlreadyExistsPopup()
    {
        InitializeComponent();
    }

    private void Confirm_OnClicked(object? sender, TouchEventArgs e)
    {
        Close();
    }
}