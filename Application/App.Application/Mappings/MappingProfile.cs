using AutoMapper;

namespace App.Application.Mappings { }

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RootCompany, RootCompanyDto>().ReverseMap();


        CreateMap<AddCountryRequest, CountriesDto>().ReverseMap();
        CreateMap<Country, CountriesDto>().ReverseMap();
        CreateMap<Country, AddCountryRequest>().ReverseMap();
        CreateMap<Country, UpdateCountryRequest>().ReverseMap();
        CreateMap<UpdateCountryRequest, CountriesDto>().ReverseMap();

        CreateMap<City, AddCityRequest>().ReverseMap();
        CreateMap<City, UpdateCityRequest>().ReverseMap();
        CreateMap<City, CityDto>().ReverseMap();
        CreateMap<UpdateCityRequest, CityDto>().ReverseMap();
    }
}
