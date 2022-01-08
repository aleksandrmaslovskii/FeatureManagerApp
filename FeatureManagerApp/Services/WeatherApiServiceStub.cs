using FeatureManagerApp.Models;

namespace FeatureManagerApp.Services
{
    public class WeatherApiServiceStub : IWeatherService
    {
        public Task<WeatherResponse> GetByCityAsync(string city)
        {
            return Task.FromResult(new WeatherResponse
            {
                Date = DateTime.Now,
                TemperatureCelsius = 0,
                Description = "Freezing"
            });
        }
    }
}
