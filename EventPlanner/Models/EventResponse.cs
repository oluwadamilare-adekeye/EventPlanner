using Newtonsoft.Json;

namespace EventPlanner.Models;

public class EventResponse
{
    [JsonProperty("_embedded")]
    public EventEmbedded? Embedded { get; set; }
}

public class EventEmbedded
{
    [JsonProperty("events")]
    public List<Event>? Events { get; set; }
}