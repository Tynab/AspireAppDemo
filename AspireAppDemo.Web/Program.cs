using AspireAppDemo.Web;
using AspireAppDemo.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
_ = builder.AddServiceDefaults();
builder.AddRedisOutputCache("cache");

// Add services to the container.
_ = builder.Services.AddRazorComponents().AddInteractiveServerComponents();

_ = builder.Services.AddHttpClient<WeatherApiClient>(client =>
    // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
    // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
    client.BaseAddress = new("https+http://apiservice"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

_ = app.UseHttpsRedirection();
_ = app.UseStaticFiles();
_ = app.UseAntiforgery();
_ = app.UseOutputCache();
_ = app.MapRazorComponents<App>()
       .AddInteractiveServerRenderMode();
_ = app.MapDefaultEndpoints();

app.Run();
