using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeather.Presentation.ViewModels;

namespace MyWeather.Presentation;

public partial class AddCityPage : ContentPage
{
    public AddCityPage(AddCityViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}