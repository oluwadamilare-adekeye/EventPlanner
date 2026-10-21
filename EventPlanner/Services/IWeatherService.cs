namespace EventPlanner.Services;
using EventPlanner.Models;

public interface IWeatherService
{
    Task<WeatherResponse?> GetEventForecastAsync(double latitude, double longitude, DateOnly eventDate);
}