namespace MyWeather.Presentation.Constants;

public static class IconPaths
{
    public static string GetPath(string condition)
        => condition switch
        {
            "Mist" => "white_mist.png",
            "Clouds" => "white_brokenclouds.png",
            "Clear" => "white_clearsky.png",
            "Snow" => "white_snow.png",
            "Thunderstorm" => "white_thunderstorm.png",
            "Drizzle" => "white_snow.png",
            "Rain" => "white_rain.png",
            _ => "white_clearsky.png"
        };
}