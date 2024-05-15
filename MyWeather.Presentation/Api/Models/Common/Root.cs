namespace MyWeather.Presentation.Api.Models.Common;

public class Root
{
    public string Cod { get; set; }
    public int Message { get; set; }
    public int Cnt { get; set; }
    public List<List> List { get; set; }
    public City City { get; set; }
}
