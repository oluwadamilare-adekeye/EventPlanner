using RestSharp;
using Newtonsoft.Json;
using EventPlanner.Models;

namespace EventPlanner.Services;

public class WeatherService
{
    private const string WEATHER_URL = "https://api.open-meteo.com/v1/forecast";

    public async Task<WeatherResponse?> GetWeatherAsync(
        double latitude, double longitude)
    {
        var client = new RestClient(WEATHER_URL);
        var request = new RestRequest();

        request.AddParameter("latitude", latitude);
        request.AddParameter("longitude", longitude);
        request.AddParameter("current",
            "temperature_2m,precipitation,weather_code");
        request.AddParameter("timezone", "auto");

        var response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful ||
            string.IsNullOrWhiteSpace(response.Content))
        {
            throw new HttpRequestException(
                $"Weather API request failed: {response.StatusCode}");
        }

        return JsonConvert.DeserializeObject<WeatherResponse>(
            response.Content);
    }
    
    public async Task<WeatherResponse?> GetEventForecastAsync(
        double latitude, double longitude, DateOnly eventDate)
    {
        var client = new RestClient(WEATHER_URL);
        var request = new RestRequest();

        request.AddParameter("latitude", latitude);
        request.AddParameter("longitude", longitude);

        request.AddParameter("daily",
            "temperature_2m_max,temperature_2m_min,precipitation_probability_max,weather_code");

        request.AddParameter("start_date", eventDate.ToString("yyyy-MM-dd"));
        request.AddParameter("end_date", eventDate.ToString("yyyy-MM-dd"));
        request.AddParameter("timezone", "auto");

        var response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful ||
            string.IsNullOrWhiteSpace(response.Content))
        {
            throw new HttpRequestException(
                $"Weather forecast request failed: {response.StatusCode}");
        }

        return JsonConvert.DeserializeObject<WeatherResponse>(
            response.Content);
    }
}