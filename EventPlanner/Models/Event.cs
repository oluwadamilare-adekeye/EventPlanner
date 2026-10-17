using Newtonsoft.Json;

namespace EventPlanner.Models;

public class Event
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }
    
    [JsonProperty("dates")]
    public EventDates? Dates { get; set; }

    [JsonProperty("images")]
    public List<EventImage>? Images { get; set; }

    [JsonProperty("_embedded")]
    public EventVenueEmbedded? Embedded { get; set; }
}