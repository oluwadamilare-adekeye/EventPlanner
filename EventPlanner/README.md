# EventPlanner

## Project Overview

EventPlanner is a web-based event discovery application developed using **C#, .NET 10 and Blazor** for the Service-Oriented Architecture CA1 assessment.

The application combines event information from Ticketmaster with location-specific weather forecasts from Open-Meteo. It allows users to discover events across Ireland, view event details and check weather conditions when planning to attend.

## Technologies Used

- **C# / .NET 10** — Application development
- **Blazor Web App** — Interactive web interface
- **RestSharp** — HTTP requests to external APIs
- **Newtonsoft.Json** — JSON deserialization
- **Bootstrap and custom CSS** — Responsive user interface
- **NUnit** — Automated unit testing
- **JetBrains Rider** — Development environment
- **Git and GitHub** — Version control

## Third-Party APIs

### 1. Ticketmaster Discovery API

The Ticketmaster Discovery API provides information about events, including event names, dates, start times, venues, cities, images and ticket links.

The application uses this API to retrieve events in Ireland. Users can search using keywords and apply city or category filters.

Documentation: https://developer.ticketmaster.com/products-and-docs/apis/discovery-api/v2/

### 2. Open-Meteo Weather Forecast API

The Open-Meteo API provides weather forecasts based on geographical coordinates.

EventPlanner uses venue latitude and longitude obtained from Ticketmaster to request weather forecasts for individual events. Forecast information includes minimum and maximum temperatures and precipitation probability.

The application validates coordinates and event dates before requesting a forecast. Events outside the supported forecast period display an appropriate message.

Documentation: https://open-meteo.com/en/docs

## Features Implemented

- Search events by keyword, artist or event name
- Filter events by city and category
- Sort events by date or event name in ascending or descending order
- Automatically update results when city or category filters change
- Display events using responsive cards
- Display event dates, times, venues and cities
- Show event images supplied by Ticketmaster
- Open external Ticketmaster ticket links
- Request weather forecasts for individual events
- Display minimum and maximum temperatures and precipitation probability
- Validate event dates and venue coordinates
- Handle unavailable forecasts, empty search results and API errors
- Display loading and feedback messages

## Project Structure

- `Models/` — Data models used to represent responses from external APIs
- `Services/EventService.cs` — Retrieves event information from Ticketmaster
- `Services/WeatherService.cs` — Retrieves forecasts from Open-Meteo
- `Services/EventSorter.cs` — Handles event sorting using LINQ
- `Services/WeatherValidator.cs` — Validates forecast dates and coordinates
- `Components/Pages/Home.razor` — Main event search interface and user interactions
- `wwwroot/app.css` — Application styling
- `Program.cs` — Application configuration and dependency injection
- `EventPlanner.UnitTests/` — Separate NUnit testing project

## Running the Application

### Prerequisites

- .NET 10 SDK
- JetBrains Rider or another compatible .NET development environment
- A Ticketmaster Developer API Consumer Key
- An internet connection for external API requests

### Setup

1. Clone the GitHub repository.
2. Open the EventPlanner solution in Rider.
3. Restore NuGet dependencies.
4. Open a terminal in the folder containing `EventPlanner.csproj`.
5. Configure the Ticketmaster Consumer Key using .NET User Secrets:

   `dotnet user-secrets set "Ticketmaster:ApiKey" "YOUR_API_KEY"`

6. Build and run the application from Rider or the .NET command-line interface.

The Ticketmaster API key is loaded from application configuration rather than being stored directly in the source code.

**Important:** Do not commit the real Ticketmaster Consumer Key to GitHub.

The Open-Meteo non-commercial API does not require an API key.

## Testing

EventPlanner has been tested using both automated unit tests and manual application testing.

### Automated Unit Testing

The project contains **13 NUnit unit tests**, all of which passed during the final Rider test run.

**EventSorterTests — 5 tests**

- Sort events by date in ascending order
- Sort events by date in descending order
- Sort events by name in ascending order
- Sort events by name in descending order
- Handle an empty event collection

**WeatherValidatorTests — 8 tests**

These cover valid and invalid event dates, forecast-date boundaries, geographical coordinate validation and invalid numerical values.

The automated tests verify the sorting and validation logic independently of the external APIs.

Tests can be run in Rider's Unit Tests window or using the following command from the solution directory:

`dotnet test`

### Manual Testing

Manual tests were performed to check:

- Keyword-based event searches
- City and category filtering
- Ascending and descending sorting
- Ticketmaster API connectivity
- Event card content and images
- Ticket booking links
- Weather API connectivity
- Display of event-specific forecasts
- Messages for events outside the forecast period

## Limitations

- Event searches currently request up to five events per API call.
- Weather forecasts are available only for dates within the supported 16-day forecast window.
- Results depend on the availability and responses of the external APIs.
- The application does not provide ticket purchasing directly; users are redirected to Ticketmaster.

## References

- Ticketmaster Discovery API Documentation: https://developer.ticketmaster.com/products-and-docs/apis/discovery-api/v2/
- Open-Meteo Weather Forecast API: https://open-meteo.com/en/docs
- RestSharp Documentation: https://restsharp.dev/
- Newtonsoft.Json Documentation: https://www.newtonsoft.com/json/help/html/Introduction.htm
- Microsoft ASP.NET Core Blazor Documentation: https://learn.microsoft.com/en-us/aspnet/core/blazor/
- NUnit Documentation: https://docs.nunit.org/
- Microsoft .NET User Secrets Documentation: https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets