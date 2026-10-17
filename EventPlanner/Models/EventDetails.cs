using Newtonsoft.Json;

namespace EventPlanner.Models;

public class EventDates
{
    [JsonProperty("start")]
    public EventStart? Start { get; set; }
}

public class EventStart
{
    [JsonProperty("localDate")]
    public string? LocalDate { get; set; }

    [JsonProperty("localTime")]
    public string? LocalTime { get; set; }
}

public class EventImage
{
    [JsonProperty("url")]
    public string? Url { get; set; }
}

public class EventVenueEmbedded
{
    [JsonProperty("venues")]
    public List<EventVenue>? Venues { get; set; }
}

public class EventVenue
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("city")]
    public EventCity? City { get; set; }
}

public class EventCity
{
    [JsonProperty("name")]
    public string? Name { get; set; }
}