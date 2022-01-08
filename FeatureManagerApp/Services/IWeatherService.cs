using FeatureManagerApp.Models;

namespace FeatureManagerApp.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetByCityAsync(string city);
    }
}
