var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
_ = builder.AddServiceDefaults();

// Add services to the container.
_ = builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
_ = app.UseExceptionHandler();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

_ = app.MapGet("/weatherforecast", () => Enumerable.Range(1, 5).Select(index => new WeatherForecast(
    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    Random.Shared.Next(-20, 55),
    summaries[Random.Shared.Next(summaries.Length)]
)).ToArray());

_ = app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
