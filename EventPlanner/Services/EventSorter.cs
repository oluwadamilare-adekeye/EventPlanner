namespace EventPlanner.Services;

public class EventSorter
{
    public List<EventPlanner.Models.Event> SortEvents(
        List<EventPlanner.Models.Event> events, string sortOption)
    {
        if (sortOption == "dateAsc")
        {
            return events.OrderBy(e => e.Dates?.Start?.LocalDate).ToList();
        }
        else if (sortOption == "dateDesc")
        {
            return events.OrderByDescending(e => e.Dates?.Start?.LocalDate).ToList();
        }
        else if (sortOption == "nameAsc")
        {
            return events.OrderBy(e => e.Name).ToList();
        }
        else if (sortOption == "nameDesc")
        {
            return events.OrderByDescending(e => e.Name).ToList();
        }

        return events;
    }
}