using AutoMapper;
using MediatR;

namespace App.Application.Features.City.Queries.GetCitiesList { }
public class GetCityListQueryHandler : IRequestHandler<GetCityListQuery, List<CityDto>>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetCityListQueryHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<CityDto>> Handle(GetCityListQuery request,
            CancellationToken cancellationToken)
    {
        var cityList = await _cityRepository.GetAsync(null, null, "CountryCity", true);
        return _mapper.Map<List<CityDto>>(cityList);
    }
}

