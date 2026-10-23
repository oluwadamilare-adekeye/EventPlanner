
using Microsoft.Extensions.Configuration;
using RestSharp;
using EventPlanner.Models;
using Newtonsoft.Json;

namespace EventPlanner.Services;

// Retrieves event information from Ticketmaster and implements IEventService.
public class EventService : IEventService
{
    private readonly string _apiKey;

    public EventService(IConfiguration configuration)
    {
        // Load the API key from configuration instead of hardcoding it.
        _apiKey = configuration["Ticketmaster:ApiKey"]
                  ?? throw new InvalidOperationException("Ticketmaster API key is missing.");
    }

    public async Task<List<EventPlanner.Models.Event>> GetEventsAsync(string keyword, string city, string category)
    {
        // RestSharp creates an HTTP GET request to Ticketmaster.
        var client = new RestClient("https://app.ticketmaster.com/discovery/v2/");
        var request = new RestRequest("events.json", Method.Get);

        // Set the authentication key, country and maximum number of results.
        request.AddParameter("apikey", _apiKey);
        request.AddParameter("countryCode", "IE");
        request.AddParameter("size", 5);

        // Only send search filters when the user has selected or entered them.
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

        // Execute the API request asynchronously.
        var response = await client.ExecuteAsync(request);

        // Stop processing if the API request fails or returns no content.
        if (!response.IsSuccessful || string.IsNullOrWhiteSpace(response.Content))
        {
            throw new HttpRequestException(
                $"Ticketmaster API request failed: {response.StatusCode}");
        }

        // Convert the JSON response into C# objects using Newtonsoft.Json.
        var eventResponse =
            JsonConvert.DeserializeObject<EventResponse>(response.Content);

        // Return the events, or an empty list if no events are present.
        return eventResponse?.Embedded?.Events
               ?? new List<EventPlanner.Models.Event>();
    }
}
