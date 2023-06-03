using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.Country.Commands.AddCountry { }

public class AddCountryHandler : IRequestHandler<AddCountryRequest, int>
{
    readonly ICountryRepository _countryRepository;
    readonly IMapper mapper;

    public AddCountryHandler(ICountryRepository unitOfWork, IMapper mapper,
        ILogger<AddCountryHandler> logger)
    {
        _countryRepository = unitOfWork;
        this.mapper = mapper;

    }

    public async Task<int> Handle(AddCountryRequest request, CancellationToken cancellationToken)
    {
        var newCountry = await _countryRepository.AddAsync(mapper.Map<Country>(request));

        return newCountry.Id;
    }
}

