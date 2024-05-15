using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Drawing;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LinearGradientPaint = LiveChartsCore.SkiaSharpView.Painting.LinearGradientPaint;

namespace MyWeather.Presentation.ViewModels;

public sealed class TemperatureChartCardViewModel : ObservableObject
{
    public ObservableCollection<double> Values = new ObservableCollection<double>();
    public ObservableCollection<string> Labels = new ObservableCollection<string>();
    public ISeries[] Series { get; set; }
    public List<Axis> XAxes { get; set; }
    public List<Axis> YAxes { get; set; }

    public TemperatureChartCardViewModel()
    {
        SetupChart();
    }

    private void SetupChart()
    {
        Series = SetupSeries();
        XAxes = SetupXAxes();
        YAxes = SetupYAxes();
    }
    private ISeries[] SetupSeries() => [
        new LineSeries<double>
        {
            Values = Values,
            DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue}\u00b0c",
            DataLabelsPosition = DataLabelsPosition.Top,
            GeometryStroke = null,
            GeometryFill = null,
            Fill = null,
            Stroke = new SolidColorPaint(SKColors.White) {StrokeThickness = 2},
            DataLabelsPaint = new SolidColorPaint(SKColors.White) {StrokeThickness = 2},
            
        }
    ];
    private List<Axis> SetupXAxes() => [
        new Axis
        {
            TextSize = 8,
            Labels = Labels,
            LabelsAlignment = Align.End,
            LabelsPaint = new SolidColorPaint(SKColors.White) {StrokeThickness = 2},
        }
    ];
    private List<Axis> SetupYAxes() => [
        new Axis
        {
            IsVisible = false
        }
    ];
}



