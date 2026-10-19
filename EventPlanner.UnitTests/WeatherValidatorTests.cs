using EventPlanner.Services;

namespace EventPlanner.UnitTests;

public class WeatherValidatorTests
{
    private WeatherValidator validator = null!;

    [SetUp]
    public void Setup()
    {
        validator = new WeatherValidator();
    }

    [Test]
    public void IsDateValid_EventToday_ReturnsTrue()
    {
        var today = new DateOnly(2026, 10, 19);

        Assert.That(validator.IsDateValid(today, today), Is.True);
    }

    [Test]
    public void IsDateValid_EventWithinForecast_ReturnsTrue()
    {
        var today = new DateOnly(2026, 10, 19);

        Assert.That(validator.IsDateValid(today.AddDays(10), today), Is.True);
    }

    [Test]
    public void IsDateValid_EventTooFarAway_ReturnsFalse()
    {
        var today = new DateOnly(2026, 10, 19);

        Assert.That(validator.IsDateValid(today.AddDays(20), today), Is.False);
    }

    [Test]
    public void IsDateValid_PastEvent_ReturnsFalse()
    {
        var today = new DateOnly(2026, 10, 19);

        Assert.That(validator.IsDateValid(today.AddDays(-1), today), Is.False);
    }

    [Test]
    public void AreCoordinatesValid_ValidLocation_ReturnsTrue()
    {
        Assert.That(validator.AreCoordinatesValid(53.3498, -6.2603), Is.True);
    }

    [Test]
    public void AreCoordinatesValid_InvalidLatitude_ReturnsFalse()
    {
        Assert.That(validator.AreCoordinatesValid(100, -6.2603), Is.False);
    }

    [Test]
    public void AreCoordinatesValid_InvalidLongitude_ReturnsFalse()
    {
        Assert.That(validator.AreCoordinatesValid(53.3498, 200), Is.False);
    }

    [Test]
    public void AreCoordinatesValid_NaN_ReturnsFalse()
    {
        Assert.That(validator.AreCoordinatesValid(double.NaN, -6.2603), Is.False);
    }
}