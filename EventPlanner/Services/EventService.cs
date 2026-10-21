using Microsoft.Extensions.Configuration;
using RestSharp;
using EventPlanner.Models;
using Newtonsoft.Json;

namespace EventPlanner.Services;

public class EventService : IEventService
{
    private readonly string _apiKey;

    public EventService(IConfiguration configuration)
    {
        _apiKey = configuration["Ticketmaster:ApiKey"]
                  ?? throw new InvalidOperationException("Ticketmaster API key is missing.");
    }
    
    public async Task<List<EventPlanner.Models.Event>> GetEventsAsync(string keyword, string city, string category)
    {
        var client = new RestClient("https://app.ticketmaster.com/discovery/v2/");
        var request = new RestRequest("events.json", Method.Get);

        request.AddParameter("apikey", _apiKey);
        request.AddParameter("countryCode", "IE");
        request.AddParameter("size", 5);
        
        if (!string.IsNullOrWhiteSpace(keyword))
        {
            request.AddParameter("keyword", keyword);
        }
        
        if (!string.IsNullOrWhiteSpace(city))
        {
            request.AddParameter("city", city);
        }
        
        if (!string.IsNullOrWhiteSpace(category))
        {
            request.AddParameter("classificationName", category);
        }

        var response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful || string.IsNullOrWhiteSpace(response.Content))
        {
            throw new HttpRequestException(
                $"Ticketmaster API request failed: {response.StatusCode}");
        }

        var eventResponse =
            JsonConvert.DeserializeObject<EventResponse>(response.Content);

        return eventResponse?.Embedded?.Events
               ?? new List<EventPlanner.Models.Event>();
    }
}