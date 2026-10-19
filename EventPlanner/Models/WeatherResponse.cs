using Newtonsoft.Json;

namespace EventPlanner.Models;

public class WeatherResponse
{
    [JsonProperty("daily")]
    public DailyWeather? Daily { get; set; }
}

public class DailyWeather
{
    [JsonProperty("time")]
    public List<string>? Time { get; set; }

    [JsonProperty("temperature_2m_max")]
    public List<double>? MaxTemperature { get; set; }

    [JsonProperty("temperature_2m_min")]
    public List<double>? MinTemperature { get; set; }

    [JsonProperty("precipitation_probability_max")]
    public List<double>? RainProbability { get; set; }

    [JsonProperty("weather_code")]
    public List<int>? WeatherCodes { get; set; }
}
