# EventPlanner

## Project Overview

EventPlanner is a web-based application developed using **C# and Blazor** for the Service-Oriented Architecture CA1 assessment.

The application helps users discover events across Ireland and check weather forecasts for event locations, allowing them to plan their outings.

## Technologies Used

- C# / .NET 10
- Blazor Web App
- RestSharp — REST API requests
- Newtonsoft.Json — JSON deserialization
- Bootstrap — User interface styling
- JetBrains Rider — Development environment
- Git and GitHub — Version control

## Third-Party APIs

### 1. Ticketmaster Discovery API

Provides event information, including names, dates, venues, cities, images and ticket booking links.

Documentation: https://developer.ticketmaster.com/products-and-docs/apis/discovery-api/v2/

### 2. Open-Meteo Weather Forecast API

Provides weather forecasts using event venue coordinates, including minimum and maximum temperatures and precipitation probability.

Documentation: https://open-meteo.com/en/docs

## Features Implemented

- Search events by keyword or artist
- Filter events by city and category
- Sort events by date or name
- Automatically update results when filters change
- Display events using responsive cards
- View event dates, times, venues and locations
- Access Ticketmaster booking links
- Check weather forecasts for individual events
- Handle events outside the available weather forecast period

## Project Structure

- `Models/` — Classes representing API response data
- `Services/` — Classes responsible for retrieving external API data
- `Components/Pages/` — Blazor pages and user interface
- `Program.cs` — Application configuration and service registration

## Running the Application

1. Clone the GitHub repository.
2. Open `EventPlanner.sln` using JetBrains Rider or another compatible .NET IDE.
3. Restore NuGet dependencies.
4. Configure the Ticketmaster Consumer Key using .NET User Secrets:

   `dotnet user-secrets set "Ticketmaster:ApiKey" "YOUR_API_KEY"`

   Run this command inside the folder containing `EventPlanner.csproj`.

5. Build and run the application.

The Ticketmaster Consumer Key must not be committed to GitHub. Open-Meteo's non-commercial API does not require an API key.

## Testing

Manual testing has been carried out for event searching, filtering, sorting, API connectivity and event-specific weather forecasts.

Automated NUnit testing is planned.

## References

- Ticketmaster Discovery API: https://developer.ticketmaster.com/products-and-docs/apis/discovery-api/v2/
- Open-Meteo API Documentation: https://open-meteo.com/en/docs
- RestSharp Documentation: https://restsharp.dev/
- Newtonsoft.Json Documentation: https://www.newtonsoft.com/json/help/html/Introduction.htm
- Microsoft Blazor Documentation: https://learn.microsoft.com/en-us/aspnet/core/blazor/
