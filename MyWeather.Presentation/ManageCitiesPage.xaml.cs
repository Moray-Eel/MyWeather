using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeather.Presentation.ViewModels;

namespace MyWeather.Presentation;

public partial class ManageCitiesPage : ContentPage
{
    public ManageCitiesPage(ManageCitiesPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}