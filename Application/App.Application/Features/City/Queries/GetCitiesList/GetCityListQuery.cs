using MediatR;

namespace App.Application.Features.City.Queries.GetCountriesList { }
public class GetCityListQuery : IRequest<List<CityDto>>
{
}
