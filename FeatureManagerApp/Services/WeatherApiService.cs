using AutoMapper;
using Microsoft.Extensions.Options;
using FeatureManagerApp.Models;
using FeatureManagerApp.Models.WeatherApi;
using FeatureManagerApp.Settings;
using Newtonsoft.Json;

namespace FeatureManagerApp.Services
{
    public class WeatherApiService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly string _apiKey;

        public WeatherApiService(
            HttpClient httpClient,
            IOptions<WeatherApiSettings> options,
            IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _apiKey = options.Value.ApiKey;
        }

        public async Task<WeatherResponse> GetByCityAsync(string city)
        {
            var path = $"?key={_apiKey}&q={city}&aqi=no";
            using var httpResponseMessage = await _httpClient.GetAsync(path);
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            var weatherResponse = JsonConvert.DeserializeObject<Response>(response);
            var result = _mapper.Map<WeatherResponse>(weatherResponse);
            return result;
        }
    }
}
