using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpnado.MaterialFrame;

namespace MyWeather.Presentation.Controls.Frames;

public partial class CityCard : MaterialFrame
{ public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(CityCard), default(string));

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public static readonly BindableProperty DescriptionProperty =
        BindableProperty.Create(nameof(Description), typeof(string), typeof(CityCard), default(string));

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public static readonly BindableProperty TemperatureProperty =
        BindableProperty.Create(nameof(Temperature), typeof(string), typeof(CityCard), default(string));

    public string Temperature
    {
        get => (string)GetValue(TemperatureProperty);
        set => SetValue(TemperatureProperty, value);
    }

    public CityCard()
    {
        InitializeComponent();
    }
}