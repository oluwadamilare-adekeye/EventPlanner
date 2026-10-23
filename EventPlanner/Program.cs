using EventPlanner.Components;
using EventPlanner.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services with dependency injection.
// Each interface is linked to its implementation.
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

// Register the classes used for sorting and weather validation.
builder.Services.AddScoped<EventSorter>();
builder.Services.AddScoped<WeatherValidator>();

// Configure Blazor components and enable server-side interactivity.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Use production error handling and HSTS outside development.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

// Handle missing pages and redirect HTTP requests to HTTPS.
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

// Enable antiforgery protection for supported requests.
app.UseAntiforgery();

// Serve static assets and map interactive Blazor components.
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Start the web application.
app.Run();