using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeather.Presentation.ViewModels;

namespace MyWeather.Presentation.Controls.Views;

public partial class ContextMenu : ContentView
{
    public ContextMenu()
    {
        InitializeComponent();
        BindingContext = new ContextMenuViewModel();
    }
}