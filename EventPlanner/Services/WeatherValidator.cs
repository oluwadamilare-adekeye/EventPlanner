namespace EventPlanner.Services;

public class WeatherValidator
{
    public bool IsDateValid(DateOnly eventDate, DateOnly today)
    {
        return eventDate >= today &&
               eventDate <= today.AddDays(15);
    }

    public bool AreCoordinatesValid(double latitude, double longitude)
    {
        return double.IsFinite(latitude) &&
               double.IsFinite(longitude) &&
               latitude >= -90 && latitude <= 90 &&
               longitude >= -180 && longitude <= 180;
    }
}