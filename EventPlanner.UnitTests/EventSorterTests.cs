using EventPlanner.Models;
using EventPlanner.Services;

namespace EventPlanner.UnitTests;

public class EventSorterTests
{
    private EventSorter sorter = null!;

    [SetUp]
    public void Setup()
    {
        sorter = new EventSorter();
    }

    [Test]
    public void SortEvents_NameAscending_ReturnsAlphabeticalOrder()
    {
        var events = new List<EventPlanner.Models.Event>
        {
            new() { Name = "Oasis" },
            new() { Name = "Coldplay" },
            new() { Name = "Beyonce" }
        };

        var result = sorter.SortEvents(events, "nameAsc");

        Assert.That(result[0].Name, Is.EqualTo("Beyonce"));
        Assert.That(result[1].Name, Is.EqualTo("Coldplay"));
        Assert.That(result[2].Name, Is.EqualTo("Oasis"));
    }

    [Test]
    public void SortEvents_NameDescending_ReturnsReverseAlphabeticalOrder()
    {
        var events = new List<EventPlanner.Models.Event>
        {
            new() { Name = "Coldplay" },
            new() { Name = "Oasis" },
            new() { Name = "Beyonce" }
        };

        var result = sorter.SortEvents(events, "nameDesc");

        Assert.That(result[0].Name, Is.EqualTo("Oasis"));
        Assert.That(result[1].Name, Is.EqualTo("Coldplay"));
        Assert.That(result[2].Name, Is.EqualTo("Beyonce"));
    }

    [Test]
    public void SortEvents_EmptyList_ReturnsEmptyList()
    {
        var events = new List<EventPlanner.Models.Event>();

        var result = sorter.SortEvents(events, "nameAsc");

        Assert.That(result, Is.Empty);
    }
    
    [Test]
    public void SortEvents_DateAscending_ReturnsEarliestFirst()
    {
        var events = new List<EventPlanner.Models.Event>
        {
            new() { Dates = new EventDates {
                Start = new EventStart { LocalDate = "2026-12-10" } } },

            new() { Dates = new EventDates {
                Start = new EventStart { LocalDate = "2026-10-20" } } },

            new() { Dates = new EventDates {
                Start = new EventStart { LocalDate = "2026-11-15" } } }
        };

        var result = sorter.SortEvents(events, "dateAsc");

        Assert.That(result[0].Dates?.Start?.LocalDate,
            Is.EqualTo("2026-10-20"));

        Assert.That(result[1].Dates?.Start?.LocalDate,
            Is.EqualTo("2026-11-15"));

        Assert.That(result[2].Dates?.Start?.LocalDate,
            Is.EqualTo("2026-12-10"));
    }

    [Test]
    public void SortEvents_DateDescending_ReturnsLatestFirst()
    {
        var events = new List<EventPlanner.Models.Event>
        {
            new() { Dates = new EventDates {
                Start = new EventStart { LocalDate = "2026-10-20" } } },

            new() { Dates = new EventDates {
                Start = new EventStart { LocalDate = "2026-12-10" } } },

            new() { Dates = new EventDates {
                Start = new EventStart { LocalDate = "2026-11-15" } } }
        };

        var result = sorter.SortEvents(events, "dateDesc");

        Assert.That(result[0].Dates?.Start?.LocalDate,
            Is.EqualTo("2026-12-10"));

        Assert.That(result[1].Dates?.Start?.LocalDate,
            Is.EqualTo("2026-11-15"));

        Assert.That(result[2].Dates?.Start?.LocalDate,
            Is.EqualTo("2026-10-20"));
    }
}