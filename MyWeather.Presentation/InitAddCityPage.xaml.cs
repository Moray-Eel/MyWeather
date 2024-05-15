using MyWeather.Presentation.ViewModels;

namespace MyWeather.Presentation;

public partial class InitAddCityPage : ContentPage
{
	public InitAddCityPage(InitAddCityViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}