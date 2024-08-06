using CustomerOrdersBlazor.Data;
using CustomerOrdersBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// For console logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddHttpClient<CustomerService>();

builder.Services.AddHttpClient<OrderService>();

builder.Services.AddScoped<CustomerService>();

builder.Services.AddScoped<OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

Console.WriteLine("This is a test log message.");

app.Logger.LogInformation("Application started");


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapBlazorHub();

app.MapFallbackToPage("/_Host");

app.Run();
