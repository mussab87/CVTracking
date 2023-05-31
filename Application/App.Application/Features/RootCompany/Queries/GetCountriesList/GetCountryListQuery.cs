
using MediatR;

namespace App.Application.Features.RootCompany.Queries.GetCityList { }
public class GetCountryListQuery : IRequest<List<CountriesDto>>
{
    public GetCountryListQuery()
    {
    }
}
