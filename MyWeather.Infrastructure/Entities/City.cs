﻿using SQLite;

namespace MyWeather.Infrastructure.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    
}