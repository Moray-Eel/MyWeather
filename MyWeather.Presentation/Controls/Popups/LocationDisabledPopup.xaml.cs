using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Material.Components.Maui;

namespace MyWeather.Presentation.Controls.Popups;

public partial class LocationDisabledPopup : Popup
{
    public LocationDisabledPopup()
    {
        InitializeComponent();
    }
    private void Confirm_OnClicked(object? sender, TouchEventArgs e)
    {
        Close();
    }
}