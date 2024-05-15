using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyWeather.Presentation.ViewModels;

public sealed partial class SearchBarViewModel : ObservableObject
{
    public ICommand? ExternalTextChangedCommand { get; set; }
    [RelayCommand]
    Task Search()
    {
        ExternalTextChangedCommand?.Execute(null);
        return Task.CompletedTask;
    }
}