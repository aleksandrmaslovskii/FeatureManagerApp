using AutoMapper;
using FeatureManagerApp.Models;
using FeatureManagerApp.Models.WeatherApi;

namespace FeatureManagerApp.Settings;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Response, WeatherResponse>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Location.Localtime)))
            .ForMember(dest => dest.TemperatureCelsius, opt => opt.MapFrom(src => src.Current.TempC))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Current.Condition.Text));
    }
}