

using AutoMapper;

namespace App.Application.Mappings { }

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RootCompany, RootCompanyDto>().ReverseMap();
        CreateMap<Country, CountriesDto>().ReverseMap();
        //CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
        //CreateMap<Order, UpdateOrderCommand>().ReverseMap();
    }
}
