using RestSharp;
using Newtonsoft.Json;
using EventPlanner.Models;

namespace EventPlanner.Services;

// Retrieves event-specific weather forecasts from Open-Meteo.
public class WeatherService : IWeatherService
{
    private const string WEATHER_URL = "https://api.open-meteo.com/v1/forecast";

    public async Task<WeatherResponse?> GetEventForecastAsync(
        double latitude, double longitude, DateOnly eventDate)
    {
        // Use RestSharp to prepare the forecast API request.
        var client = new RestClient(WEATHER_URL);
        var request = new RestRequest();

        // Venue coordinates come from the Ticketmaster event data.
        request.AddParameter("latitude", latitude);
        request.AddParameter("longitude", longitude);

        // Request daily temperatures, rain probability and weather codes.
        request.AddParameter("daily",
            "temperature_2m_max,temperature_2m_min,precipitation_probability_max,weather_code");

        // Use the same start and end date to request one event day's forecast.
        request.AddParameter("start_date", eventDate.ToString("yyyy-MM-dd"));
        request.AddParameter("end_date", eventDate.ToString("yyyy-MM-dd"));
        request.AddParameter("timezone", "auto");

        // Send the HTTP request asynchronously and await the response.
        var response = await client.ExecuteAsync(request);

        // Throw an exception when the weather API request is unsuccessful.
        if (!response.IsSuccessful ||
            string.IsNullOrWhiteSpace(response.Content))
        {
            throw new HttpRequestException(
                $"Weather forecast request failed: {response.StatusCode}");
        }

        // Convert the JSON response into the WeatherResponse model.
        return JsonConvert.DeserializeObject<WeatherResponse>(
            response.Content);
    }
}