using MediatR;

namespace App.Application.Features.Country.Queries.GetCountriesList { }
public class GetCountryListQuery : IRequest<List<CountriesDto>>
{
    public GetCountryListQuery()
    {
    }
}
