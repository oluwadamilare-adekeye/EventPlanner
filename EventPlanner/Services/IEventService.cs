namespace EventPlanner.Services;

public interface IEventService
{
    Task<List<EventPlanner.Models.Event>> GetEventsAsync(string keyword, string city, string category);
}