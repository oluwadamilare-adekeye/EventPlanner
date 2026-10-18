using Newtonsoft.Json;

namespace EventPlanner.Models;

public class WeatherResponse
{
    [JsonProperty("current")]
    public CurrentWeather? Current { get; set; }
}

public class CurrentWeather
{
    [JsonProperty("temperature_2m")]
    public double Temperature { get; set; }

    [JsonProperty("precipitation")]
    public double Precipitation { get; set; }

    [JsonProperty("weather_code")]
    public int WeatherCode { get; set; }
}