using AutoMapper;
using MediatR;

namespace App.Application.Features.RootCompany.Queries.GetcountryList { }
public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, List<CountriesDto>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public GetCountryListQueryHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<CountriesDto>> Handle(GetCountryListQuery request,
            CancellationToken cancellationToken)
    {
        var countryList = await _countryRepository.GetAllAsync();
        return _mapper.Map<List<CountriesDto>>(countryList);
    }
}

