

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
        //CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
        //CreateMap<Order, UpdateOrderCommand>().ReverseMap();
    }
}
