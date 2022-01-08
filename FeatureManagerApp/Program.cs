using FeatureManagerApp.Services;
using FeatureManagerApp.Settings;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<WeatherApiSettings>(builder.Configuration.GetSection("WeatherApi"));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddFeatureManagement();

builder.Services.AddHttpClient<WeatherApiService>( 
    "WeatherApi", 
    (serviceProvider, client) => 
    {
        var config = serviceProvider.GetRequiredService<IOptions<WeatherApiSettings>>().Value; 
        client.BaseAddress = new Uri(config.BaseAddress); 
    }); 

builder.Services.AddScopedFeature<IWeatherService, WeatherApiServiceStub, WeatherApiService>(nameof(FeatureSettings.UseWeatherApiStub));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();