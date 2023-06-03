using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.Country.Commands.UpdateCity { }
public class UpdateCityHandler : IRequestHandler<UpdateCityRequest>
{
    readonly ICityRepository _cityRepository;
    readonly IMapper _mapper;

    public UpdateCityHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCityRequest request, CancellationToken cancellationToken)
    {
        var cityToUpdate = await _cityRepository.GetByIdAsync(request.Id);
        if (cityToUpdate == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }

        _mapper.Map(request, cityToUpdate, typeof(UpdateCityRequest), typeof(City));

        await _cityRepository.UpdateAsync(cityToUpdate);

        return;
    }
}

