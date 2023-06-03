using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.City.Commands.AddCity { }

public class AddCityHandler : IRequestHandler<AddCityRequest, int>
{
    readonly ICityRepository _cityRepository;
    readonly IMapper mapper;

    public AddCityHandler(ICityRepository unitOfWork, IMapper mapper,
        ILogger<AddCountryHandler> logger)
    {
        _cityRepository = unitOfWork;
        this.mapper = mapper;

    }

    public async Task<int> Handle(AddCityRequest request, CancellationToken cancellationToken)
    {
        var newCity = await _cityRepository.AddAsync(mapper.Map<City>(request));

        return newCity.Id;
    }
}

